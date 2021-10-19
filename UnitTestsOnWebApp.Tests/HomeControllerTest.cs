using DataProject.Repositories.Interfaces;
using System;
using FluentAssertions;
using Xunit;
using NSubstitute;
using System.Collections.Generic;
using DataProject.Entities;
using UnitTestsOnWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoBogus;

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

            var actual = homeController.Index();

            actual.As<ViewResult>().Model.Should().BeOfType<List<User>>();
        }

        [Fact]
        public void Index_ExecuteIndexWithRandomParametr_ResultTypeIsViewResult()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserRange(Arg.Any<int>(), Arg.Any<int>()).Returns(new List<User>());
            HomeController homeController = new HomeController(userRepository);

            var actual = homeController.Index(AutoFaker.Generate<int>(), AutoFaker.Generate<int>());

            actual.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Index_ExecuteIndexWithRandomParametr_ModelTypeIsList()
        {
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserRange(Arg.Any<int>(), Arg.Any<int>()).Returns(new List<User>());
            HomeController homeController = new HomeController(userRepository);


            var actual = homeController.Index(AutoFaker.Generate<int>(), AutoFaker.Generate<int>());

            actual.As<ViewResult>().Model.Should().BeOfType<List<User>>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void Index_ExecuteIndexWithNoParametr_ResultLenghtSameAsRepositoryResponce(int inputDatataLenght)
        {
            List<User> dataSource = DataGeneration(inputDatataLenght);
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetAll().Returns(dataSource);
            HomeController homeController = new HomeController(userRepository);
            int expected = inputDatataLenght;
            
            var actual = homeController.Index();

            actual.As<ViewResult>().Model.As<List<User>>().Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void Index_ExecuteIndexWithNoParametr_ResultListSameAsRepositoryResponce(int inputDatataLenght)
        {
            List<User> dataSource = DataGeneration(inputDatataLenght);
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetAll().Returns(dataSource);
            HomeController homeController = new HomeController(userRepository);
            var expected = dataSource;

            var actual = homeController.Index();

            actual.As<ViewResult>().Model.As<List<User>>().Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(0, 1, 2)]
        [InlineData(0, -1, 2)]
        public void Index_ExecuteIndexWithRandomParametr_ResultListSameAsRepositoryResponce(int inputDatataLenght, int start, int end)
        {
            List<User> dataSource = DataGeneration(inputDatataLenght);
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserRange(Arg.Any<int>(), Arg.Any<int>()).Returns(dataSource);
            HomeController homeController = new HomeController(userRepository);
            var expected = dataSource;

            var actual = homeController.Index(start, end);

            actual.As<ViewResult>().Model.As<List<User>>().Should().BeEquivalentTo(expected);
        }
        [Theory]
        [InlineData(0, 1, 2)]
        [InlineData(0, -1, 2)]
        public void Index_ExecuteIndexWithNoParametr_ResultListAsContainsApropriateItemsFromDataSource(int inputDatataLenght, int start, int end)
        {
            List<User> dataSource = DataGeneration(inputDatataLenght);
            IUserRepository userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserRange(Arg.Any<int>(), Arg.Any<int>()).Returns(dataSource);
            HomeController homeController = new HomeController(userRepository);
            var expected = dataSource;


            var actual = homeController.Index(start, end);

            actual.As<ViewResult>().Model.As<List<User>>().Should().BeEquivalentTo(expected);
        }


        private List<User> DataGeneration(int userAmount)
        {
            List<User> users = new List<User>();
            var userFaker = new AutoFaker<User>()
                .RuleFor(fake => fake.Id, fake => fake.IndexFaker)
                .RuleFor(fake => fake.Name, fake => fake.Name.FirstName());
            for(int i =0; i < userAmount; i++)
            {
                users.Add(userFaker.Generate());
            }
            return users;
        }

    }
}
