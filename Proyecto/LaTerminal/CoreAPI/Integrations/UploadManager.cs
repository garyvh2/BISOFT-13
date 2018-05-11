using CoreAPI.Managers;
using DataAccess.CRUD;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace CoreAPI.Integrations
{
    public class UploadManager
    {
        // >> CRUD Factory
        private UsuarioManager manager;
        // >> Constructor
        public UploadManager ()
        {
            manager = new UsuarioManager();
        }

        public void UploadImage(HttpRequest request, string folder)
        {
            try
            {
                // >> Se debe incluir una imagen
                if (request.Files.Count == 0)
                    // >> No imagenes en el request
                    throw new BussinessException(12);

                if (HttpContext.Current.Request.Form["id"] == null)
                    // >> El Id debe ser incluido
                    throw new BussinessException(12);

                var id = HttpContext.Current.Request.Form["id"];
                var usuario = manager.RetrieveById(new Usuario()
                {
                    Identificacion = id
                });


                foreach (string name in request.Files)
                {
                    HttpPostedFile file = request.Files[name];
                    // >> Comprobar si la imagen es invalida
                    if (file != null && file.ContentLength > 0)
                    {
                        // >> Tamano maximo y Formatos desde configuracion
                        var max_length          = ConfigurationService.GetItem<int>("MAX_CONTENT_LENGTH");
                        var allowed_file_ext    = ConfigurationService.GetItem<string>("ALLOWED_FILE_EXTENSIONS").Split(',').ToList();
                        
                        // >> extension
                        var ext = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower();

                        if (!allowed_file_ext.Contains(ext))
                        {
                            // >> Formato invalido
                            throw new BussinessException(13);
                        }
                        else if (file.ContentLength > max_length)
                        {
                            // >> Tamano exedido
                            throw new BussinessException(14);
                        }
                        else
                        {
                            // >> Build Path
                            var path = HttpContext.Current.Server.MapPath("~/App_Data/Images/" + folder  + "/" + id + ext);
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/App_Data/Images/" + folder  + "/"));
                            file.SaveAs(path);

                            // Update User
                            usuario.Foto = path;
                            manager.ActualizarFoto(usuario);
                        }
                    }
                    else
                    {
                        // >> Imagen Invalida
                        throw new BussinessException(15);
                    }
                };
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public HttpResponseMessage GetImage (string folder, string id)
        {
            try
            {
                var usuario = manager.RetrieveById(new Usuario()
                {
                    Identificacion = id
                });

                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StreamContent(new FileStream(usuario.Foto, FileMode.Open));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return response;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex, storeOnly: true);
                return null;
            }
        }
    }
}
