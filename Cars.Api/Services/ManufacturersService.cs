using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Api.Infrastructure;
using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Api.Services
{
    public interface IManufacturersService
    {
        Task<IEnumerable<Manufacturer>> GetAll();
        Task<Manufacturer> GetById(int id);
        Task<int> Save(Manufacturer manufacturer);
    }

    public class ManufacturersService : IManufacturersService
    {
        private readonly DatabaseContext _db;

        public ManufacturersService(DatabaseContext db) => _db = db;

        public async Task<IEnumerable<Manufacturer>> GetAll() =>
            await _db.Manufacturers
                .OrderBy(m => m.Name)
                .Include(m => m.Cars)
                .ToListAsync();

        public async Task<Manufacturer> GetById(int id) =>
            await _db.Manufacturers
                .Where(m => m.Id == id)
                .Include(m => m.Cars)
                .FirstOrDefaultAsync();

        public async Task<int> Save(Manufacturer manufacturer)
        {
            await _db.Manufacturers.AddAsync(manufacturer);
            return await _db.SaveChangesAsync();
        }
    }
}