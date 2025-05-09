﻿using BusinessLayer.Constant;
using BusinessLayer.Exceptions;
using BusinessLayer.Models;

namespace BusinessLayer.Validators
{
    internal class SpeakerValidator
    {
        public void Validate(Speaker speaker)
        {
            ValidateFields(speaker);
            ValidateProfessionalCriteria(speaker);
            ValidateEmail(speaker);
        }

        private void ValidateFields(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.FirstName))
            {
                throw new ArgumentNullException("First Name is required");
            }

            if (string.IsNullOrWhiteSpace(speaker.LastName))
            {
                throw new ArgumentNullException("Last Name is required");
            }

            if (string.IsNullOrWhiteSpace(speaker.Email))
            {
                throw new ArgumentNullException("Email is required");
            }

            if (!speaker.Sessions.Any(session => session.Approved))
            {
                throw new NoSessionsApprovedException("Can't register speaker with no sessions to present.");
            }
        }

        private void ValidateProfessionalCriteria(Speaker speaker)
        {
            if (!(speaker.Experience > 10
                && speaker.HasBlog
                && speaker.Certifications.Count > 2
                && Constants.Employers.Contains(speaker.Employer)))
            {
                throw new SpeakerDoesntMeetRequirementsException(
                     "Speaker doesn't meet our arbitrary and capricious standards.");
            }
        }

        private void ValidateEmail(Speaker speaker)
        {
            string emailDomain = speaker.Email.Split('@').Last();

            bool oldBrowser = speaker.Browser.Name == WebBrowser.BrowserName.InternetExplorer 
                && speaker.Browser.MajorVersion < 9;

            bool isWrongDomain = Constants.WrongDomains.Contains(emailDomain);

            if (isWrongDomain || oldBrowser)
            {
                throw new SpeakerDoesntMeetRequirementsException(
                    "Speaker doesn't meet our arbitrary and capricious standards.");
            } 

        }

    }
}
