using BusinessLayer.Abstraction;
using BusinessLayer.Models;
using BusinessLayer.Validators;

namespace BusinessLayer.Services
{
    internal class SpeakerService
    {
        private readonly SessionApprover _sessionApprover;
        private readonly SpeakerValidator _validator;
        private readonly IRepository _inMemoryRepository;
        private readonly ICalculator _registrationCalculator;

        public SpeakerService(SessionApprover sessionApprover, 
            SpeakerValidator validator, 
            IRepository inMemoryRepository, 
            ICalculator registrationCalculator)
        {
            _sessionApprover = sessionApprover;
            _validator = validator;
            _inMemoryRepository = inMemoryRepository;
            _registrationCalculator = registrationCalculator;
        }

        public int RegisterSpeaker(Speaker speaker)
        {
            _sessionApprover.ApproveSession(speaker.Sessions);
            _validator.Validate(speaker);
            speaker.RegistrationFee = _registrationCalculator.Calculate(speaker.Experience);
            return _inMemoryRepository.SaveSpeaker(speaker);
        }
    }
}
