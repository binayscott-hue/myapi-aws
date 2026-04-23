using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase {
    private readonly AppDbContext _db;
    public ProductsController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _db.Products.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Product p) {
        _db.Products.Add(p);
        await _db.SaveChangesAsync();
        return Ok(p);
    }
}
