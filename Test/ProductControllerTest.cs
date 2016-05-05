using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Products;
using NMock;
using Infraestructura;
using System.Collections.Generic;
using MvcApplication14.Controllers;
using System.Web.Mvc;

namespace Test
{
    [TestClass]
    public class ProductControllerTest
    {
        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }


        [TestMethod]
        public void NumberOfProductsEqualsOne()
        {
            // Arrange
            var repository = _factory.CreateMock<IRepositoryProduct>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var productController = new ProductController(repository.MockObject, unitOfWork.MockObject);
            
            var products = new HashSet<Product>() {
                new Product() {Name = "pera"}
            };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(products);
            unitOfWork.Expects.One.Method(c => c.Dispose());

            // Act
            var result = ((productController.Index() as ViewResult).Model) as List<Product>;
            productController.Dispose();
            // Assert
            Assert.AreEqual(1, result.Count);
            //Assert.AreEqual("pera", result);
        }
    }
}
