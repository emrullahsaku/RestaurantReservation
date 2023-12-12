using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.Application.Models.Table;

namespace Is_Sistem.Application.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationResponseModel>> GetAllAsync();
        Task<IEnumerable<TableResponseModel>> GetTablesByReservedStatusAsync(bool isReserved);
        Task<ReservationResponseModel> MakeReservationAsync(CreateReservationModel createReservationModel);
    }
}
