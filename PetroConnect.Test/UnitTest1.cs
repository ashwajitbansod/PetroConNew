using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using PetroConnect.Data.Context;
using PetroConnect.API.Controllers;
using PetroConnect.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PetroConnect.API.Models;

namespace PetroConnect.Test
{
    [TestFixture]
    public class Tests
    {
        private Mock<IUserService> userService;

        [SetUp]
        public void SetUp()
        {
            userService = new Mock<IUserService>();
        }


        //[Test]
        //public void Test1()
        //{
        //    var mockTest = new Mock<DbSet<TestData>>();
        //    var mockContext = new Mock<PetroConnectContext>();
        //    //var userService = new Mock<IUserService>();
        //    var objUserController = new UsersController(userService.Object);

        //    IActionResult result = objUserController.GetAll();
        //    Assert.IsNotNull(result);

        //    var re = (OkObjectResult)result;
        //    Assert.IsTrue(re.StatusCode == 200);
        //}

        [TestCase("i", "Rick", "Darel", 13123, "UserType", 34234)]
        public async Task RegistrationTeam_Positive(string action, string fName, string lName, long LoginId, string role, long userId)
        {
            var mockTest = new Mock<DbSet<Sp_ResultModals>>();
            var mockContext = new Mock<PetroConnectContext>();
            var userService = new Mock<IUserService>();
            //var objUserController = new UsersController(userService.Object,);

            var objPara = new TeamModel
            {
                Action = action,
                ULA_FirstName = fName,
                ULA_LastName = lName,
                ULA_LoginId = LoginId,
                ULA_Roll = role,
                ULA_UID_UserId = userId

            };
            //var objParam = new Mock<TeamModel>();
            //objParam.Setup(x => It.IsAny<TeamModel>() ).Returns(new TeamModel
            //{
            //    ULA_FirstName = "vij",
            //    Action = 'I',
            //    ULA_LastName = "jhkjhk",
            //    ULA_LoginId = 234324,
            //    ULA_Roll = "34",
            //    ULA_UID_UserId = 324
            //});

            //IActionResult result = await objUserController.RegistrationTeam(objPara);
            //Assert.IsNotNull(result);

            //var re = (OkObjectResult)result;
            //Assert.IsTrue(re.StatusCode == 200);
        }




        [TestCase('i' , "Rick", "Darel", 13123, "UserType", 34234)]
        public async Task RegistrationTeam_Negative(char action, string fName, string lName, long LoginId, string role, long userId)
        {
            //var mockTest = new Mock<DbSet<Sp_ResultModals>>();
            //var mockContext = new Mock<PetroConnectContext>();
            //var userService = new Mock<IUserService>();
            //var objUserController = new TeamController(userService.Object);

            //var objPara = new TeamModel
            //{
            //    Action = action,
            //    ULA_FirstName = fName,
            //    ULA_LastName = lName,
            //    ULA_LoginId = LoginId,
            //    ULA_Roll = role,
            //    ULA_UID_UserId = userId

            //};

            //IActionResult result = await objUserController.RegistrationTeam(objPara);
            //Assert.IsNotNull(result);

            //var re = result as OkObjectResult;
            //Assert.IsNotNull(re);
            //Assert.IsTrue(re.StatusCode == 200);
        }


    }
}