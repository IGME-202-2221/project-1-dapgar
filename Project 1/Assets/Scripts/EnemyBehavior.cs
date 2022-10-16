using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] EnemySpawning enemySpawning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Car").transform;
        enemySpawning = GameObject.Find("EnemySpawnManager").GetComponent<EnemySpawning>();

        InvokeRepeating("SemiBehavior", 15f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("truck"))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpawning.truckSpeed * Time.deltaTime);
            RotateTowardsTarget();
        }
        else if (CompareTag("semi"))
        {
            transform.Translate(Vector3.down * enemySpawning.semiSpeed * Time.deltaTime);
        }
    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    void SemiBehavior()
    {
        if (tag == "semi")
        {
            int random = Random.Range(0, 4);
            transform.position = enemySpawning.semiSpawnPts[random].transform.position;
            transform.rotation = enemySpawning.semiSpawnPts[random].transform.rotation;
        }
    }
}
