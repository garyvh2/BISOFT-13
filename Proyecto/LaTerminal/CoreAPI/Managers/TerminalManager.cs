using CoreAPI.Integrations;
using CoreAPI.Integrations.Models;
using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI.Managers
{
    public class TerminalManager : BaseManager, ICoreManager<Terminal>
    {

        private TerminalCrudFactory crudTerminal;
        private UsuarioCrudFactory CRUDUsuario;
        // >> Constructor
        public TerminalManager()
        {
            crudTerminal = new TerminalCrudFactory();
            CRUDUsuario = new UsuarioCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Terminal Create(Terminal terminal)
        {
            try
            {
                var dbTerminal = crudTerminal.Retrieve(terminal);

                if (dbTerminal != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var usuario = new Usuario()
                {
                    Identificacion = terminal.Id_Usuario,
                    Id_Terminal = terminal.CEDULA_JUR
                };

                var dbUserByTerminal = CRUDUsuario.RetrieveByTerminal(usuario);
                if (dbUserByTerminal != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(25);
                }

                usuario = CRUDUsuario.Retrieve(usuario);
                if (usuario == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(23);
                }

                var missingFields = CheckMissingFields(terminal, new string[] { });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                terminal = crudTerminal.Create(terminal);

                // >> Email Preparation
                var From = new EmailPerson(terminal.NOMBRE, terminal.CORREO);
                var To = new EmailPerson(usuario.Nombre_Completo, usuario.Correo);
                var Envelope = new EmailEnvelope()
                {
                    To = To,
                    From = From
                };

                
                Envelope.Subject = "[La Terminal] - Asignación de terminal";
                Envelope.Content.AddText($"Ha sido asignado como encargado de la terminal <b>{terminal.NOMBRE}</b>");

                if (usuario.First_Time == true)
                {
                    var Clave = PasswordManager.GetInstance().GenerateRandom();
                    usuario.First_Time = false;
                    usuario.Clave = PasswordManager.GetInstance().MD5Hash(Clave);
                    usuario = CRUDUsuario.Update(usuario);
                    Envelope.Content.AddText("Su contraseña temporal es:");
                    Envelope.Content.AddText($"<b>{Clave}</b>");
                    Envelope.Content.AddText("Por su seguridad no mantenga esta información al acceso de terceras personas.");
                }

                Envelope.Content.AddText("<br><hr>Detalles de terminal:");
                Envelope.Content.AddTable(
                    new List<string>() { "Cédula jurídica", "Nombre", "Dirección", "Correo" },
                    new List<List<string>>() { new List<string>() { terminal.CEDULA_JUR, terminal.NOMBRE, terminal.DIRECCION, terminal.CORREO } });
                EmailManager.GetInstance().SendMail(Envelope);


                usuario.Id_Terminal = terminal.CEDULA_JUR;
                CRUDUsuario.AsignarTerminal(usuario);

                return terminal;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Terminal RetrieveById(Terminal terminal)
        {
            try
            {
                terminal = crudTerminal.Retrieve(terminal);

                return terminal;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Terminal> RetrieveAll()
        {
            try
            {
                var terminal = crudTerminal.RetrieveAll();

                return terminal;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Terminal Update(Terminal terminal)
        {
            try
            {
                var dbTerminal = crudTerminal.Retrieve(terminal);

                if (dbTerminal == null)
                {
                    // >> Object is already update on the DB
                    throw new BussinessException(3);
                }

                var usuario = new Usuario()
                {
                    Identificacion = terminal.Id_Usuario,
                    Id_Terminal = terminal.CEDULA_JUR
                };


                usuario = CRUDUsuario.Retrieve(usuario);
                if (usuario == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(23);
                }

                if (usuario.Id_Rol != "ENCARGADO_TERMINAL")
                {
                    // >> Object is already on the DB
                    throw new BussinessException(24);
                }


                var missingFields = CheckMissingFields(terminal, new string[] { });
                missingFields.ForEach(missing =>
                {
                    terminal[missing] = dbTerminal[missing];
                });

                terminal = crudTerminal.Update(terminal);


                // >> Email Preparation
                var From = new EmailPerson(terminal.NOMBRE, terminal.CORREO);
                var To = new EmailPerson(usuario.Nombre_Completo, usuario.Correo);
                var Envelope = new EmailEnvelope()
                {
                    To = To,
                    From = From
                };
                
                Envelope.Subject = "[La Terminal] - Asignación de terminal";
                Envelope.Content.AddText($"Ha sido asignado como encargado de la terminal <b>{terminal.NOMBRE}</b>");

                if (usuario.First_Time == true)
                {
                    var Clave = PasswordManager.GetInstance().GenerateRandom();
                    usuario.First_Time = false;
                    usuario.Clave = PasswordManager.GetInstance().MD5Hash(Clave);
                    usuario = CRUDUsuario.Update(usuario);
                    Envelope.Content.AddText("Su contraseña temporal es:");
                    Envelope.Content.AddText($"<b>{Clave}</b>");
                    Envelope.Content.AddText("Por su seguridad no mantenga esta información al acceso de terceras personas.");
                }

                Envelope.Content.AddText("<br><hr>Detalles de terminal:");
                Envelope.Content.AddTable(
                    new List<string>() { "Cédula jurídica", "Nombre", "Dirección", "Correo" },
                    new List<List<string>>() { new List<string>() { terminal.CEDULA_JUR, terminal.NOMBRE, terminal.DIRECCION, terminal.CORREO } });
                EmailManager.GetInstance().SendMail(Envelope);
                
                usuario.Id_Terminal = terminal.CEDULA_JUR;
                CRUDUsuario.AsignarTerminal(usuario);

                return terminal;

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Terminal terminal)
        {
            try
            {
                var dbTerminal = crudTerminal.Retrieve(terminal);

                if (dbTerminal == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(4);
                }

                crudTerminal.Delete(terminal);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
    }
}
