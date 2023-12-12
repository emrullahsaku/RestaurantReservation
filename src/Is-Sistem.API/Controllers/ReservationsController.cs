using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Is_Sistem.Application.Models;
using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.Application.Services;
using Is_Sistem.Application.Models.Table;

namespace Is_Sistem.API.Controllers
{
    [AllowAnonymous]
    public class ReservationsController : ApiController
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService) 
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(ApiResult<IEnumerable<ReservationResponseModel>>.Success(await _reservationService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateReservationModel createReservationModel)
        {
            return Ok(ApiResult<ReservationResponseModel>.Success(
                await _reservationService.MakeReservationAsync(createReservationModel)));
        }
    }
}
