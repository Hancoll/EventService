﻿namespace ActivityService.Domain.Common;

public class Entity
{
    public Guid Id { get; set; }

    protected Entity(Guid id)
    {
        Id = id;
    }
}