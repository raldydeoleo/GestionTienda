
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


        [HttpPost]
        [Authorize(Permissions.Menus.Programacion)]
        public async Task<ActionResult<Productos>> CreateProductos(Productos productos)
        {
            try
            {
                Productos result = null;
                result = await _repository.CreateProducto(productos);
                return Created("api/registrar", result);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

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

        [Route("getproducto/{id}")]
        [HttpGet]       
        public async Task<ActionResult<Productos>> GetProducto(int id)
        {
            try
            {
                Productos result = null;
                result = await  _repository.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(Productos productos)
        {
            
            try
            {
                await _repository.UpdateProducto(productos);
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return NoContent();
        }

        [HttpPut]
        [Route("delete")]
        public async Task<ActionResult<Productos>> Delete(Productos productos)
        {
            try
            {
                //entity.EstaBorrado = true;
                //entity.FechaHoraBorrado = DateTime.Now;
                await _repository.Delete(productos);
                return productos;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

    }
}