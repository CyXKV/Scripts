using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveCreator", menuName = "Scriptable Objects/WaveCreator")]
public class WaveCreator : ScriptableObject
{
    public List<GameObject> enemies;
}
