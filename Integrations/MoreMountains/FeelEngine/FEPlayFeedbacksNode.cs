using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Halcyon.BT.Integrations.MoreMountains.FeelEngine
{


    [System.Serializable]
    [NodeMenuPath("Integrations/MoreMountains/FeelEngine")]
    [NodeMenuName("Feel Engine: Play Feedbacks")]
    [NodeTitle("Feel Engine:\n Play Feedbacks")]
    [NodeIcon(NodeIcons.trigger)]
    [NodeColor(NodeColors.green)]
    public class FEPlayFeedbacksNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<MMFeedbacks> feedback;
        /// <summary>
        /// Called when the node is called and was not Running last frame.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// Called when the node completes and was not Running last frame.
        /// </summary>
        protected override void OnStop()
        {
        }

        /// <summary>
        /// Runs every frame the node is called or is in the Running State.
        /// </summary>
        /// <returns>Current State of the Node</returns>
        protected override State OnUpdate()
        {
            if(feedback.Value != null)
                feedback.Value.PlayFeedbacks();
            return State.Success;
        }

        /// <summary>
        /// Updates the Description Every Frame, Use to display errors and or realtime blackboard value changes.
        /// </summary>
        public override void UpdateDescription()
        {
            //The description updates every refresh frame within the editor. 
            description = "Plays the associated feedbacks from the linked MMFeedbacks script.";

            //Errored can be used to show the user an error message that something wasn't initialized or set correctly.
            errored = false;
        }
    }
}