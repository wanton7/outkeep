﻿using Orleans;
using System;

namespace Outkeep.Governance
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class WeakActivationStateAttribute : Attribute, IFacetMetadata, IWeakActivationStateConfiguration
    {
        public WeakActivationStateAttribute(string resourceGovernorName)
        {
            ResourceGovernorName = resourceGovernorName;
        }

        public string ResourceGovernorName { get; }
    }
}