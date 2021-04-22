using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using TPAParkingLotAPI.Services;

namespace TWAParkingLotAPI.Controllers
{
	//[Authorize(policy: "ADRoleOnly")]
	[Route("parkinglot/add")]
	[ApiController]
	public class ParkingLotController : ControllerBase
	{
		private readonly IParkingLotRepository _parkingLotRepository;
		//private readonly IMapper _mapper;

		public ParkingLotController(IParkingLotRepository parkingLotRepository)
		//IMapper mapper)
		{
			_parkingLotRepository = parkingLotRepository ?? throw new ArgumentNullException(nameof(parkingLotRepository));
			//_mapper = mapper ??
			//	throw new ArgumentNullException(nameof(mapper));
		}

		[HttpPost]
		public System.Net.Http.HttpResponseMessage AddParkingLot(string twDataJson)
		{

			//your code here
			var result = _parkingLotRepository.Save(twDataJson);
			var response = new HttpResponseMessage(HttpStatusCode.Created)
			{
				Content = new StringContent("Data saved successfully")
			};

			return response;
		}
	}
}
