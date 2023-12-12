using Is_Sistem.Core.Entities;
using Is_Sistem.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_Sistem.DataAccess.Repositories.Impl
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DatabaseContext context) : base(context) { }
    }
}
