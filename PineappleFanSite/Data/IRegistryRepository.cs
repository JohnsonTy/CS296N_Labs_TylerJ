using PineappleFanSite.Models;
using Microsoft.EntityFrameworkCore;
namespace PineappleFanSite.Data
{
    public interface IRegistryRepository
    {
        public List<Stories> GetStories();
        public Stories GetStoryById(int Id);
        public int StoreStories(Stories story);
        public int StoreMessage(Messages message);
    }
}