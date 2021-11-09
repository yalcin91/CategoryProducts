using System.Collections.Generic;

namespace UdemyNLayerProject.Web.DTOs
{
    public class CategoryWithProducts : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
