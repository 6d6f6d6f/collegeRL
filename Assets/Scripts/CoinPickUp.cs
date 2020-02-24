using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public GameManagement gameManager;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagement>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.CoinPickUp();
            Destroy(gameObject);
        }
    }
}
