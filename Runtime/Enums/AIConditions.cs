using System;

namespace Halcyon.BT
{
    [Flags]
    public enum AIConditions
    {
        None = 0,
        Stunned = 1 << 0,
        Frozen = 1 << 1,
        Silenced = 1 << 2,
        
    }
}