using Application.Abstractions;
using Application.Emails;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;
using System.Text;

namespace Application.Services
{
    public class TrainingRecordService : ITrainingRecordService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;

        public TrainingRecordService(IMapper mapper, IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.emailSender = emailSender;
        }

        public Task<TrainingRecordViewModel> Add(TrainingRecordModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            var trainingMarks = await unitOfWork.TrainingMarkRepository.GetAsync(x => IDs.Contains(x.TrainingRecordId));
            var trainingRecords = await unitOfWork.TrainingRecordRepository.GetAsync(x => IDs.Contains(x.Id));

            unitOfWork.TrainingMarkRepository.RemoveRange(trainingMarks);
            unitOfWork.TrainingRecordRepository.RemoveRange(trainingRecords);

            await unitOfWork.SaveAsync();
        }

        public async Task<TrainingRecordViewModel> Edit(Guid id, TrainingRecordModel model)
        {
            var trainingRecord = await unitOfWork.TrainingRecordRepository.GetByIdAsync(id);

            if (trainingRecord != null)
            {
                if (model.Note is not null && trainingRecord.Note != model.Note)
                {
                    trainingRecord.Note = model.Note;
                }
                if (model.IsPresent.HasValue && trainingRecord.IsPresent != model.IsPresent)
                {
                    trainingRecord.IsPresent = model.IsPresent.Value;
                }

                unitOfWork.TrainingRecordRepository.Update(trainingRecord);
                await unitOfWork.SaveAsync();
            }

            return mapper.Map<TrainingRecordViewModel>(trainingRecord);
        }

        public async Task<TrainingRecordViewModel> Get(Guid id)
        {
            var trainingRecord = await unitOfWork.TrainingRecordRepository.GetByIdAsync(id);

            return mapper.Map<TrainingRecordViewModel>(trainingRecord);
        }

        public Task<IReadOnlyCollection<TrainingRecordViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task SendRecordByEmail(Guid recordId)
        {
            var training = await unitOfWork.TrainingRepository.GetSingleAsync(x => x.TrainingRecords.Select(x => x.Id).Contains(recordId));

            if (training is not null)
            {
                var trainingRecord = await unitOfWork.TrainingRecordRepository.GetByIdAsync(recordId);
                trainingRecord.Training = training;

                var subject = $"{trainingRecord.Training.Name} - {trainingRecord.Training.StartDate.ToString("yyyy-MM-dd")}";
                var content = new StringBuilder("<h1>Training Details</h1>");
                content.Append($"<p><strong>Note:</strong> {trainingRecord.Note}</p>");
                content.Append("<ul>");
                foreach (var mark in trainingRecord.TrainingMarks)
                {
                    content.Append($"<li>{mark.Criterion.Name} - {mark.Mark}</li>");
                }
                content.Append("</ul>");
                var message = new Message(
                new List<string> { trainingRecord.Player.Email },
                    subject,
                    content.ToString()
                );

                await emailSender.SendEmailAsync(message);
            }
        }
    }
}
