using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;

namespace Halcyon {

    public class CreateNodeWindow : ScriptableObject, ISearchWindowProvider {

        Texture2D icon;
        BehaviourTreeView treeView;
        NodeView source;
        bool isSourceParent;
        EditorUtility.ScriptTemplate[] scriptFileAssets;

        TextAsset GetScriptTemplate(int type) {
            var projectSettings = BehaviourTreeProjectSettings.GetOrCreateSettings();

            switch (type) {
                case 0:
                    if (projectSettings.scriptTemplateActionNode) {
                        return projectSettings.scriptTemplateActionNode;
                    }
                    return BehaviourTreeEditorWindow.Instance.scriptTemplateActionNode;
                case 1:
                    if (projectSettings.scriptTemplateCompositeNode) {
                        return projectSettings.scriptTemplateCompositeNode;
                    }
                    return BehaviourTreeEditorWindow.Instance.scriptTemplateCompositeNode;
                case 2:
                    if (projectSettings.scriptTemplateDecoratorNode) {
                        return projectSettings.scriptTemplateDecoratorNode;
                    }
                    return BehaviourTreeEditorWindow.Instance.scriptTemplateDecoratorNode;
            }
            Debug.LogError("Unhandled script template type:" + type);
            return null;
        }

        public void Initialise(BehaviourTreeView treeView, NodeView source, bool isSourceParent) {
            this.treeView = treeView;
            this.source = source;
            this.isSourceParent = isSourceParent;

            icon = new Texture2D(1, 1);
            icon.SetPixel(0, 0, new Color(0, 0, 0, 0));
            icon.Apply();

            scriptFileAssets = new EditorUtility.ScriptTemplate[] {
                new EditorUtility.ScriptTemplate { templateFile = GetScriptTemplate(0), defaultFileName = "NewActionNode", subFolder = "Actions" },
                new EditorUtility.ScriptTemplate { templateFile = GetScriptTemplate(1), defaultFileName = "NewCompositeNode", subFolder = "Composites" },
                new EditorUtility.ScriptTemplate { templateFile = GetScriptTemplate(2), defaultFileName = "NewDecoratorNode", subFolder = "Decorators" },
            };
        }
        
        
        public class ContextualItem:IComparable<ContextualItem>
        {
            public string contextName = "";
            public Type contextType = null;

            public int CompareTo(ContextualItem other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return string.Compare(contextName, other.contextName, StringComparison.OrdinalIgnoreCase);
            }
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) 
        {
            var tree = new List<SearchTreeEntry>
            {
                //Creating the Root
                new SearchTreeGroupEntry(new GUIContent("Create Node"), 0),
            };

        
            List<ContextualItem> items = new List<ContextualItem>();
            //Gets all classes of type Node
            var collectionTypes = TypeCache.GetTypesDerivedFrom<Node>(); 
            
            foreach (var type in collectionTypes)
            {
                if(type.IsAbstract || type == typeof( RootNode))
                    continue;

                if (source != null)
                {
                    if (isSourceParent && type.BaseType == typeof(TriggerNode))
                    {
                        continue;
                    } 
                    if(!isSourceParent && type.BaseType == typeof(ActionNode))
                    {
                        continue;
                    }
                }
                
                //Filters out Action nodes of all types if the source is null as actions nodes do not contain an output.
                
                string menuName = "";
                string nodeTitle = "";
                string folderpath = "";
                foreach (var attribute in type.GetCustomAttributes(true))
                {
                    if (attribute is BehaviourTreeNodeAttribute behaviourTreeTagAttribute)
                    {
                        
                        menuName = behaviourTreeTagAttribute.GetMenuName();
                        nodeTitle = behaviourTreeTagAttribute.GetNodeTitle();
                        folderpath = behaviourTreeTagAttribute.GetMenuPath();
                    }
                }

                if (menuName == "")
                {
                    menuName = nodeTitle;
                }
                
                if (menuName == "")
                {
                    menuName = type.Name;
                }
                
                items.Add(new ContextualItem(){contextName = folderpath+"/" + menuName,contextType = type});
            }

            items.Sort((a, b) =>
            {
               
                string[] split1 = a.contextName.Split('/');
                string[] split2 = b.contextName.Split('/');

                for (int i = 0; i < split1.Length; i++)
                {
                    if (i >= split2.Length)
                    {
                        return 1;
                    }

                    int value = split1[i].CompareTo(split2[i]);
                    if (value != 0)
                    {
                        if (split1.Length != split2.Length && (i == split1.Length - 1 || i == split2.Length - 1))
                        {
                            return split1.Length < split2.Length ? 1 : -1;
                        }

                        return value;
                    }
                }
                return 0;
            });
    
            List<string> groups = new List<string>();
            foreach (var item in items)
            {
                string[] entryTitle = item.contextName.Split('/');
                string groupname = "";
                for (int i = 0; i < entryTitle.Length - 1; i++) //The Minus 1 reduces the size to only include groups not the final button
                {
                    groupname += entryTitle[i];
                    if (!groups.Contains(groupname))
                    {
                        tree.Add(new SearchTreeGroupEntry(new GUIContent(entryTitle[i]), i+1));
                        groups.Add(groupname);
                    }

                    groupname += "/";
                }

                var entry = new SearchTreeEntry(new GUIContent(entryTitle.Last()));
                entry.level = entryTitle.Length;
                System.Action invoke = () => CreateNode(item.contextType, context);
                entry.userData = invoke;
                tree.Add(entry);
            }
    
              
            {
                tree.Add(new SearchTreeGroupEntry(new GUIContent("New Script...")) { level = 1 });

                System.Action createActionScript = () => CreateScript(scriptFileAssets[0], context);
                tree.Add(new SearchTreeEntry(new GUIContent($"New Action Script")) { level = 2, userData = createActionScript });

                System.Action createCompositeScript = () => CreateScript(scriptFileAssets[1], context);
                tree.Add(new SearchTreeEntry(new GUIContent($"New Composite Script")) { level = 2, userData = createCompositeScript });

                System.Action createDecoratorScript = () => CreateScript(scriptFileAssets[2], context);
                tree.Add(new SearchTreeEntry(new GUIContent($"New Decorator Script")) { level = 2, userData = createDecoratorScript });
            }
            return tree;
        }
        

        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context) {
            System.Action invoke = (System.Action)searchTreeEntry.userData;
            invoke();
            return true;
        }

