using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT {
    [System.Serializable]
    [NodeMenuPath("Behaviour Tree")]
    [NodeTitle("Random Failure")]
    [NodeMenuName("Random Failure")]
    [NodeIcon(NodeIcons.random)]
    [CreateBBVariable("ChanceOfFailure", BBVariableType.Number)]
    public class RandomFailure : ActionNode {

        [Range(0,1)]
        [Tooltip("Percentage chance of failure")] 
        public NodeProperty<NumericProperty> chanceOfFailure = new NodeProperty<NumericProperty>() { Value = new NumericProperty() {DoubleValue = .5}};

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            float value = Random.value;
            if (value > chanceOfFailure.Value.FloatValue) {
                return State.Failure;
            }
            return State.Success;
        }
    }
}