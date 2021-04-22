using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAParkingLotAPI.Services
{
    public interface IParkingLotRepository
    {
        

		bool Save(string twParkingLotJson);
    }
}
