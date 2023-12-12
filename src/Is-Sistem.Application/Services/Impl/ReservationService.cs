using AutoMapper;
using Is_Sistem.Application.Common.Email;
using Is_Sistem.Application.Exceptions;
using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.Application.Models.Table;
using Is_Sistem.Application.Templates;
using Is_Sistem.Core.Entities;
using Is_Sistem.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Is_Sistem.Application.Services.Impl
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ITemplateService _templateService;
        public ReservationService(IReservationRepository reservationRepository, ITableRepository tableRepository, IMapper mapper, IEmailService emailService, ITemplateService templateService)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
            _emailService = emailService;
            _templateService = templateService;
        }

        public async Task<IEnumerable<ReservationResponseModel>> GetAllAsync()
        {

            var reservations = await _reservationRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ReservationResponseModel>>(reservations);
        }

        public async Task<IEnumerable<TableResponseModel>> GetTablesByReservedStatusAsync(bool isReserved)
        {

            var tables = await _tableRepository.GetAllAsync(r => r.IsReserved == isReserved);

            return _mapper.Map<IEnumerable<TableResponseModel>>(tables);
        }

        public async Task<ReservationResponseModel> MakeReservationAsync(CreateReservationModel createReservationModel)
        {
            if (createReservationModel.ReservationDate < DateTime.Now)
            {
                // Geçersiz rezervasyon tarihi
                throw new BadRequestException("Geçersiz rezervasyon tarihi. Lütfen gelecekte bir tarih seçin.");
            }

            var availableTables = await _tableRepository.GetAllAsync(r => r.IsReserved == false);

            if (availableTables == null || !availableTables.Any())
            {
                // Uygun masa bulunamadı
                throw new NotFoundException("Üzgünüz, şu an için uygun masa bulunmamaktadır.");
            }

            // Uygun bir masa bulunduğunda devam edilir
            var reservation = _mapper.Map<Reservation>(createReservationModel);

            // İstenen misafir sayısına uygun bir masa bulma
            var suitableTable = availableTables.FirstOrDefault(t => t.Capacity >= reservation.NumberOfGuests);

            if (suitableTable == null)
            {
                // Uygun kapasitede masa bulunamadı
                throw new NotFoundException("Üzgünüz, istediğiniz misafir sayısına uygun bir masa bulunamadı.");
            }

            //_ = await _reservationRepository.DeleteAsync(suitableTable);
            suitableTable.IsReserved = true;
            _ = await _tableRepository.UpdateAsync(suitableTable);

            reservation.Id = Guid.NewGuid();
            reservation.TableNumber = suitableTable.Number;

            var addedReservation = await _reservationRepository.AddAsync(reservation);
            var emailTemplate = await _templateService.GetTemplateAsync(TemplateConstants.ConfirmationEmail);

            var emailBody = $"Sayın {reservation.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {reservation.TableNumber}, Tarih: {reservation.ReservationDate}, Kişi Sayısı: {reservation.NumberOfGuests}";

            await _emailService.SendEmailAsync(EmailMessage.Create(reservation.CustomerEmail, emailBody, "Rezervasyon Doğrulama"));
            return _mapper.Map<ReservationResponseModel>(addedReservation);
        }

    }
}
