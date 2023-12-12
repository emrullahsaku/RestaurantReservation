using Is_Sistem.Core.Common;

namespace Is_Sistem.Core.Entities
{
    public class Table : BaseEntity, IAuditedEntity
    {
        public int Number { get; set; }

        public int Capacity { get; set; }

        public bool IsReserved { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
