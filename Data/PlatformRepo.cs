using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat is null) throw new ArgumentNullException(nameof(plat));

            _context.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
             return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            var platformItems = _context.Platforms.ToList();
            
            return platformItems.FirstOrDefault(p=>p.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}