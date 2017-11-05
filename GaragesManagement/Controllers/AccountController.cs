using GaragesManagement.Database;
using GaragesManagement.Models;
using GaragesManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GaragesManagement.Controllers
{
    public class AccountController : ApiController
    {
        [HttpOptions, HttpPost]
        public ResponseModel Login(string username, string password)
        {
            try
            {
                return DB.Instance.Login(username, password);
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    ResponseCode = Constains.UNKNOW_ERROR_CODE,
                    Message = Constains.UNKNOW_ERROR_MSG
                };
            }
        }
    }
}
