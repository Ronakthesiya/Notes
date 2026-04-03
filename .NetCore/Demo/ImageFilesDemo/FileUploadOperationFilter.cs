using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ImageFilesDemo
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.HttpMethod.Method != "POST")
                return;

            if (!apiDescription.RelativePath.ToLower().Contains("upload"))
                return;

            operation.consumes.Add("multipart/form-data");

            operation.parameters = new List<Parameter>
            {
                new Parameter
                {
                    name = "file",
                    @in = "formData",
                    type = "file",
                    required = true
                }
            };
        }
    }
}