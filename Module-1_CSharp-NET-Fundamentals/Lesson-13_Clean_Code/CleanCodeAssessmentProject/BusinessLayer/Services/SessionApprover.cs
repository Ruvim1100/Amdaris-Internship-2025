using BusinessLayer.Constant;
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    internal class SessionApprover
    {
        public void ApproveSession(List<Session> sessions)
        {
            if (sessions == null || sessions.Count == 0)
                throw new ArgumentException("Speaker must have at least one session.");

            foreach (var session in sessions)
            {
                session.Approved = !Constants.OldTechnologies.Any(technology => 
                session.Title.Contains(technology) || session.Description.Contains(technology));
            }
        }
    }
}
