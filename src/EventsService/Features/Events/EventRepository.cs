﻿using EventsService.Infrastructure.Persistence;
using MongoDB.Driver;

namespace EventsService.Features.Events;

public class EventRepository : IEventRepository
{
    private readonly IApplicationContext _context;

    public void Add(Event @event)
    {
        _context.Events.InsertOne(@event);
    }

    public void Delete(Guid id)
    {
        _context.Events.DeleteOne(x => x.Id == id);
    }

    public Event GetEvent(Guid id)
    {
        return _context.Events.Find(x => x.Id == id).First();
    }

    public IEnumerable<Event> GetEvents(DateTime? start, DateTime? end, int? from, int? size)
    {
        var startDateTime = start ?? DateTime.MinValue;
        var endDateTime = end ?? DateTime.MaxValue;

        var result = _context.Events.Find(e =>
                e.StartDateTime >= startDateTime &&
                e.EndDateTime <= endDateTime)
            .Skip(from ?? 0)
            .Limit(size);

        return result.ToList();
    }

    public bool IsExists(Guid id)
    {
        return _context.Events.Find(x => x.Id == id).Any();
    }

    public void Update(Event @event)
    {
        _context.Events.ReplaceOne(e => e.Id == @event.Id, @event);
    }

    public EventRepository(IApplicationContext context)
    {
        _context = context;
    }
}
