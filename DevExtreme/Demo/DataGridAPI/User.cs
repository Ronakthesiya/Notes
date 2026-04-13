using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceStack.DataAnnotations;

namespace DataGridAPI
{
    public class User
    {
        [ValidateNever]
        public int id { get; set; }

        
        public string name { get; set; }

        
        public string email { get; set; }

        
        public DateTime bod { get; set; }

        
        public decimal salary { get; set; }

        
        public bool isActive { get; set; }

    }
}