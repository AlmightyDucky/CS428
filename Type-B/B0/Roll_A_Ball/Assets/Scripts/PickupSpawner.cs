using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickup;

    public int minX = 0; //-20,
    public int maxX = 0; //20
    public int minZ = 0; //-22
    public int maxZ = 0; //10
    public float delayBetweenSpawning = 2.5f;

    private int locationX = 0;
    private int locationZ = 0;

    void Start()
    {
        StartCoroutine(SpawnPickup());
    }

    void Update()
    {
        if (GameManager.timeRanOut)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator SpawnPickup()
    {
        locationX = Random.Range(minX, maxX) + 1;
        locationZ = Random.Range(minZ, maxZ) + 1;

        Vector3 pos = new Vector3(locationX, 0.5f, locationZ);
        Instantiate(pickup, pos, Quaternion.identity);

        yield return new WaitForSeconds(delayBetweenSpawning);

        StartCoroutine(SpawnPickup());
    }
}
