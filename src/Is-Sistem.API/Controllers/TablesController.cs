using Is_Sistem.Application.Models.Table;
using Is_Sistem.Application.Models;
using Is_Sistem.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Is_Sistem.API.Controllers
{
    [AllowAnonymous]
    public class TablesController : ApiController
    {
        private readonly IReservationService _reservationService;
        public TablesController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetTablesByReservedStatuAsync(bool isReserved)
        {
            return Ok(ApiResult<IEnumerable<TableResponseModel>>.Success(await _reservationService.GetTablesByReservedStatusAsync(isReserved)));
        }
    }
}
