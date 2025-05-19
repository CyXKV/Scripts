using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static Action allEnemyDestroyedAction;
    public static Action spawnAction;
    private bool allSpawned = false;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float spawnHeight;
    

    private void Awake()
    {
        WavesManager.spawnEnemy += Spawn;
    }

    private void Spawn(WaveCreator wave)
    {
        StartCoroutine(SpawnDelay(wave));
    }

    IEnumerator SpawnDelay(WaveCreator wave)
    {
        if (wave.enemies.Count == 0)
        {
            allSpawned = true;
            yield break;
        }
        Instantiate(wave.enemies[wave.enemies.Count-1], new Vector3(transform.position.x,spawnHeight,transform.position.z), Quaternion.identity);
        wave.enemies.RemoveAt(wave.enemies.Count-1);
        spawnAction?.Invoke();
        yield return new WaitForSeconds(spawnDelay);
        Spawn(wave);
    }

    private void Update()
    {
        if (allSpawned)
        {
            if (!GameObject.FindGameObjectWithTag("Enemy"))
            {
                allEnemyDestroyedAction?.Invoke();
                allSpawned = false;
            }
        }
    }
}
