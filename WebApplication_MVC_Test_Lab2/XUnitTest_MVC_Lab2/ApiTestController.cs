using System;
using Xunit;
using Moq;
using WebApplication_MVC_Test_Lab2;
using WebApplication_MVC_Test_Lab2.Controllers;
using WebApplication_MVC_Test_Lab2.Data;
using WebApplication_MVC_Test_Lab2.Models;
using System.Collections.Generic;

namespace XUnitTest_MVC_Lab2
{
    public class ApiControllerTest
    {
        [Fact] // GetAllData_CallsGetAllDataOnce
        public void Data_TryGetAllData()
        {
            var MockRequest = new Mock<IApiRequestSend<StorageSort>>();
            var itemController = new ApiController(MockRequest.Object);

            itemController.GetAll();

            MockRequest.Verify(m => m.GetAllData(), Times.Once());
        }

        private StorageSort ItemUsedForTesting()
        {
            return new StorageSort()
            {
                Id = 555,
                NameOfItem = "Bag of luck",
                Price = 10,
                Quantity = 1000,
                Section = "Unclear"
            };
        }

        [Fact] // AddStorageSort_CallsAddEntityOnce
        public void Item_TryAddItem()
        {
            var item = ItemUsedForTesting();
            var MockRequest = new Mock<IApiRequestSend<StorageSort>>();
            var itemController = new ApiController(MockRequest.Object);

            itemController.AddStorageSort(item);
            MockRequest.Verify(m => m.AddEntity(item), Times.Once);
        }

        [Fact]
        public void Item_TryModifyItem()
        {
            var item = ItemUsedForTesting();
            var MockRequest = new Mock<IApiRequestSend<StorageSort>>();
            var itemController = new ApiController(MockRequest.Object);

            itemController.EditStorageSort(item.Id, item);
            MockRequest.Verify(m => m.ModifyEntity(item.Id, item), Times.Once);
        }

        [Fact]
        public void Item_TryDeleteItem()
        {
            var item = ItemUsedForTesting();
            var MockRequest = new Mock<IApiRequestSend<StorageSort>>();
            var itemController = new ApiController(MockRequest.Object);

            itemController.DeleteStorageSort(item);
            MockRequest.Verify(m => m.DeleteEntity(item), Times.Once);
        }
    }
}
