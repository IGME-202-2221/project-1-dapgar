using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] EnemySpawning enemySpawns;

    [SerializeField] GameObject player;
    [SerializeField] CarCombat carCombat;

    // Update is called once per frame
    void Update()
    {
        // Checks Car collisions.
        if (CircleCollision(player, enemySpawns.enemies))
        {
            carCombat.TakeDamage(25);
        }

        // Checks bullet collisions.
        for (int i = 0; i < carCombat.bullets.Count; i++)
        {
            CircleCollision(carCombat.bullets[i], enemySpawns.enemies);
        }
    }

    public bool CircleCollision(GameObject player, List<GameObject> otherObjs)
    {
        foreach(GameObject obj in otherObjs)
        {
            if (Vector3.Distance(player.transform.position, obj.transform.position) <
                obj.GetComponent<SpriteRenderer>().bounds.extents.x +
                player.GetComponent<SpriteRenderer>().bounds.extents.x)
            {
                player.GetComponent<SpriteRenderer>().color = Color.blue;
                obj.GetComponent<SpriteRenderer>().color = Color.red;

                obj.transform.position = enemySpawns.spawnPoints[Random.Range(0, 4)].transform.position;

                return true;
            }
            else
            {
                player.GetComponent<SpriteRenderer>().color = Color.white;
                obj.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        return false;
    }
}
