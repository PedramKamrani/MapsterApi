using MapsterApi.Entites;
using Microsoft.AspNetCore.Mvc;

namespace MapsterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context; /// <summary>
        /// repository
        /// </summary>
        /// <param name="context"></param>

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto dto)
        {
            Product product = dto.ToEntity();

            _context.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }


        [HttpGet]
        public async Task<IActionResult> Get(int productId)
        {
            ProductDto productDto = await _context
                .Products
                .Where(p => p.Id == productId)
                .ProjectToType<ProductDto>()
                .FirstOrDefaultAsync();

            return Ok(productDto);
        }


        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context
                .Products
                .ProjectToType<ProductDto>()
                .ToListAsync();

            return Ok(result);
        }
    }
}