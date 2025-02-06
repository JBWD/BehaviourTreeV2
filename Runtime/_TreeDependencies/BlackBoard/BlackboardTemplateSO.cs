using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Halcyon.BT
{
    [CreateAssetMenu(menuName = "Halcyon/Behaviour Tree/Black Board Template", fileName = "New Blackboard Template")]
    public class BlackboardTemplateSO : ScriptableObject 
    {

        //String Name - String Type 
        // There is not going to be a value, this is just to make it easier to fill in multiple params.
       
        public List<Variable> variables = new List<Variable>();
        
        
        
        [Serializable]
        public class Variable
        {
            public string name;
            public BlackBoardSelectorType type; 
        }
        

        [Serializable]
        public class BlackBoardSelectorType
        {
            public string type;
        }
        private void PopulateAssociatedTypes()
        {
           
        }
    }
    
  

}