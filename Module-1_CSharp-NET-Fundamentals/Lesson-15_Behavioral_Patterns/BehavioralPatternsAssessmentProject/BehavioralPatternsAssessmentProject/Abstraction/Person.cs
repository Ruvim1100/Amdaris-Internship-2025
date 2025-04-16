using BehavioralPatternsAssessmentProject.Models;

namespace BehavioralPatternsAssessmentProject.Abstraction
{
    internal abstract class Person
    {
        public string Name { get; }
        public IReadOnlyList<ContactChannel> ContactChannels => contactChannels;
        private readonly List<ContactChannel> contactChannels = [];

        protected Person(string name, string? email, string? phoneNumber)
        {
            Name = name;

            if (!string.IsNullOrWhiteSpace(email))
                contactChannels.Add(new() { ChannelType = ChannelType.Email, Identifier = email });

            if (!string.IsNullOrWhiteSpace(phoneNumber))
                contactChannels.Add(new() { ChannelType = ChannelType.Sms, Identifier = phoneNumber });
        }
    }
}
