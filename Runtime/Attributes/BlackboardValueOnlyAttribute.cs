using System;

namespace Halcyon.BT
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BlackboardValueOnlyAttribute : Attribute
    {
       
        public BlackboardValueOnlyAttribute()
        {
            
        }

        
    }
}