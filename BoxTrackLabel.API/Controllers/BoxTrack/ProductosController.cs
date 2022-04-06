
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxTrackLabel.API.Models;
using BoxTrackLabel.API.Repositories;
using BoxTrackLabel.API.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoxTrackLabel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductosController : ControllerBase
    {
        private readonly BoxTrackDbContext _context;
        private readonly ProductosRepository _repository;        

        public ProductosController(ProductosRepository repository) 
        {
           _repository = repository;            
        }


        [Route("getallproductos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetAllProductos()
        {

            return await _context.Productos.ToListAsync();
        
        }

        [Route("getall")]
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }     

    }
}