using UnityEngine;
using UnityEngine.SceneManagement;

namespace Halcyon.BT
{


    public class CreateSceneNode : ActionNode
    {
        
        
        public NodeProperty<string> sceneName;
        
        [BlackboardValueOnly]
        public NodeProperty<Scene> saveScene;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            SceneManager.CreateScene(sceneName.Value);
            return State.Success;
        }
    }
}