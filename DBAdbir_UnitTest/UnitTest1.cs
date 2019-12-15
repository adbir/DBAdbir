using Xunit;
using Microsoft.AspNetCore.Mvc;
using DBAdbir;
using DBAdbir.Models;
using DBAdbir.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace DBAdbir_UnitTest
{

    public class UnitTest1
    {
        [Fact]
        public void TestAddMethodWithTwoPositiveNumbers()
        {
            var testService = new TestService();

            int result = testService.Add(2, 5);
            Assert.Equal(7, result);

        }

        [Fact]
        public void TestIndexMethodReturnsObjects()
        {
            //Arrange
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.Get()).Returns(DataTestService.GetTestCategories());
            var controller = new CategorysController(mockRepo.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Category>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void CreatePost_ReturnsViewWithCategories_WhenModelStateIsInvalid()
        {
            //Arrange
            var mockRepo = new Mock<ICategoryRepository>();
            var controller = new CategorysController(mockRepo.Object);

            controller.ModelState.AddModelError("Name", "Required");
            var categories = new Category() { Name = "", Description = "Fiskeaffald" };

            //Act
            var result = controller.Create(categories);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Category>(viewResult.ViewData.Model);
            Assert.IsType<Category>(model);
        }
        [Fact]
        public void CreatePost_SaveThroughRepository_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.Save(It.IsAny<Category>()))
                //.Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new CategorysController(mockRepo.Object);
            Category c = new Category()
            {
                Name = "Heste",
                Description = "Broholmere foretr�kkes. Ingen ponyer her."
            };

            // Act
            var result = controller.Create(c);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

    }
}
