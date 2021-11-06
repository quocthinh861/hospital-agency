using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Data;

namespace backend.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public ManagerController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpPost]
        [Route("supplier")]
        public ActionResult<SupplierResponse> PurchasingResponse(SupplierResponse supplier)
        {
            try
            {
                var result = _dataRepository.PostSupplier(supplier);
                if (result)
                {
                    return supplier;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("supplier")]
        public ActionResult<PurchasingSingleResponse> PurchasingResponse(string id)
        {
            var purchase = _dataRepository.GetSinglePurchasing(id);
            try
            {
                if (purchase != null)
                {
                    return purchase;
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<ManagerSingleResponse> Login(LoginRequest data)
        {
            var manager = _dataRepository.GetSingleManager(data.username, data.password);
            try
            {
                if (manager != null)
                {
                    return manager;
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
