using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text waveCountText;
    [SerializeField] private TMP_Text enemyCountText;
    private void Awake()
    {
        WavesManager.updateEnemyCount += UpdateEnemyCount;
        WavesManager.waveTimerChange += UpdateTimer;
        WavesManager.updateWave += UpdateWave;
    }

    private void UpdateEnemyCount(Dictionary<string,int> enemyList)
    {
        string enemyText = "";
        
        foreach(var enemy in enemyList)
        {
            enemyText += enemy.Key + ": " + enemy.Value + "\n";
        }
        
        enemyCountText.text = enemyText;
    }

    private void UpdateWave(int currentWave, int waveCount)
    {
        waveCountText.text = currentWave.ToString() + " / " + waveCount.ToString();
    }

    private void UpdateTimer(float timer)
    {
        timerText.text = timer.ToString("0");
    }
}
