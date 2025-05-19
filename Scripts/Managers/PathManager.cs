using System;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] private List<PathStorage> paths;
    public static Action<List<PathStorage>> getPath;

    void Awake()
    {
        SpawnManager.spawnAction += GetPath;
    }

    void GetPath()
    {
        getPath?.Invoke(paths);
    }
}
