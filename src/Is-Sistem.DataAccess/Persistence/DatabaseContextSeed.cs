using Microsoft.AspNetCore.Identity;
using Is_Sistem.Core.Entities;
using Is_Sistem.DataAccess.Repositories;

namespace Is_Sistem.DataAccess.Persistence;

public static class DatabaseContextSeed
{

    public static async Task SeedReservationTableAsync(DatabaseContext context, ITableRepository tableRepository)
    {
        if (!context.Tables.Any())
        {
            var tables = new List<Table>
        {
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Capacity = 4,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Capacity = 4,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 3,
                Capacity = 4,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 4,
                Capacity = 4,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 5,
                Capacity = 6,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 6,
                Capacity = 6,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 7,
                Capacity = 6,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 8,
                Capacity = 8,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 9,
                Capacity = 8,
                IsReserved = false
            },
            new Table
            {
                Id = Guid.NewGuid(),
                Number = 10,
                Capacity = 10,
                IsReserved = false
            }
        };

            foreach (var table in tables)
            {
                await tableRepository.AddAsync(table);
            }

            await context.SaveChangesAsync();
        }
    }
    //public static async Task SeedReservationTableAsync(DatabaseContext context, IReservationRepository reservationRepository)
    //{
    //    if (!context.Reservations.Any())
    //    {
    //        var reservations = new List<Reservation>
    //    {
    //        new Reservation
    //        {
    //            CustomerName = "Müşteri 1",
    //            ReservationDate = DateTime.Now.AddHours(4),
    //            NumberOfGuests = 4,
    //            TableNumber = 1,
    //            //IsReserved = true,
    //            //TableCapacity = 4
    //        },
    //        new Reservation
    //        {
    //            CustomerName = "Müşteri 2",
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 3,
    //            TableNumber = 2,
    //            //IsReserved = true,
    //            //TableCapacity = 4
    //        },
    //        new Reservation
    //        {
    //            CustomerName = "Müşteri 3",
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 3,
    //            //IsReserved = true,
    //            //TableCapacity = 4
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 4,
    //            //IsReserved = false,
    //            //TableCapacity = 4
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 5,
    //            //IsReserved = false,
    //            //TableCapacity = 6
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 6,
    //            //IsReserved = false,
    //            //TableCapacity = 6
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 7,
    //            //IsReserved = false,
    //            //TableCapacity = 6
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 8,
    //            //IsReserved = false,
    //            //TableCapacity = 6
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 9,
    //            //IsReserved = false,
    //            //TableCapacity = 8
    //        },
    //        new Reservation
    //        {
    //            CustomerName = string.Empty,
    //            ReservationDate = DateTime.Now,
    //            NumberOfGuests = 0,
    //            TableNumber = 10,
    //            //IsReserved = false,
    //            //TableCapacity = 8
    //        }
    //    };

    //        foreach (var reservation in reservations)
    //        {
    //            await reservationRepository.AddAsync(reservation);
    //        }

    //        await context.SaveChangesAsync();
    //    }
    //}

}
