# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)

Note this package is still in very early development and in high flux. 

# [0.0.22] - 01-01-2024

### Added
- Global Event System 
- Math Nodes
- String Nodes
- UI Text Mesh Pro Nodes 
- Description Visibility Button

### Changed
- Modified the way descriptions function, this changed from being only on the nodes to be both on the nodes and in the Inspector View.

### Fixed
- N/A


# [0.0.21] - 29-12-2023

### Added
- Node Class Attribute that allows for modification of the title, color, display icon and menu path in the context menu.
- Triggers nodes were added to allow for real time collisions and inputs to kick off sub tree children within the same behaviour tree. These derive from the root node have been
    set to actions that have been implemented within the Behaviour Runner Instance.

- A* Pathfinding Integration Nodes:
    - Follow Target
    - Move to Position
    - Is Agent Moving
    - Stop Movement
    - Start Movment
    - Change Max Speed

### Changed
- Updated descriptions to change in realtime when the inspector is refreshed. This allows for variables to be changed and update the description.
- Switched Gizmos to use a foreach loop rather than Traversal to allow for Trigger Nodes and their children to draw Gizmos.
- Switched OnInit to use a foreach loop during initialization of the Behaviour Runner Instance to allow for Trigger nodes and their children to be initialized.
- Action Node's Input was switched from 'Single' to 'Multi' this will allow for multiple triggers and sequences to call the same nodes (Conflictions can occur if data is modifies in a previous tree)

### Fixed
- N/A

# [0.0.20] - 29-11-2023

### Added
- N/A

### Changed
- Improved Open Behaviour Tree dialog menu

### Fixed
- BlackboardKey 'Delete' context menu option now appears when clicking anywhere within the row

# [0.0.19] - 27-03-2023

- Restructured repository to contain just the package rather than the project. Installation URL is now just https://github.com/thekiwicoder0/UnityBehaviourTreeEditor.git
- Increased node text size slightly and center aligned
- Increased node description size slightly
- Use GraphElement.Capabilities to disable node snapping rather than editor prefs

# [0.0.18] - 09-03-2023

- Blackboard Keys can now be renamed by double clicking on the blackboard key label
- Nodes can be copy, pasted, and duplicated in the tree view
- Nodes snap to 15 pixels to align with the grid background. (Disabled adjacent node snapping)

# [0.0.17] - 04-03-2023

## NodeProperty<T>s, Blackboard Overrides, Switch Node

The NodeProperty class replaces the BlackboardProperty class, allowing node variables to be specified on the node, or optionally bind them directly to a blackboard key value.

### Changed features
- Renamed BlackboardProperty to NodeProperty
- Added a default value to the NodeProperty class
- Exposing a NodeProperty variable on a node allows the value to be specified on the node instance or bind it to a blackboard key.
- Added blackboard key overrides to the BehaviourTreeInstance component allowing blackboard key values to be override at the game object level.
- Added a new Switch composite node which allows executing a specific child based on an index value.

# [0.0.16] - 02-03-2023

## Runtime Blackboard Key support

Added runtime support for reading and writing blackboard values from components.

See BehaviourTreeInstance:
- SetBlackboardValue<T>
- GetBlackboardValue<T>
- FindBlackboardKey<T>

### Changed features
- Renamed BehaviourTreeRunner to BehaviourTreeInstance
- Changed behaviour tree initialisation from Start to Awake
- Added missing string blackboard key type
- Added SetBlackboardValue<T> method to BehaviourTreeInstance
- Added GetBlackboardValue<T> method to BehaviourTreeInstance
- Added FindBlackboardKey<T> method to BehaviourTreeInstance
- Added custom icon to BehaviourTreeInstance MonoBehaviour

# [0.0.15] - 01-03-2023

## Blackboard Refactor

The blackboard has been refactored significantly to support many more types, including any custom types defined in a project.

Note this will break any previously defined blackboard keys in your tree so you'll need to recreate them and assign them to a node.

Additionally, there are two new nodes:
- SetProperty
- CompareProperty

These nodes can be placed in a tree and used to set an arbitary blackboard key to a specific value, or compare a key to a specific value respectively.

### Changed features

- Added BlackboardProperty<T> type for reading and writing blackboard keys from nodes.
- Added generic BlackboardKey<T> type. Subclass this type to add support for custom types to the blackboard.
- Fixed editor assembly definition to only build for the editor.

# [0.0.14] - 01-03-2023

### Major changes

None

### Changed features

- Added CHANGELOG.md
- Amended Samples folder name to adhere to unity package standards

# [0.0.13] - (Previous Changes - prior to changelog.md)

## Major changes

- Added initial subtree implementation.
- Add a SubTreeNode to the graph and assign a behaviour tree to run it as a subtree in the graph.
- Auto Select nodes after they've been created so they appear in the inspector immediately
- New node scripts are automatically added to the tree on creation when dragging
- Block the UI while new node scripts are compiling
- Various other smaller changes and bug fixes