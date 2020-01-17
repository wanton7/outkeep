﻿namespace Outkeep.Core.Caching
{
    public enum EvictionCause
    {
        None = 0,

        Removed = None + 100,

        Replaced = None + 200,

        Expired = None + 300,

        Capacity = 400,

        Disposed = 500
    }
}