using System;

namespace Halcyon
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BlackboardValueOnlyAttribute : Attribute
    {
       
        public BlackboardValueOnlyAttribute()
        {
            
        }

        
    }
}