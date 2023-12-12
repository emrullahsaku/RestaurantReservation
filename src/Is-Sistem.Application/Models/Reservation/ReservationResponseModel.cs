namespace Is_Sistem.Application.Models.Reservation
{
    public class ReservationResponseModel : BaseResponseModel
    {
        public string CustomerName { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfGuests { get; set; }

        public int TableNumber { get; set; }

        public bool IsReserved { get; set; }
    }
}
