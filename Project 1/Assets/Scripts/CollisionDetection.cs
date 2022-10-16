using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] EnemySpawning enemySpawns;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] GameObject player;
    [SerializeField] CarCombat carCombat;

    // Update is called once per frame
    void Update()
    {
        // Checks Trucks collisions.
        if (CircleCollision(player, enemySpawns.trucks))
        {
            carCombat.TakeDamage(25);
        }

        // Checks Semis collision
        if (CircleCollision(player, enemySpawns.semis))
        {
            carCombat.TakeDamage(25);
        }

        // Checks bullet collisions with trucks.
        for (int i = 0; i < carCombat.bullets.Count; i++)
        {
            if (carCombat.bullets[i] != null)
            {
                if (CircleCollision(carCombat.bullets[i], enemySpawns.trucks))
                {
                    scoreManager.score += 100;
                }
            }
        }

        // Checks bullet collisions with semis.
        for (int i = 0; i < carCombat.bullets.Count; i++)
        {
            if (carCombat.bullets[i] != null)
            {
                AABBCollision(carCombat.bullets[i].GetComponent<SpriteRenderer>(), enemySpawns.semis) ;
            }
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

                if (obj.CompareTag("truck"))
                {
                    obj.transform.position = enemySpawns.truckSpawnPts[Random.Range(0, 4)].transform.position;
                }

                if (player.tag == "bullet")
                {
                    Destroy(player.gameObject);
                }

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

    public void AABBCollision(SpriteRenderer player, List<GameObject> otherObjs)
    {
        foreach (GameObject otherSR in otherObjs)
        {
            if (player.bounds.min.x < otherSR.GetComponent<SpriteRenderer>().bounds.max.x &&
                player.bounds.max.x > otherSR.GetComponent<SpriteRenderer>().bounds.min.x &&
                player.bounds.max.y > otherSR.GetComponent<SpriteRenderer>().bounds.min.y &&
                player.bounds.min.y < otherSR.GetComponent<SpriteRenderer>().bounds.max.y)
            {
                if (player.tag == "bullet")
                {
                    Destroy(player.gameObject);
                }
            }
            
        }
    }
}
