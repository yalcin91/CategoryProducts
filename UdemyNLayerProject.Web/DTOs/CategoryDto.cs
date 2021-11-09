using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} mag niet leeg zijn")]
        public string Naam { get; set; }
    }
}
