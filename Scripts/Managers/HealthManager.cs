using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int castleHealth = 100;

    private void Awake()
    {
        Enemy.pathEndAction += ChangeHealth;
    }

    void ChangeHealth(int health) // Вводить нужно -10, если нужно нанести урон.
    {
        castleHealth += health;
    }
}
