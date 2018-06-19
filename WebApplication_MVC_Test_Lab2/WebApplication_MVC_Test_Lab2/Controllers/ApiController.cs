using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_MVC_Test_Lab2.Controllers;
using WebApplication_MVC_Test_Lab2.Data;
using WebApplication_MVC_Test_Lab2.Models;

namespace WebApplication_MVC_Test_Lab2.Controllers
{
    [Produces("application/json")]
    [Route("api/Api")]
    public class ApiController : Controller
    {
        private readonly IApiRequestSend<StorageSort> apiRequestSend;

        public ApiController(IApiRequestSend<StorageSort> apiRequestSend)
        {
            this.apiRequestSend = apiRequestSend;
        }

        public void AddStorageSort(StorageSort item)
        {
            apiRequestSend.AddEntity(item);
        }

        public void EditStorageSort(int item_id, StorageSort item)
        {
            apiRequestSend.ModifyEntity(item_id, item);
        }

        public void DeleteStorageSort(StorageSort item)
        {
            apiRequestSend.DeleteEntity(item);
        }

        public void GetAll() => apiRequestSend.GetAllData();
    }
}