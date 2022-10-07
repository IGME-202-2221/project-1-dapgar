using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject enemyPF;

    [SerializeField] int maxEnemies;
    [SerializeField] float enemySpeed;

    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();

    int numOfEnemies;

    private void Update()
    {
        if (numOfEnemies < maxEnemies)
        {
            enemies.Add(Instantiate(enemyPF, spawnPoints[Random.Range(0, 4)].transform.position, transform.rotation, transform));
            numOfEnemies++;
        }
    }
}