        public void CreateNode(System.Type type, SearchWindowContext context) {
            BehaviourTreeEditorWindow editorWindow = BehaviourTreeEditorWindow.Instance;
            
            var windowMousePosition = editorWindow.rootVisualElement.ChangeCoordinatesTo(editorWindow.rootVisualElement.parent, context.screenMousePosition - editorWindow.position.position);
            var graphMousePosition = editorWindow.treeView.contentViewContainer.WorldToLocal(windowMousePosition);
            var nodeOffset = new Vector2(-75, -20);
            var nodePosition = graphMousePosition + nodeOffset;

            // #TODO: Unify this with CreatePendingScriptNode
            NodeView createdNode;
            if (source != null) {
                if (isSourceParent) {
                    createdNode = treeView.CreateNode(type, nodePosition, source);
                } else {
                    createdNode = treeView.CreateNodeWithChild(type, nodePosition, source);
                }
            } else {
                createdNode = treeView.CreateNode(type, nodePosition, null);
            }

            treeView.SelectNode(createdNode);
        }

        public void CreateScript(EditorUtility.ScriptTemplate scriptTemplate, SearchWindowContext context) {
            BehaviourTreeEditorWindow editorWindow = BehaviourTreeEditorWindow.Instance;

            var windowMousePosition = editorWindow.rootVisualElement.ChangeCoordinatesTo(editorWindow.rootVisualElement.parent, context.screenMousePosition - editorWindow.position.position);
            var graphMousePosition = editorWindow.treeView.contentViewContainer.WorldToLocal(windowMousePosition);
            var nodeOffset = new Vector2(-75, -20);
            var nodePosition = graphMousePosition + nodeOffset;

            EditorUtility.CreateNewScript(scriptTemplate, source, isSourceParent, nodePosition);
        }

        public static void Show(Vector2 mousePosition, NodeView source, bool isSourceParent = false) {
            Vector2 screenPoint = GUIUtility.GUIToScreenPoint(mousePosition);
            CreateNodeWindow searchWindowProvider = ScriptableObject.CreateInstance<CreateNodeWindow>();
            searchWindowProvider.Initialise(BehaviourTreeEditorWindow.Instance.treeView, source, isSourceParent);
            SearchWindowContext windowContext = new SearchWindowContext(screenPoint, 240, 320);
            SearchWindow.Open(windowContext, searchWindowProvider);
        }

 


        
        


    }
}
