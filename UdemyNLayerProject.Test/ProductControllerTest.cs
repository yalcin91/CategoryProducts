using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UdemyNLayerProject.API.Controllers;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Mapping;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;

using Xunit;

namespace UdemyNLayerProject.Test
{
    public class ProductControllerTest
    {
        //private readonly MapperConfiguration configurationProvider = new MapperConfiguration(;
        private readonly Mapper _mapper;
        private readonly Mock<IProductService> _mockRepo;
        private readonly ProductsController _controller;
        private List<Product> products;
        private List<ProductDto> productDtos;

        public ProductControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = (Mapper)mapper;
            }
            _mockRepo = new Mock<IProductService>();
            _controller = new ProductsController(_mockRepo.Object, _mapper);

            productDtos = new List<ProductDto>() {
                new ProductDto { Id = 1, CategoryId = 1, Name = "Kalem", Price = 12.25m, Stock = 115 },
                new ProductDto { Id = 2, CategoryId = 2, Name = "Silgec", Price = 11.78m, Stock = 86}};

            products = new List<Product>() { 
                new Product { Id = 1, CategoryId = 1, Name = "Kalem", Price = 12.25m, Stock = 115 },
                new Product { Id = 2, CategoryId = 2, Name = "Silgec", Price = 11.78m, Stock = 86}};
        }

        [Fact]
        public async void GetProduct_ActionExecutes_ReturnOkWithProduct()
        {
            _mockRepo.Setup(x=>x.GetAllAsync()).ReturnsAsync(products);
            var result = await _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProducts = Assert.IsAssignableFrom<List<ProductDto>>(okResult.Value);
            Assert.Equal<int>(2, returnProducts.ToList().Count);
        }

        [Fact]
        public async void GetProduct_ActionExecutes_ReturnNotFound()
        {
            List<Product> l = null;
            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(l);
            var result = await _controller.GetAll();
            Assert.IsType<NotFoundResult>(result);
        }


        [Theory]
        [InlineData(0)]
        public async void GetProduct_IdInValid_ReturnNotFound(int productId)
        {
            Product product = null;
            _mockRepo.Setup(x=>x.GetByIdAsync(productId)).ReturnsAsync(product);
            var result = await _controller.GetById(productId);
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetProduct_IdInValid_ReturnOk(int productId)
        {
            var product = products.First(x=>x.Id == productId);
            _mockRepo.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);
            var result = await _controller.GetById(productId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(productId, returnProduct.Id);
            Assert.Equal(product.Name, returnProduct.Name);
        }

       /* [Fact]
        public  void PutProduct_IdIsNotEqualProduct_ReturnBadRequest()
        {
            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            //ProductDto productDto = new ProductDto();
            var product1 = productDtos.First();
            //product1.Id = 2;
            var result =  _controller.Update(product1);
            //Assert.IsType<OkObjectResult>(result);
            //var returnProduct = Assert.IsAssignableFrom<NoContentResult>(result);
            var badRequest = Assert.IsAssignableFrom<BadRequestResult>(result);
            //Assert.Equal(returnProduct.Id, product1.Id);
            //Assert.Equal(returnProduct.Name, product1.Name);

            /*_mockRepo.Setup(x => x.Update()).ReturnsAsync(products);
            var result = await _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProducts = Assert.IsAssignableFrom<List<ProductDto>>(okResult.Value);
            Assert.Equal<int>(2, returnProducts.ToList().Count);
        }*/

        [Fact]
        public  void PutProduct_IdIsEqualProduct_ReturnNoContent()
        {
            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var product1 = productDtos.First();
            var result =  _controller.Update(product1);
            var returnProduct = Assert.IsAssignableFrom<NoContentResult>(result);
        }
    }
}
