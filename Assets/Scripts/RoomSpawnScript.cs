using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnScript : MonoBehaviour
{
    public float numTreants;
    public float numMaggots;
    public float numCoins;
    public float numGems;

    public GameObject TreantPrefab;
    public GameObject MaggotPrefab;

    public GameObject coinObject;
    public GameObject gemObject;

    private Bounds roomSize;

    private void Start()
    {
        roomSize = gameObject.GetComponent<BoxCollider2D>().bounds;
        if(numCoins == -1)
        {
            numCoins = Random.Range(0, 6);
        }
        if(numGems == -1)
        {
            numGems = Random.Range(0, 2);
        }


        coinObject = Resources.Load("Coin") as GameObject;
        gemObject = Resources.Load("Gem") as GameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Entered Room");
            while(numTreants > 0)
            {
                GameObject spawnedTreant = Object.Instantiate(TreantPrefab) as GameObject;
                //spawn Position
                spawnedTreant.transform.position = RandomPointInBounds(roomSize); //Random Position within the box
                numTreants--;
            }

            while (numMaggots > 0)
            {
                GameObject spawnedMaggot = Object.Instantiate(MaggotPrefab) as GameObject;
                spawnedMaggot.transform.position = RandomPointInBounds(roomSize);
                numMaggots--;
            }
            while(numCoins > 0)
            {
                GameObject spawnedCoin = Object.Instantiate(coinObject) as GameObject;
                spawnedCoin.transform.position = RandomPointInBounds(roomSize);
                numCoins--;
            }

            while(numGems > 0)
            {
                GameObject spawnedGem = Object.Instantiate(gemObject) as GameObject;
                spawnedGem.transform.position = RandomPointInBounds(roomSize);
                numGems--;
            }
        }
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            1
        );
    }
}
