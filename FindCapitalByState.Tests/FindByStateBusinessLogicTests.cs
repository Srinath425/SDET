using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindCapitalByState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace FindCapitalByState.Tests
{
    [TestClass]
    public class FindByStateBusinessLogicTests
    {
        IFindByStateBusinessLogic findByState = new FindByStateBusinessLogic();

        [TestMethod]
        public void FindCityByState_Should_Pass_For_Valid_Input_State_Abbriviation()
        {
            var mockFindByStateLogic = new Mock<IFindByStateBusinessLogic>();

            mockFindByStateLogic.Setup(f => f.HttpGetResponse()).Returns("{\r\n    \"RestResponse\": {\r\n        \"messages\": [\r\n            \"Total [55] records found.\"\r\n        ],\r\n        \"result\": [\r\n            {\r\n                \"id\": 1,\r\n                \"country\": \"USA\",\r\n                \"name\": \"Alabama\",\r\n                \"abbr\": \"AL\",\r\n                \"area\": \"135767SKM\",\r\n                \"largest_city\": \"Birmingham\",\r\n                \"capital\": \"Montgomery\"\r\n            }]\r\n\t}\r\n}");

            string inputValue = "AL";
            var response = findByState.FindCityByState(inputValue);

            Assert.IsNotNull(response);
            Assert.AreEqual("Montgomery", response.Capital);
            Assert.AreEqual("Birmingham", response.LargestCity);
        }

        [TestMethod]
        public void FindCityByState_Should_Pass_For_Valid_Input_State_Name()
        {
            var mockFindByStateLogic = new Mock<IFindByStateBusinessLogic>();

            mockFindByStateLogic.Setup(f => f.HttpGetResponse()).Returns("{\r\n    \"RestResponse\": {\r\n        \"messages\": [\r\n            \"Total [55] records found.\"\r\n        ],\r\n        \"result\": [\r\n            {\r\n                \"id\": 1,\r\n                \"country\": \"USA\",\r\n                \"name\": \"Alabama\",\r\n                \"abbr\": \"AL\",\r\n                \"area\": \"135767SKM\",\r\n                \"largest_city\": \"Birmingham\",\r\n                \"capital\": \"Montgomery\"\r\n            }]\r\n\t}\r\n}");

            string inputValue = "Alabama";
            var response = findByState.FindCityByState(inputValue);

            Assert.IsNotNull(response);
            Assert.AreEqual("Montgomery", response.Capital);
            Assert.AreEqual("Birmingham", response.LargestCity);
        }

        [TestMethod]
        public void FindCityByState_Should_Pass_For_Valid_Input_State_Name_Case_Chaning()
        {
            var mockFindByStateLogic = new Mock<IFindByStateBusinessLogic>();

            mockFindByStateLogic.Setup(f => f.HttpGetResponse()).Returns("{\r\n    \"RestResponse\": {\r\n        \"messages\": [\r\n            \"Total [55] records found.\"\r\n        ],\r\n        \"result\": [\r\n            {\r\n                \"id\": 1,\r\n                \"country\": \"USA\",\r\n                \"name\": \"Alabama\",\r\n                \"abbr\": \"AL\",\r\n                \"area\": \"135767SKM\",\r\n                \"largest_city\": \"Birmingham\",\r\n                \"capital\": \"Montgomery\"\r\n            }]\r\n\t}\r\n}");

            string inputValue = "alaBama";
            var response = findByState.FindCityByState(inputValue);

            Assert.IsNotNull(response);
            Assert.AreEqual("Montgomery", response.Capital);
            Assert.AreEqual("Birmingham", response.LargestCity);
        }

        [TestMethod]
        public void FindCityByState_Should_Fail_For_Invalid_Input_Invalid_State_Name()
        {
            var mockFindByStateLogic = new Mock<IFindByStateBusinessLogic>();

            mockFindByStateLogic.Setup(f => f.HttpGetResponse()).Returns("{\r\n    \"RestResponse\": {\r\n        \"messages\": [\r\n            \"Total [55] records found.\"\r\n        ],\r\n        \"result\": [\r\n            {\r\n                \"id\": 1,\r\n                \"country\": \"USA\",\r\n                \"name\": \"Alabama\",\r\n                \"abbr\": \"AL\",\r\n                \"area\": \"135767SKM\",\r\n                \"largest_city\": \"Birmingham\",\r\n                \"capital\": \"Montgomery\"\r\n            }]\r\n\t}\r\n}");

            string inputValue = "Test";
            var response = findByState.FindCityByState(inputValue);

            Assert.IsNotNull(response);
            Assert.AreEqual("No result found : Invalid input\n", response.ErrorMessage);
        }

        [TestMethod]
        public void FindCityByState_Should_Fail_For_Invalid_Input_No_State_Name()
        {
            var mockFindByStateLogic = new Mock<IFindByStateBusinessLogic>();

            mockFindByStateLogic.Setup(f => f.HttpGetResponse()).Returns("{\r\n    \"RestResponse\": {\r\n        \"messages\": [\r\n            \"Total [55] records found.\"\r\n        ],\r\n        \"result\": [\r\n            {\r\n                \"id\": 1,\r\n                \"country\": \"USA\",\r\n                \"name\": \"Alabama\",\r\n                \"abbr\": \"AL\",\r\n                \"area\": \"135767SKM\",\r\n                \"largest_city\": \"Birmingham\",\r\n                \"capital\": \"Montgomery\"\r\n            }]\r\n\t}\r\n}");

            string inputValue = string.Empty;
            var response = findByState.FindCityByState(inputValue);

            Assert.IsNotNull(response);
            Assert.AreEqual("Please enter state name\n", response.ErrorMessage);
        }
    }
}