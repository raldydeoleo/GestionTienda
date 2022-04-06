using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BoxTrackLabel.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxTrackLabel.API.Repositories
{
    public class ProductosRepository : EfCoreRepository<Module, BoxTrackDbContext>
    {
        private readonly BoxTrackDbContext _context;
        public ProductosRepository(BoxTrackDbContext context) : base(context)
        {
             _context = context;
        }

        /// <summary>
        /// Obtiene el listado 
        /// </summary>
        public new async Task<List<Productos>> GetAll()
        {
            return await _context.Productos.Include(p=>p.suplidores).ToListAsync();
        }
    }
}