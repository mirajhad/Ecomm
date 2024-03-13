using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecomm.Data;
using Ecomm.Models;
using Ecomm.Infrastructor;
using Microsoft.AspNetCore.Authorization;

namespace Ecomm.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _Product;

        public ProductsController(
            IProduct product)
        {
            
            _Product = product;
        }

        // GET: api/Products
        [HttpGet]
        public IQueryable<Product> GetProducts(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = (IQueryable<Product>)_Product.GetAll().
                        OrderByDescending(x=>x.Price);
                    break;
                case "asc":
                    products = (IQueryable<Product>)_Product.GetAll().
                        OrderBy(x => x.Price);
                    break;

                default:
                    products = (IQueryable<Product>)_Product.GetAll();
                    break;
            }
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product =  _Product.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var productbyId =  _Product.GetProductById(id);
            _Product.update(productbyId);

           

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            _Product.Insert(product);
           
            

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _Product.GetProductById(id);
           _Product.Delete(product);
            return Ok();
        }

        
    }
}
