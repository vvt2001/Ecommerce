using EcommerceAPI.Services;
using EcommerceData.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        [HttpGet("get")]
        public ActionResult Get(int id)
        {
            var account = _accountServices.Get(id);
            return Ok(account);
        }
        [HttpPost("create")]
        public ActionResult Create([FromBody] Account account)
        {
            var new_account = _accountServices.Create(account);
            return Ok(new_account);
        }
        [HttpDelete("delete")]
        public ActionResult Delete(int id)
        {
            _accountServices.Delete(id);
            return Ok();
        }
        [HttpPut("edit")]
        public ActionResult Edit(int id, string password)
        {
            var edit_account = _accountServices.Edit(id, password);
            return Ok(edit_account);
        }
    }
}
