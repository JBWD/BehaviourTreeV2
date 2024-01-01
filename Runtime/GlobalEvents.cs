using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TheKiwiCoder
{
    public static class GlobalEvents
    {
        /// <summary>
        /// On Value change uses a string identifier to allow for multiple nodes to listen to the same event and choose
        /// when they want to use the value provided.
        /// </summary>
        public static Action<string, float> OnValueChange;




    }
}
