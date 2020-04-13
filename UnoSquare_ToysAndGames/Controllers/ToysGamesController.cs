using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnoSquare_ToysAndGames.Repositories;
using UnoSquare_ToysAndGames.Models;

namespace UnoSquare_ToysAndGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysGamesController : ControllerBase
    {
        private IRepository<Product> ProductRepository;

        public ToysGamesController(IRepository<Product> ProductRepository)
        { this.ProductRepository = ProductRepository; }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts() => ProductRepository.GetAll();

        [HttpGet("{id}", Name = "Get")]
        public Product GetProductById(int id) => ProductRepository.GetById(id); 
        [HttpPost]
        public void AddProduct([FromBody] Product product) => ProductRepository.Insert(product);

        [HttpPut]
        public void UpdateProduct([FromBody] Product product) => ProductRepository.Update(product);

        [HttpDelete("{id}")]
        public void DeleteProduct(int id) => ProductRepository.Delete(id);
       
    }
}
