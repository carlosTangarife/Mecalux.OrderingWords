using Mecalux.OrderingWords.Api.Controllers;
using Mecalux.OrderingWords.Application.Contracts.Repository;
using Mecalux.OrderingWords.Applications.Enums;
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
        private OrderWordsController _orderWordsController;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<OrderWordsController>>();
            _mockOrderOptionsRepository = new Mock<IOrderOptionsRepository>();
            _orderWordsController = new OrderWordsController(_mockLogger.Object, _mockOrderOptionsRepository.Object);
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
    }
}
