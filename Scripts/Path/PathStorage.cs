using UnityEngine;

[CreateAssetMenu(fileName = "PathStorage", menuName = "Scriptable Objects/PathStorage")]
public class PathStorage : ScriptableObject
{
    public Vector3[] paths;
    public float[] rotation;
}
