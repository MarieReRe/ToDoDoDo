using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using To_Do.Controllers;
using To_Do.Models;
using To_Do.Models.Interfaces;
using To_Do.Models.Services;
using Xunit;

namespace ToDo.Tests
{
    public class ControllerActionTesting
    {
        
        [Fact]
        public async void GetToDo_ReturnsHttpNotFound_ForInvalidToDo()
        {
            //arrange:
            var mockRepo = new Mock<IToDoManager>();
            var controller = new ToDoController(mockRepo.Object);

            //act
           var actionResult = await controller.DetailsForToDo(10);

            //assert
            Assert.IsType<NotFoundResult>( actionResult.Result);
            Assert.Null(actionResult.Value);

        }
        [Fact]
        public async void DeleteReturnsOk()
        {
            //Arrange
            var mockRepo = new Mock<IToDoManager>();
            var controller = new ToDoController(mockRepo.Object);

            //Act
            var actionResult = await controller.DeleteToDo(10);
            

            //Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);

        }

      
    }
}
