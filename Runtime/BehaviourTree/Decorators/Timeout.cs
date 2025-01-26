using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    [System.Serializable]
    [NodeMenuPath("Behaviour Tree/Flow")]
    [CreateBBVariable("Duration", BBVariableType.Number)]
    public class Timeout : DecoratorNode {
        [Tooltip("Returns failure after this amount of time if the subtree is still running.")] 
        public NodeProperty<NumericProperty> duration = new NodeProperty<NumericProperty>() { Value = new NumericProperty() { DoubleValue = 1}};
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

            if (Time.time - startTime > duration.Value.FloatValue) {
                return State.Failure;
            }

            return child.Update();
        }
    }
}