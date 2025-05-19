using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    private Vector3 currentPosition;
    private List<PathStorage> paths = new List<PathStorage>();
    private int currentIndex = 0;
    private bool getPath = false;
    [SerializeReference] private int health = 100;
    [SerializeReference] private int speed = 5;
    public static Action<int> pathEndAction;
    [SerializeReference] private int damage;
    

    private void Awake()
    {
        PathManager.getPath += WritePath;
    }

    void WritePath(List<PathStorage> pathList)
    {
        PathManager.getPath -= WritePath;
        foreach (PathStorage path in pathList)
        {
            paths.Add(Instantiate(path));
        }
        getPath = true;
    }

    void Move()
    {
            transform.position = Vector3.MoveTowards(transform.position, paths[0].paths[currentIndex], Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, paths[0].paths[currentIndex]) < 0.05f)
            {
                if (currentIndex == paths[0].paths.Length-1)
                {
                    pathEndAction?.Invoke(damage);
                    Die();
                    return;
                }
                transform.Rotate(0,paths[0].rotation[currentIndex],0);
                currentIndex++;
            }
    }

    void ChangeHealth(int healthAmount) // Вводить нужно -10, если нужно нанести урон.
    {
        health += healthAmount;
    }
    
    void Die() // При смерти уничтожает врага
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (getPath)
        {
            Move();
        }
    }
}
