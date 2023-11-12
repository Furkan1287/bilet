using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/events")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

 [HttpGet]
public ActionResult<IEnumerable<Event>> GetEvents()
{
    var events = _eventService.GetEvents();
    return Ok(events);
}

    [HttpGet("{eventId}")]
    public ActionResult<Event> GetEvent(int eventId)
    {
        var eventItem = _eventService.GetEventById(eventId);
        if (eventItem == null)
        {
            return NotFound();
        }

        return eventItem;
    }

    [HttpPost]
    public ActionResult<Event> CreateEvent(Event eventItem)
    {
        _eventService.CreateEvent(eventItem);
        return CreatedAtAction(nameof(GetEvent), new { eventId = eventItem.EventId }, eventItem);
    }

    [HttpPut("{eventId}")]
    public IActionResult UpdateEvent(int eventId, Event eventItem)
    {
        if (eventId != eventItem.EventId)
        {
            return BadRequest();
        }

        _eventService.UpdateEvent(eventItem);

        return NoContent();
    }

    [HttpDelete("{eventId}")]
    public IActionResult DeleteEvent(int eventId)
    {
        var eventItem = _eventService.GetEventById(eventId);

        if (eventItem == null)
        {
            return NotFound();
        }

        _eventService.DeleteEvent(eventId);

        return NoContent();
    }
}
