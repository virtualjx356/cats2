using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPAParkingLotAPI.DbContexts;

namespace TPAParkingLotAPI.Services
{
	public class ParkingLotRepository : IParkingLotRepository, IDisposable
	{
		private readonly ParkingLotDbContext _context;
		public ParkingLotRepository(ParkingLotDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		


		public bool Save(string twParkingLotJson)
		{
			return true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose resources when needed
			}
		}
	}
}
