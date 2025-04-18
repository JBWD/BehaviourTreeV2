using System.Collections;
using System.Collections.Generic;
using Halcyon.BT.Integrations.Pathlist;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Halcyon.BT {

    [System.Serializable]
    public class BooleanKey : BlackboardKey<bool> {

    }

    [System.Serializable]
    public class IntKey : BlackboardKey<int> {

    }

    [System.Serializable]
    public class FloatKey : BlackboardKey<float> {

    }

    [System.Serializable]
    public class DoubleKey : BlackboardKey<double> {

    }

    [System.Serializable]
    public class StringKey : BlackboardKey<string> {

    }

    [System.Serializable]
    public class Vector2Key : BlackboardKey<Vector2> {

    }

    [System.Serializable]
    public class Vector3Key : BlackboardKey<Vector3> {

    }

    [System.Serializable]
    public class Vector4Key : BlackboardKey<Vector4> {

    }

    [System.Serializable]
    public class Vector2IntKey : BlackboardKey<Vector2Int> {

    }

    [System.Serializable]
    public class Vector3IntKey : BlackboardKey<Vector3Int> {

    }

    [System.Serializable]
    public class GradientKey : BlackboardKey<Gradient> {

    }

    [System.Serializable]
    public class ColorKey : BlackboardKey<Color> {

    }

    [System.Serializable]
    public class LayerKey : BlackboardKey<int> {

    }

    [System.Serializable]
    public class LayerMaskKey : BlackboardKey<LayerMask> {

    }

    [System.Serializable]
    public class TagKey : BlackboardKey<string> {

    }

    [System.Serializable]
    public class CurveKey : BlackboardKey<AnimationCurve> {

    }

    [System.Serializable]
    public class BoundsKey : BlackboardKey<Bounds> {

    }

    [System.Serializable]
    public class BoundsIntKey : BlackboardKey<BoundsInt> {

    }

    [System.Serializable]
    public class GameObjectKey : BlackboardKey<GameObject> {

    }

    [System.Serializable]
    public class MaterialKey : BlackboardKey<Material> {

    }

    [System.Serializable]
    public class RigidBodyKey : BlackboardKey<Rigidbody> {

    }

    [System.Serializable]
    public class ColliderKey : BlackboardKey<Collider> {

    }

    [System.Serializable]
    public class TextMeshProUGUIKey : BlackboardKey<TextMeshProUGUI> {
        
    }

    [System.Serializable]
    public class LightKey : BlackboardKey<Light>
    {
        
    }

    [System.Serializable]
    public class UnityEventKey : BlackboardKey<UnityEvent>
    {
        
    }

    [System.Serializable]
    public class TransformKey : BlackboardKey<Transform>
    {
        
    }

    [System.Serializable]
    public class ButtonKey: BlackboardKey<Button>
    {
        
    }

    [System.Serializable]
    public class QuaternionKey : BlackboardKey<Quaternion>
    {
        
    }

    [System.Serializable]
    public class SceneKey : BlackboardKey<Scene>
    {
        
    }
    [System.Serializable]
    public class PathListKey : BlackboardKey<PathList>
    {
    }
    
    [System.Serializable]
    public class NumberKey : BlackboardKey<NumericProperty>
    {
    }
}
