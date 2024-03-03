using Halcyon.Integrations.Pathlist;
using UnityEngine;


namespace Halcyon
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