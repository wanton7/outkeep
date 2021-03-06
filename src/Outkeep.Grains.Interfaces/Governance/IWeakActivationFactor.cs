﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Outkeep.Governance
{
    /// <summary>
    /// Marker interface for weak activation factors.
    /// </summary>
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces")]
    public interface IWeakActivationFactor : IComparable<IWeakActivationFactor>
    {
    }
}