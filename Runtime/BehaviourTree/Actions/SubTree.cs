using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Halcyon.BT;
using System;

namespace Halcyon.BT {

    [System.Serializable]
    [NodeMenuPath("Deprecated")]
    [NodeTitle("Run Sub Tree")]
    [NodeMenuName("Run Sub Tree")]
    public class SubTree : ActionNode {
        
        [Tooltip("Behaviour tree asset to run as a subtree")]
        public BehaviourTree treeAsset;
        [HideInInspector] public BehaviourTree treeInstance;

     

        public override void OnInit() {
            if (treeAsset) {
                treeInstance = treeAsset.Clone();
                //Might want to look into having a cloned blackboard or a scriptable object blackboard that can be used instead.
                                                                                                                                     //Might have to be changed as the subtree may have other variables that need to be used. As 2 blackboards will be used.
                treeInstance.Bind(context);
            }
            
            
        }

        protected override void OnStart() {
            if (treeInstance) {
                treeInstance.treeState = Node.State.Running;
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (treeInstance) {
                return treeInstance.Update();
            }
            return State.Failure;
        }
    }
}
