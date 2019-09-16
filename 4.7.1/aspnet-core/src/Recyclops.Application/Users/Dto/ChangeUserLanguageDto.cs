using System.ComponentModel.DataAnnotations;

namespace Recyclops.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}