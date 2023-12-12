using Is_Sistem.Core.Entities;
using Is_Sistem.DataAccess.Persistence;

namespace Is_Sistem.DataAccess.Repositories.Impl
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(DatabaseContext context) : base(context) { }
    }
}
