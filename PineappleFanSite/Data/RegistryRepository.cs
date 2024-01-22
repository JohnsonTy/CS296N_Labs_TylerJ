using Microsoft.EntityFrameworkCore;
using PineappleFanSite.Models;
using System;

namespace PineappleFanSite.Data
{
    public class RegistryRepository : IRegistryRepository
    {
        AppDbContext context;
        public RegistryRepository(AppDbContext c)
        {
            context = c;
        }

        public Stories GetStoryById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Stories> GetStories()
        {
            return context.Stories
            .Include(m => m.Topic)
            .Include(m => m.By)
            .ToList();
        }

        public int StoreStories(Stories story)
        {
            context.Add(story);
            return context.SaveChanges();
        }

        public int StoreMessage(Messages message)
        {
            context.Add(message);
            return context.SaveChanges();
        }
    }
}
