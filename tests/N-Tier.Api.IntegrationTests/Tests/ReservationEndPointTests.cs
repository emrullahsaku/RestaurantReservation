using FizzWare.NBuilder;
using FluentAssertions;
using Is_Sistem.Api.IntegrationTests.Common;
using Is_Sistem.Api.IntegrationTests.Helpers;
using Is_Sistem.API;
using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Is_Sistem.Api.IntegrationTests.Tests
{
    public class ReservationEndPointTests
    {
        private readonly ApiApplicationFactory<Program> _factory;
        public ReservationEndPointTests()
        {
            _factory = new ApiApplicationFactory<Program>();
        }

        [Fact]
        public async Task Create_Should_Add_Reservation_In_Database()
        {
            // Arrange
            var client = await _factory.CreateDefaultClientAsync();
            var context = _factory.GetRequiredService<DatabaseContext>();

            var reservations = Builder<CreateReservationModel>.CreateNew().
                With(t => t.CustomerName = "Emrullah")
                .With(t => t.NumberOfGuests = 1)
                .With(t => t.ReservationDate = DateTime.Now.AddHours(4)).Build();
            

            // Act
            var apiResponse = await client.PostAsync("/api/reservations", new JsonContent(reservations));

            // Assert
            var response = await ResponseHelper.GetApiResultAsync<CreateReservationResponseModel>(apiResponse); 
            var reservationFromDatabase = await context.Reservations.Where(t => t.Id == response.Result.Id).FirstOrDefaultAsync();  
            CheckResponse.Succeeded(response);
            reservationFromDatabase.Should().NotBeNull();
        }
    }
}
