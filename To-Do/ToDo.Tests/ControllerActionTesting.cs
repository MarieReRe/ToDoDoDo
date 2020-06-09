using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using To_Do.Controllers;
using To_Do.Models.Interfaces;
using To_Do.Models.Services;
using Xunit;

namespace ToDo.Tests
{
    public class ControllerActionTesting
    {
        
        [Fact]
        public void GetToDo_ReturnsHttpNotFound_ForInvalidToDo()
        {
            //arrange: SET 
            

            var mockRepo = new Mock<IToDoManager>();

          
            var controller = new ToDoController(mockRepo.Object);

            //act
           var actionResult = controller.DetailsForToDo(10);

            //assert

            Assert.IsType<NotFoundResult>( actionResult);
        }

      
    }
}
