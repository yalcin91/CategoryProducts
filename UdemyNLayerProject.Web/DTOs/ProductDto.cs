using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "{0} alani 1 den buyuk bir deger olmali")]
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alani gereklidir")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "{0} alani 1 den buyuk bir deger olmali")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} alani 1 den buyuk bir deger olmali")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
