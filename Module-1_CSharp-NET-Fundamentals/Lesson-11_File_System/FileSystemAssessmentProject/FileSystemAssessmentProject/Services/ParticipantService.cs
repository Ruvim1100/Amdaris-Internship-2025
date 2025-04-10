
using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Logging;
using FileSystemAssessmentProject.Repositories;

namespace FileSystemAssessmentProject.Services
{
    internal class ParticipantService(InMemoryRepository<Participant> participantRepository)
    {
        private readonly Logger<ParticipantService> logger = new();

        public void PrintParticipan(Participant participant)
        {
            ConsoleLogParticipan(participant);
        }

        public void PrintAllParticipans(List<Participant> participants)
        {
            foreach (var participant in participants)
            {
                ConsoleLogParticipan(participant);
            }
        }

        private void ConsoleLogParticipan(Participant participant)
        {
            Console.WriteLine($"Participant: {participant.Name}, Email: {participant.Email}");
        }

        public async Task<List<Participant>> GetAllAsync()
        {
            try
            {
                var result = participantRepository.GetAll().ToList();
                await logger.LogInfoAsync("Participants downloaded successfully");
                return result;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Participants are not downloaded");
                throw;
            }
        }

        public async Task<Participant> GetByIdAsync(Guid id)
        {
            try
            {
                var result = participantRepository.GetById(id);
                await logger.LogInfoAsync("Participant downloaded successfully");
                return result;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Participant didn't download");
                throw;
            }
        }

        public async Task<Participant> AddAsync(Participant participant)
        {
            try
            {
                var result = participantRepository.Add(participant);
                await logger.LogInfoAsync("Course Added Successfully");
                return participant;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Participant cannot be added");
                throw;
            }
        }

        public async Task<Participant> UpdateAsync(Participant participant)
        {
            try
            {
                var result = participantRepository.Update(participant);
                await logger.LogInfoAsync("Participant Udated Successfully");
                return participant;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Participant cannot be updated");
                throw;
            }
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                var result = participantRepository.Delete(id);
                await logger.LogInfoAsync("Participant Deleted Successfully");
                return id;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Participant cannot be deleted");
                throw;
            }
        }
    }
}
