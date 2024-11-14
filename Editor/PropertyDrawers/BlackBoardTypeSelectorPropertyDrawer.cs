using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;

namespace Halcyon.BT
{
    

    [CustomPropertyDrawer(typeof(BlackboardTemplateSO.BlackBoardSelectorType))]
    public class BlackBoardTypeSelectorPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty typeString = property.FindPropertyRelative("type");
            EditorGUILayout.Space(-15);
            EditorGUILayout.BeginHorizontal();
            List<string> names = new List<string>();
            var types = TypeCache.GetTypesDerivedFrom<BlackboardKey>();
            int selectedIndex = 0;

            for (var index = 0; index < types.Count; index++)
            {
                var type = types[index];
                if (type.IsAbstract)
                    continue;
                string stringType = type.ToString();
                string[] n = stringType.Split('.');
                stringType = n[n.Length - 1].Replace("Key", "");
                names.Add(stringType);
                
            }

            names.Sort();
            if (names.Contains(typeString.stringValue))
            {
               selectedIndex = names.IndexOf(typeString.stringValue);
            }
            
            EditorGUILayout.LabelField("Type");
            selectedIndex = EditorGUILayout.Popup(selectedIndex, names.ToArray());
            typeString.stringValue = names[selectedIndex];
            EditorGUILayout.EndHorizontal();
        }
    }
}