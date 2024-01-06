using TheKiwiCoder.Integrations.Pathlist;
using UnityEngine;


namespace TheKiwiCoder
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