using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceStack.DataAnnotations;

namespace DataGridAPI
{
    public class UserPatchDTO
    {
        [ValidateNever]
        public int? id { get; set; }

        [ValidateNever]
        public string? name { get; set; }

        [ValidateNever]
        public string? email { get; set; }

        [ValidateNever]
        public DateTime? bod { get; set; }

        [ValidateNever]
        public decimal? salary { get; set; }

        [ValidateNever]
        public bool? isActive { get; set; }

    }
}