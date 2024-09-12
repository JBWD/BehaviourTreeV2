using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Halcyon.BT
{
    public static class GlobalEvents
    {

        
        // Global Events are used by listeners and Activators within the behaviour trees to communicate between trees.
        // Example of Use: OnBaseEvent: Player Died -> (Send Message to the following) -> Update UI, Pause Game, Open Death Screen.
        
        
        public static Action<string> OnBaseEvent;
        public static Action<string, float> OnFloatValueChange;
        public static Action<string, bool> OnBoolValueChange;
        public static Action<string, int> OnIntegerValueChange;
        public static Action<string, Vector2> OnVector2ValueChange;
        public static Action<string, Vector3> OnVector3ValueChange;
        public static Action<string, string> OnStringValueChange;

    }
}
