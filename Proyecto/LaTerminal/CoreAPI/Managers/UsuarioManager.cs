using CoreAPI.Integrations;
using CoreAPI.Integrations.Models;
using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using DataAccess.CRUD.ArchitectureComponents;
using DataAccess.MAPPER;
using Entities.Classes;
using Entities.Entities;
using Entities.Entities.ArchitectureEntities;
using Exceptions;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    // >> ===================================================================================== <<
    // >> {Type}Manager <<
    // >> Es la clase encargada de procesar los datos sobre la logica del negocio
    // >> ===================================================================================== <<
    public class UsuarioManager : BaseManager
    {
        // >> CRUD Factory
        private UsuarioCrudFactory crudUsuario;
        // >> CRUD Usuario Logs
        private Usuario_LogsCrudFactory crudUsuarioLogs;
        // >> Constructor
        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
            crudUsuarioLogs = new Usuario_LogsCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Usuario Create(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve(usuario);
                var dbUserCorreo = crudUsuario.RetrieveByCorreo(usuario);
                if (dbUser != null || dbUserCorreo != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                if (usuario.Clave == null)
                    usuario.Clave = PasswordManager.GetInstance().GenerateRandom();

                var missingFields = CheckMissingFields(usuario, new string[] { "Foto", "SNombre", "SApellido", "Clave_Salt", "Id_Terminal", "Id_Empresa_Bus", "First_Time" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                usuario.Clave = PasswordManager.GetInstance().MD5Hash(usuario.Clave);

                return usuario = crudUsuario.Create(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Usuario RetrieveById(Usuario usuario)
        {
            try
            {
                usuario = crudUsuario.Retrieve(usuario);

                return usuario;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Usuario> RetrieveAll()
        {
            try
            {
                var usuarios = crudUsuario.RetrieveAll();

                usuarios.ForEach(usuario =>
                {
                    usuario.Agrupar = (usuario.PNombre ?? " ").Substring(0, 1);
                });

                return usuarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Usuario Update(Usuario usuario, bool omit_encrypt = false)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // Si no se cambia la contrasenna entonces se mantiene la contrasenna
                if (usuario.Clave == null)
                    omit_encrypt = true;
                // Omit nullable properties
                var missingFields = CheckMissingFields(usuario, new string[] { "Id_Empresa_Bus", "Id_Terminal" });
                missingFields.ForEach(missing =>
                {
                    usuario[missing] = dbUser[missing];
                });
                if (!omit_encrypt)
                    usuario.Clave = PasswordManager.GetInstance().MD5Hash(usuario.Clave);

                if (!dbUser.Approved && usuario.Approved && dbUser.Id_Rol == "JURIDICO")
                {
                    var To = new EmailPerson(dbUser.Nombre_Completo, dbUser.Correo);
                    var Envelope = new EmailEnvelope()
                    {
                        To = To
                    };
                    
                    Envelope.Subject = "[La Terminal] - Cuenta Aprobada";
                    Envelope.Content.AddText("Gracias por unirte a La Terminal");
                    Envelope.Content.AddText("Su cuenta juridica ha sido aprobada");
                    EmailManager.GetInstance().SendMail(Envelope);
                }


                return usuario = crudUsuario.Update(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                var usuario_log = new Usuario_Logs()
                {
                    Id_Usuario = usuario.Identificacion,
                    Fecha = DateTime.Now,
                    Evento = "DELETE_ACCOUNT"
                };
                crudUsuarioLogs.Create(usuario_log);

                crudUsuario.Delete(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Login User
        public Usuario Login(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.RetrieveByCorreo(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(6);
                }


                var missingFields = CheckMissingFields(usuario, only: new String[] { "correo", "clave" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                // TODO:
                // Encriptar la clave
                usuario.Clave = PasswordManager.GetInstance().MD5Hash(usuario.Clave);
                usuario = crudUsuario.Login(usuario);

                if (usuario == null)
                {
                    throw new BussinessException(5);
                }
                else
                {
                    var usuario_log = new Usuario_Logs()
                    {
                        Id_Usuario = usuario.Identificacion,
                        Fecha = DateTime.Now,
                        Evento = "LOGIN"
                    };
                    crudUsuarioLogs.Create(usuario_log);

                    return usuario;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Recuperar Clave
        public Usuario Recover(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.RetrieveByCorreo(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(6);
                }

                var missingFields = CheckMissingFields(usuario, only: new String[] { "correo" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                // TODO:
                // Encriptar la clave
                usuario.Identificacion = dbUser.Identificacion;
                usuario.Clave = PasswordManager.GetInstance().GenerateRandom();

                var email = new EmailPerson(dbUser.PNombre + ' ' + dbUser.PApellido, usuario.Correo);

                var envelope = new EmailEnvelope();
                envelope.Content.AddText($"Saludos {email.Nombre}, gracias por contactarnos");
                envelope.Content.AddText("Hemos recibido una solicitud de cambio de contraseña");
                envelope.Content.AddText("Su nueva contraseña es:");
                envelope.Content.AddText($"<b>{usuario.Clave}</b>");
                envelope.Content.AddText("Por su seguridad no mantenga esta información al acceso de terceras personas.");
                envelope.Subject = "[La Terminal] - Recuperar contraseña";
                envelope.To = email;

                EmailManager.GetInstance().SendMail(envelope).GetAwaiter().GetResult();

                var usuario_log = new Usuario_Logs()
                {
                    Id_Usuario = usuario.Identificacion,
                    Fecha = DateTime.Now,
                    Evento = "RECOVER_PASS"
                };

                usuario.Clave = PasswordManager.GetInstance().MD5Hash(usuario.Clave);
                crudUsuarioLogs.Create(usuario_log);


                return crudUsuario.ActualizarClave(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Actualizar Clave
        public Usuario ActualizarClave(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // TODO
                // Omit nullable properties
                var missingFields = CheckMissingFields(usuario, only: new string[] { "Identificacion", "Clave" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                // Validar formato de clave
                Match match = Regex.Match(usuario.Clave, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])");
                if (!match.Success)
                    throw new BussinessException(18);
                
                usuario.Clave = PasswordManager.GetInstance().MD5Hash(usuario.Clave);
                usuario.Clave_Actual = PasswordManager.GetInstance().MD5Hash(usuario.Clave_Actual);

                // Validar Clave Actual
                if (usuario.Clave_Actual != dbUser.Clave)
                    throw new BussinessException(19);

                // Validar 6 claves anteriores
                var clave_valida = PasswordManager.GetInstance().VerificarClavesAnteriores(usuario);
                if (!clave_valida)
                    throw new BussinessException(17);

                var usuario_log = new Usuario_Logs()
                {
                    Id_Usuario = usuario.Identificacion,
                    Fecha = DateTime.Now,
                    Evento = "CHANGE_PASS"
                };
                crudUsuarioLogs.Create(usuario_log);

                return usuario = crudUsuario.ActualizarClave(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Actualizar Foto
        public Usuario ActualizarFoto(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }
                // TODO
                // Omit nullable properties
                var missingFields = CheckMissingFields(usuario, only: new string[] { "Identificacion", "Foto" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));
                
                var usuario_log = new Usuario_Logs()
                {
                    Id_Usuario = usuario.Identificacion,
                    Fecha = DateTime.Now,
                    Evento = "CHANGE_PHOTO"
                };
                crudUsuarioLogs.Create(usuario_log);

                return usuario = crudUsuario.ActualizarFoto(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List by rol
        public List<Usuario> RetrieveAllByRol(Usuario usuario)
        {
            try
            {
                var usuarios = crudUsuario.RetrieveAllByRol(usuario);

                usuarios.ForEach(user =>
                {
                    usuario.Agrupar = (usuario.PNombre ?? " ").Substring(0, 1);
                });

                return usuarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List by rol
        public List<Usuario> RetrieveAllByTerminalOrEmpresa(Usuario usuario)
        {
            try
            {
                var usuarios = crudUsuario.RetrieveAllByTerminalOrEmpresa(usuario);

                usuarios.ForEach(user =>
                {
                    usuario.Agrupar = (user.PNombre ?? " ").Substring(0, 1);
                });

                return usuarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Usuario UsuarioXTarjeta(Tarjeta tarjeta)
        {
            try
            {
                Usuario u = new Usuario();

                //u.Identificacion = tarjeta.usuario;

                return RetrieveById(u);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

        public Usuario UsuarioXRol(Usuario usuario)
        {
            try
            {
                return crudUsuario.RetrieveByRol(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
