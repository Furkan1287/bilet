using System.Collections.Generic;

public interface IEventService
{
    IEnumerable<Event> GetEvents();
    Event GetEventById(int eventId);
    void CreateEvent(Event eventItem);
    void UpdateEvent(Event eventItem);
    void DeleteEvent(int eventId);
}