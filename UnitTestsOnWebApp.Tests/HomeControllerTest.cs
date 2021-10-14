using DataProject.Repositories.Interfaces;
using System;
using FluentAssertions;
using Xunit;
using NSubstitute;
using System.Collections.Generic;
using DataProject.Entities;
using UnitTestsOnWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Bogus;

namespace UnitTestsOnWebApp.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ExecuteIndexWithNoParametr_ResultTypeIsViewResult()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetAll().Returns(new List<User>());
            HomeController homeController = new HomeController(userRepository);

            var actual = homeController.Index();

            actual.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Index_ExecuteIndexWithNoParametr_ModelTypeIsList()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetAll().Returns(new List<User>());
            HomeController homeController = new HomeController(userRepository);

            var actual = homeController.Index() as ViewResult;

            actual.Model.Should().BeOfType<List<User>>();
        }

        [Fact]
        public void Index_ExecuteIndexWithRandomParametr_ResultTypeIsViewResult()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserRange(Arg.Any<int>(), Arg.Any<int>()).Returns(new List<User>());
            HomeController homeController = new HomeController(userRepository);
            Randomizer random = new Randomizer();

            var actual = homeController.Index(random.Int(), random.Int());

            actual.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Index_ExecuteIndexWithRandomParametr_ModelTypeIsList()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserRange(Arg.Any<int>(), Arg.Any<int>()).Returns(new List<User>());
            HomeController homeController = new HomeController(userRepository);
            Randomizer random = new Randomizer();


            var actual = homeController.Index(random.Int(), random.Int()) as ViewResult;

            actual.Model.Should().BeOfType<List<User>>();
        }
    }
}
