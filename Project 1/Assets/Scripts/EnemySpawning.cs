using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject enemyPF;

    [SerializeField] int maxEnemies;
    [SerializeField] float enemySpeed;
    int numOfEnemies;

    private void Update()
    {
        if (numOfEnemies < maxEnemies)
        {
            Instantiate(enemyPF, transform.position, transform.rotation, transform);
            numOfEnemies++;
        }
    }
}
