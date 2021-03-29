using System.Collections.Generic;

namespace UdemyNLayerProject.API.DTOs
{
    public class CategoryWithProducts : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
