using System;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT.Integrations.Pathlist
{
    [Serializable]
    public class PathListProperty
    {
        
        public List<PathPoint> PathPoints;

        [Serializable]
        public class PathPoint
        {
            public Vector3 point;
            public float delayAtPoint;
            public float moveSpeed;
        }
    }
}