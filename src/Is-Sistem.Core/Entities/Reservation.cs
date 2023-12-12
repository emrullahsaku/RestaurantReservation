using Is_Sistem.Core.Common;

namespace Is_Sistem.Core.Entities
{
    public class Reservation : BaseEntity, IAuditedEntity
    {
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfGuests { get; set; }

        public int TableNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual Table Table { get; set; }
    }
}
