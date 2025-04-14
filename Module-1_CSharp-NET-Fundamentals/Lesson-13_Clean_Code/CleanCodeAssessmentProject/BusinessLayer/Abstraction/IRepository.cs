using BusinessLayer.Models;

namespace BusinessLayer.Abstraction
{
    internal interface IRepository
    {
        int SaveSpeaker(Speaker speaker);
    }
}
