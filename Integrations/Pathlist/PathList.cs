using System;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT.Integrations.Pathlist
{
    public class PathList: MonoBehaviour
    {
        public List<Vector3> pathPoints = new List<Vector3>();
        private int m_Index;

        
        public int index
        {
            get
            {
                return m_Index;
            }
            set
            {
                Debug.Log(value);
                if (value >= pathPoints.Count)
                    
                    m_Index = pathPoints.Count - 1;
                else if (value < 0)
                    m_Index = 0;
                else
                    m_Index = value;
            }
        }

        public Vector3 GetCurrentPosition()
        {
            return pathPoints[m_Index];
        }

        public void SetPathList(List<Vector3> list)
        {
            pathPoints = list;
        }

        public Vector3 GetPathPosition(int index)
        {
            if (index >= pathPoints.Count)
            {
                return pathPoints[^1];
            }

            if (index < 0)
            {
                return pathPoints[0];
            }
                
            return Vector3.zero;
        }

        public void SetPathPosition(int index, Vector3 position)
        {
            if (index > pathPoints.Count)
            {
                AddPathPosition(position);
            }

            if (index < 0 && pathPoints.Count>0)
            {
                pathPoints[0] = position;
            }
            else
            {
                AddPathPosition(position);
            }

            pathPoints[index] = position;
        }
        
        
        public void AddPathPosition(Vector3 position)
        {
            pathPoints.Add(position);
        }
    }
}