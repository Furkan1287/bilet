using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;

    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Event> GetEvents()
    {
        return _context.Events.ToList();
    }

    public Event GetEventById(int eventId)
    {
        return _context.Events.Find(eventId);
    }

    public void CreateEvent(Event eventItem)
    {
        _context.Events.Add(eventItem);
        _context.SaveChanges();
    }

    public void UpdateEvent(Event eventItem)
    {
        _context.Entry(eventItem).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteEvent(int eventId)
    {
        var eventItem = _context.Events.Find(eventId);
        _context.Events.Remove(eventItem);
        _context.SaveChanges();
    }
}
