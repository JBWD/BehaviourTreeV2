using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon {
    [System.Serializable]
    [BehaviourTreeNode(menuPath = "Behaviour Tree/Flow", nodeColor = NodeColors.blue)]
    public class Timeout : DecoratorNode {
        [Tooltip("Returns failure after this amount of time if the subtree is still running.")] public float duration = 1.0f;
        float startTime;

        protected override void OnStart() {
            startTime = Time.time;
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (child == null) {
                return State.Failure;
            }

            if (Time.time - startTime > duration) {
                return State.Failure;
            }

            return child.Update();
        }
    }
}