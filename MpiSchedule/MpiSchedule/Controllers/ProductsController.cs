using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MpiSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private static readonly List<Product> products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 999.99 },
        new Product { Id = 2, Name = "Mouse", Price = 19.99 },
        new Product { Id = 2, Name = "Keyboard", Price = 29.99 },
    ];

    [HttpGet]
    public IActionResult GetAll() => Ok(products);

    private class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Price { get; set; }
    }
}
