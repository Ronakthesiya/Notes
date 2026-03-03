using System.Web.Http;
using WebActivatorEx;
using ImageFilesDemo;
using Swashbuckle.Application;
using Swashbuckle.Swagger;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ImageFilesDemo
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ImageFilesDemo");

                        // Specify that the file input uses multipart/form-data for uploads
                        c.OperationFilter<FileUploadOperationFilter>();
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }
    }
}
