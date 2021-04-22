using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAParkingLotAPI.DbContexts
{
	public class ParkingLotDbContext : DbContext
	{
        public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options)
           : base(options)
        {
        }

        
    }
}
