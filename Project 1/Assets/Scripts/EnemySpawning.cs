using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject truckPF;
    [SerializeField] GameObject semiPF;
    [SerializeField] Transform player;

    [SerializeField] int maxTrucks;
    [SerializeField] int maxSemis;
    public float truckSpeed;
    public float semiSpeed;

    public List<GameObject> truckSpawnPts = new List<GameObject>();
    public List<GameObject> trucks = new List<GameObject>();

    public List<GameObject> semiSpawnPts = new List<GameObject>();
    public List<GameObject> semis = new List<GameObject>();

    public int numOfTrucks;
    public int numOfSemis;

    private void Start()
    {
        player = GameObject.Find("Car").GetComponent<Transform>();    
    }

    private void Update()
    {
        if (numOfTrucks < maxTrucks)
        {
            trucks.Add(Instantiate(truckPF, truckSpawnPts[Random.Range(0, 4)].transform.position, transform.rotation));
            numOfTrucks++;
        }

        if (numOfSemis < maxSemis)
        {
            int random = Random.Range(0, 4);
            semis.Add(Instantiate(semiPF, semiSpawnPts[random].transform.position, semiSpawnPts[random].transform.rotation));
            numOfSemis++;
        }
    }
}
