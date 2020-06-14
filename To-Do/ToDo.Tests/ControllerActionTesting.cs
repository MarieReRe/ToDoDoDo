using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using To_Do.Controllers;
using To_Do.Models;
using To_Do.Models.Identity;
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
        // ----------------------------Testing user functionality-----------------------------------
        //----------------------------
        [Fact]
        public async Task LoginFailsWithMissingUser()
        {
            // Arrange
            var userManager = new Mock<IUserManager>();

            var login = new LoginData { Username = "Maaaaaaariee" };

            var controller = new UsersController(userManager.Object);

            // Act
            var result = await controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }


        [Fact]
        public async Task LoginFailsWithInvalidPassword()
        {
            // Arrange
            var userManager = new Mock<IUserManager>();

            var login = new LoginData { Username = "Cyclones09" };

            userManager.Setup(s => s.FindByNameAsync(login.Username))
                .ReturnsAsync(new ToDoUser { UserName = login.Username });

            var controller = new UsersController(userManager.Object);

            // Act
            var result = await controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
        [Fact]
        public async Task LoginSucceedsWithValidPassword()
        {
            // Arrange
            var userManager = new Mock<IUserManager>();

            var login = new LoginData { Username = "ItsMeMarie", Password = "!124D!!" };

            var user = new ToDoUser { UserName = login.Username };
            userManager.Setup(s => s.FindByNameAsync(login.Username))
                .ReturnsAsync(user);

            userManager.Setup(s => s.CheckPasswordAsync(user, login.Password))
                .ReturnsAsync(true);

            userManager.Setup(s => s.CreateToken(user))
                .Returns("test token!");

            var controller = new UsersController(userManager.Object);

            // Act
            var result = await controller.Login(login);

            // Assert
            //First we check if its the correct type, then we check what its actually returning
            var okResult = Assert.IsType<OkObjectResult>(result);
            var userWithToken = Assert.IsType<UserWithToken>(okResult.Value);
            Assert.Equal(user.Id, userWithToken.UserId);
            Assert.Equal("test token!", userWithToken.Token);
        }
        [Fact]
        public async Task UpdateMissingUserReturnsA404()
        {
            //arrange
            var userService = new Mock<IUserManager>();

            userService.Setup(s => s.UpdateAsync(null)).Throws(new System.ArgumentNullException());
            
            var controller = new UsersController(userService.Object);
            //act
            var result = await controller.UpdateUser("aNewName", new UpdateUserData());

            // assert
            Assert.IsType<NotFoundResult>(result);
        }
        //change this to a theory
      /*  [Fact]
        public async Task UserUpdatedSuccess()
        {
            //arrange
            var userService = new Mock<IUserManager>();

            var user = new ToDoUser
            {
                Id = "77",
                UserName = "Wow"
            };

            userService.Setup(s => s.FindByIdAsync(user.Id)).ReturnsAsync(user);
            var controller = new UsersController(userService.Object);
            var data = new UpdateUserData { FirstName = "Jessica" };

            //act
            var result = await controller.UpdateUser(user.Id, data);
            // assert
         var okResult = Assert.IsType<OkObjectResult>(result);
          var savedUser =   Assert.IsType<UserDTO>(okResult.Value)
            userService.Verify(s => s.UpdateAsync(user));
        }
      */

    }
}
