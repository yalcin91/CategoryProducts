﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyNLayerProject.API.DTOs
{
    public class ProductWithCategory: ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
