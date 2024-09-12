using Halcyon.BT.Integrations.Pathlist;
using UnityEngine;


namespace Halcyon.BT
{
    public partial class Context
    {

        public PathList pathlist;
        
        public void InitializePathList()
        {
            pathlist = gameObject.GetComponent<PathList>();
        }
    }
}