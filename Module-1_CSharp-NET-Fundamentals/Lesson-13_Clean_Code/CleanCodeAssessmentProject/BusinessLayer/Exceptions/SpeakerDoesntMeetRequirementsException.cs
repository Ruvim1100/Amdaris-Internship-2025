using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    internal class SpeakerDoesntMeetRequirementsException : Exception
    {
        public SpeakerDoesntMeetRequirementsException() : base() { }
        public SpeakerDoesntMeetRequirementsException(string message) 
            : base(message) {}

        public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
            : base(string.Format(format, args)) { }
    }
}
