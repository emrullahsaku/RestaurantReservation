using AutoMapper;
using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.Application.Models.Table;
using Is_Sistem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_Sistem.Application.MappingProfiles
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableResponseModel>();
        }
    }
}
