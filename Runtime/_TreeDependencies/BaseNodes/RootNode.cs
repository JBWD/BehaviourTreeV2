using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon.BT {

    
    [NodeTitle("Unity:\nUpdate")]
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.red)]
    [System.Serializable]
    public class RootNode : Node {

        [SerializeReference]
        [HideInInspector] 
        public Node child;

        protected override void OnStart()
        {
            description = "Node the game loop starts in.";
        }

        protected override void OnStop() {

        }

        protected override State OnUpdate() {
            
            if (child != null) 
                child.Update();
            return State.Running;
        }
        
        
    }
    
    
}