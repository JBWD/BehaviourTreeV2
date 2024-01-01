using Pathfinding;

namespace TheKiwiCoder
{
    public partial class Context
    {
        public AIPath aiPath = null;
        
        
        public void InitializeAStar()
        {
            if (aiPath == null)
            {
                aiPath = gameObject.GetComponent<AIPath>();
            }
        }
    }
}