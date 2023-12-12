namespace Is_Sistem.Application.Models.Table
{
    public class TableResponseModel : BaseResponseModel
    {
        public int Number { get; set; }

        public int Capacity { get; set; }

        public bool IsReserved { get; set; }
    }
}
