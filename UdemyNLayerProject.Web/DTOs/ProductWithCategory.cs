using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductWithCategory: ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
