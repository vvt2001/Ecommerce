using EcommerceAPI.Services;
using EcommerceData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet("get")]
        public ActionResult Get(int id)
        {
            var product = _productServices.Get(id);
            return Ok(product);
        }
        [HttpPost("create")]
        public ActionResult Create([FromBody] Product product)
        {
            var new_product = _productServices.Create(product);
            return Ok(new_product);
        }
        [HttpDelete("delete")]
        public ActionResult Delete(int id)
        {
            _productServices.Delete(id);
            return Ok();
        }
        [HttpPut("edit")]
        public ActionResult Edit([FromBody] Product product)
        {
            var edit_product = _productServices.Edit(product);
            return Ok(edit_product);
        }
        [HttpGet("search")]
        public ActionResult Search([FromBody] ProductSearching productSearching)
        {
            var searchResult = _productServices.Search(productSearching);
            return Ok(searchResult);
        }
       
    }
}
