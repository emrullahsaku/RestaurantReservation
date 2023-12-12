namespace Is_Sistem.Application.Models.Reservation
{
    public class CreateReservationModel
    {
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfGuests { get; set; }

        public int TableNumber { get; set; }
    }
    public class CreateReservationResponseModel : BaseResponseModel { }
}
