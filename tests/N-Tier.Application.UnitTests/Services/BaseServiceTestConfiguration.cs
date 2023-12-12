using AutoMapper;
using Is_Sistem.Application.MappingProfiles;
using Is_Sistem.Application.Services;
using Is_Sistem.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace Is_Sistem.Application.UnitTests.Services;

public class BaseServiceTestConfiguration
{
    protected readonly IReservationRepository ReservationRepository;
    protected readonly ITableRepository TableRepository;
    protected readonly IEmailService EmailService;
    protected readonly ITemplateService TemplateService;
    protected readonly IConfiguration Configuration;
    protected readonly IMapper Mapper;

    protected BaseServiceTestConfiguration()
    {
        Mapper = new MapperConfiguration(cfg => { cfg.AddMaps(typeof(ReservationProfile)); }).CreateMapper();


        Configuration = new ConfigurationBuilder()
            .AddInMemoryCollection()
            .Build();

        ReservationRepository = Substitute.For<IReservationRepository>();
        EmailService = Substitute.For<IEmailService>();
        TemplateService = Substitute.For<ITemplateService>();
    }
}
