using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc; //Contiene controllerBase
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] //Da API behavior
    [Route("api/[controller]")] //La ruta PREVIA a los endpoints.
    public class ProductsController : ControllerBase //Needs to inherit de esta clase
    {
        private readonly StoreContext _context;  //? Trae un StoreContext


        //? The constructor for the class; instantly run on when an object of the class is created. As long as tenga el mismo nombre que la clase.
        public ProductsController(StoreContext context)   //! control+. en context e initialize field from parameter
       
        {
             _context = context;  //? Inicializa una nueva instancia de ese StoreContext
        }



        [HttpGet] //url seria /api/products
        public async Task<ActionResult<List<Product>>> GetProducts() {  //Es una async, la Task engloba todo el endpoint, para permitir threading.
             //Task pasa la tarea a un delegate, y por ende no blockea el thread
            var products = await _context.Products.ToListAsync(); //? Saca la lista de productos de la instancia de StoreContext _context

            return Ok(products);
        }


        [HttpGet("{id}")] //Accepts an id, and if the url has an ID, the server will send this endpoint content
        public async Task<ActionResult<Product>> GetProduct(int id) { //url seria también /api/products . Lo que va a permitir diferneciarlos es la presencia de id en la url query
            
            return await _context.Products.FindAsync(id);

        }

    }
}