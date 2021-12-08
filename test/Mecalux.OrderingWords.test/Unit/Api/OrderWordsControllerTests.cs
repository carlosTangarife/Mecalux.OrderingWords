﻿using Mecalux.OrderingWords.Api.Controllers;
using Mecalux.OrderingWords.Application.Contracts.Repository;
using Mecalux.OrderingWords.Application.Contracts.Service;
using Mecalux.OrderingWords.Applications.Enums;
using Mecalux.OrderingWords.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Mecalux.OrderingWords.Test.Unit.Api
{
    [TestClass]
    public class OrderWordsControllerTests
    {
        private Mock<ILogger<OrderWordsController>> _mockLogger;
        private Mock<IOrderOptionsRepository> _mockOrderOptionsRepository;
        private Mock<IOrderWordsService> _mockOrderWordsService;
        private OrderWordsController _orderWordsController;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<OrderWordsController>>();
            _mockOrderOptionsRepository = new Mock<IOrderOptionsRepository>();
            _mockOrderWordsService = new Mock<IOrderWordsService>();
            _orderWordsController = new OrderWordsController(_mockLogger.Object, _mockOrderOptionsRepository.Object, _mockOrderWordsService.Object);
        }

        #region GetOrderOptions
        [TestMethod]
        public void When_GetOrderOptions_Expected_ThreeOptions()
        {
            // Arrange
            var elementsExpected = 3;
            var orderOptionsMock = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>(OrderOptions.AlphabeticAsc.ToString(), (int)OrderOptions.AlphabeticAsc),
                new KeyValuePair<string, int>(OrderOptions.AlphabeticDesc.ToString(), (int)OrderOptions.AlphabeticDesc),
                new KeyValuePair<string, int>(OrderOptions.LengthAsc.ToString(), (int)OrderOptions.LengthAsc)
            };

            _mockOrderOptionsRepository.Setup(x => x.GetOrderOptions()).Returns(orderOptionsMock).Verifiable();

            // Act
            var result = _orderWordsController.GetOrderOptions();

            // Assert
            var ok = result as OkObjectResult;
            Assert.IsNotNull(ok);

            var orderOptions = ok.Value as List<KeyValuePair<string, int>>;
            Assert.IsNotNull(orderOptions);

            Assert.AreEqual(elementsExpected, orderOptions.Count);
            Assert.IsTrue(orderOptions.Contains(new KeyValuePair<string, int>(OrderOptions.AlphabeticAsc.ToString(), (int)OrderOptions.AlphabeticAsc)));
            Assert.IsTrue(orderOptions.Contains(new KeyValuePair<string, int>(OrderOptions.AlphabeticDesc.ToString(), (int)OrderOptions.AlphabeticDesc)));
            Assert.IsTrue(orderOptions.Contains(new KeyValuePair<string, int>(OrderOptions.LengthAsc.ToString(), (int)OrderOptions.LengthAsc)));

            _mockOrderOptionsRepository.Verify(x => x.GetOrderOptions(), Times.Once);
        }
        #endregion GetOrderOptions


        #region GetStatic
        [TestMethod]
        public void Given_TextToAnalizeEmpty_When_GetStatic_Expected_TextStatisticsDefault()
        {
            // Arrange
            string textToAnalize = string.Empty;
            _mockOrderWordsService.Setup(x => x.GetStatic(textToAnalize)).Returns(new TextStatistics { }).Verifiable();

            // Act
            var result = _orderWordsController.GetStatic(textToAnalize);

            // Assert
            var ok = result as OkObjectResult;
            Assert.IsNotNull(ok);

            var textStatistics = ok.Value as TextStatistics;
            Assert.IsNotNull(textStatistics);
            Assert.AreEqual(0, textStatistics.HyphensQuantity);
            Assert.AreEqual(0, textStatistics.SpacesQuantity);
            Assert.AreEqual(0, textStatistics.WordQuantity);
            _mockOrderWordsService.Verify(x => x.GetStatic(textToAnalize), Times.Never);
        }

        [TestMethod]
        public void Given_TextToAnalize_When_GetStatic_Expected_TextStatistics()
        {
            // Arrange
            string textToAnalize = "Mecalux sistemas de almacenamiento flexibles";

            TextStatistics textStatisticsMock = new()
            {
                HyphensQuantity = 0,
                SpacesQuantity = 4,
                WordQuantity = 5
            };

            _mockOrderWordsService.Setup(x => x.GetStatic(textToAnalize)).Returns(textStatisticsMock).Verifiable();

            // Act
            var result = _orderWordsController.GetStatic(textToAnalize);

            // Assert
            var ok = result as OkObjectResult;
            Assert.IsNotNull(ok);

            var textStatistics = ok.Value as TextStatistics;
            Assert.IsNotNull(textStatistics);
            Assert.AreEqual(0, textStatistics.HyphensQuantity);
            Assert.AreEqual(4, textStatistics.SpacesQuantity);
            Assert.AreEqual(5, textStatistics.WordQuantity);
            _mockOrderWordsService.Verify(x => x.GetStatic(textToAnalize), Times.Once);
        }

        [TestMethod]
        public void Given_TextToAnalize_When_GetStatic_Expected_TextStatisticsWithHyphensQuantity()
        {
            // Arrange
            string textToAnalize = "Mecalux-sistemas de almacenamiento-flexibles";

            TextStatistics textStatisticsMock = new()
            {
                HyphensQuantity = 2,
                SpacesQuantity = 2,
                WordQuantity = 3
            };

            _mockOrderWordsService.Setup(x => x.GetStatic(textToAnalize)).Returns(textStatisticsMock).Verifiable();

            // Act
            var result = _orderWordsController.GetStatic(textToAnalize);

            // Assert
            var ok = result as OkObjectResult;
            Assert.IsNotNull(ok);

            var textStatistics = ok.Value as TextStatistics;
            Assert.IsNotNull(textStatistics);
            Assert.AreEqual(2, textStatistics.HyphensQuantity);
            Assert.AreEqual(2, textStatistics.SpacesQuantity);
            Assert.AreEqual(3, textStatistics.WordQuantity);
            _mockOrderWordsService.Verify(x => x.GetStatic(textToAnalize), Times.Once);
        }
        #endregion GetStatic
    }
}
