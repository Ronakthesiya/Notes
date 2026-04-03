using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ImageFilesDemo.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public IHttpActionResult UploadImage()
        {
            HttpRequest httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count == 0)
                return BadRequest("No file uploaded.");

            HttpPostedFile file = httpRequest.Files[0];

            string path = HttpContext.Current.Server.MapPath("~/UploadedImages");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, file.FileName);
            file.SaveAs(filePath);

            return Ok(file.FileName);
        }


        [HttpGet]
        [Route("get/{fileName}")]
        public IHttpActionResult GetImage(string fileName)
        {
            var path = HttpContext.Current.Server.MapPath("~/UploadedImages/" + Path.GetFileName(fileName));

            if (!File.Exists(path))
                return NotFound();

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            // Direct assignment of the file bytes
            response.Content = new ByteArrayContent(File.ReadAllBytes(path));

            // Automatically sets the correct type (image/jpeg, image/png, etc.)
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(MimeMapping.GetMimeMapping(path));

            return ResponseMessage(response);
        }
    }
}
