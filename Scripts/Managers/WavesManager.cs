using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public static Action<WaveCreator> spawnEnemy;
    public static Action<Dictionary<string, int>> updateEnemyCount;
    public static Action<int,int> updateWave;
    public static Action<float> waveTimerChange;
    
    private int currentWave;
    private int waveCount;
    private bool waveActive = false;
    [SerializeField] private float timeToNextWave;
    private float waveTimer;
    [SerializeField] private List<WaveCreator> originWaves ;
    private List<WaveCreator> waves;

    private void Awake()
    {
        SpawnManager.allEnemyDestroyedAction += NextWave;
    }

    private void Start()
    {
        InitializingWaves();
    }

    private void InitializingWaves()
    {
        waves = new List<WaveCreator>();
        
        foreach (WaveCreator wave in originWaves)
        {
            waves.Add(Instantiate(wave));
        }
        
        waveTimer = timeToNextWave;
        waveActive = true;
        waveCount = waves.Count;
        currentWave = 1;
        
        updateWave?.Invoke(currentWave, waveCount);
        CreateCurrentWaveEnemiesList();
    }

    private void CreateCurrentWaveEnemiesList()
    {
        Dictionary<string,int> enemiesList = new Dictionary<string, int>();
        List<GameObject> enemyArray = waves[currentWave - 1].enemies;
        int enemyTypesCount = 0;
        string[] enemyNames = new string[enemyArray.Count];
        int[] enemyCount = new int[enemyArray.Count];
        
        for (int i = 0; i < enemyArray.Count; i++)
        {
            for (int j = 0; j < enemyArray.Count; j++)
            {
                if (enemyNames[j] == enemyArray[i].name)
                {
                    enemyCount[j] += 1;
                    break;
                }

                if (enemyNames[j] != null)
                {
                    continue;
                }

                enemyTypesCount += 1;
                enemyCount[j] = 1;
                enemyNames[j] = enemyArray[i].name;
                break;
            }
        }

        for (int i = 0; i < enemyTypesCount; i++)
        {
            enemiesList.Add(enemyNames[i],enemyCount[i]);
        }
        
        updateEnemyCount?.Invoke(enemiesList);
    }
    
    private void NextWave()
    {
        if (waves.Count <= currentWave)
        {
            Debug.Log("No waves available"); //Здесь типа победил
            return;
        } 
        currentWave++;
        waveActive = true;
        updateWave?.Invoke(currentWave, waveCount);
        CreateCurrentWaveEnemiesList();
    }
    private void StartWave()
    {
        spawnEnemy?.Invoke(waves[currentWave-1]);
    }

    private void Update()
    {
        if (waveActive)
        {
            waveTimer -= Time.deltaTime;
            waveTimerChange?.Invoke(waveTimer);
        }

        if (waveTimer <= 0)
        {
            waveActive = false;
            waveTimer = timeToNextWave;
            StartWave();
        }
    }
}
