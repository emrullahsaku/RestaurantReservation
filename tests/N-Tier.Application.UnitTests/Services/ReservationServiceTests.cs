using FizzWare.NBuilder;
using FluentAssertions;
using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.Application.Services.Impl;
using Is_Sistem.Core.Entities;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Is_Sistem.Application.UnitTests.Services
{
    public class ReservationServiceTests : BaseServiceTestConfiguration
    {
        private readonly ReservationService _sut;

        public ReservationServiceTests()
        {
            _sut = new ReservationService(ReservationRepository, TableRepository, Mapper, EmailService, TemplateService);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Table_Lists()
        {
            //Arrange
            var tableLists = Builder<Reservation>.CreateListOfSize(10).Build().ToList();

            ReservationRepository.GetAllAsync().Returns(tableLists);

            //Act
            var result = await _sut.GetAllAsync();

            //Assert
            result.Should().HaveCount(10);
            await ReservationRepository.Received().GetAllAsync();
        }

        [Fact]
        public async Task MakeReservationAsync_Should_Add_New_Reservation_To_Database()
        {
            // Arrange
            var createReservationModel = Builder<CreateReservationModel>.CreateNew().Build();
            createReservationModel.ReservationDate = DateTime.Now.AddHours(4);
            var reservation = Mapper.Map<Reservation>(createReservationModel);

            ReservationRepository.AddAsync(Arg.Any<Reservation>()).Returns(reservation);

            // Act
            var result = await _sut.MakeReservationAsync(createReservationModel);

            // Assert
            result.IsReserved.Should().BeTrue();
            await ReservationRepository.Received().AddAsync(Arg.Any<Reservation>());
        }
    }
}
