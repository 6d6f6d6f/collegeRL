using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static HealthSystem myHealth;

    public GameManagement gameManager;

    public Text playerHealthDisplay;

    public PlayerMovement playerMove;

    private bool canBeHit = true;

    private float immuneTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        myHealth = new HealthSystem(4);
        playerHealthDisplay.text = "HP: " + myHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (immuneTimer >= 0)
        {
            immuneTimer -= Time.deltaTime;
        }
        else
        {
            canBeHit = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BadGuy") && canBeHit)
        {
            myHealth.Damage(1);
            playerHealthDisplay.text = "HP: " + myHealth.GetHealth().ToString();

            if(myHealth.GetHealth() <= 0)
            {
                Destroy(gameObject);
                gameManager.LoseGame();
            }
            Debug.Log("Player Hit");
            playerMove.KnockBack(collision.gameObject);

            canBeHit = false;
            immuneTimer = 1;
        }

        if (collision.gameObject.CompareTag("BadThing") && canBeHit)
        {
            myHealth.Damage(1);
            playerHealthDisplay.text = "HP: " + myHealth.GetHealth().ToString();

            if (myHealth.GetHealth() <= 0)
            {
                Destroy(gameObject);
                gameManager.LoseGame();
            }
            canBeHit = false;
            immuneTimer = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BadThing") && canBeHit)
        {
            myHealth.Damage(1);
            playerHealthDisplay.text = "HP: " + myHealth.GetHealth().ToString();

            if (myHealth.GetHealth() <= 0)
            {
                Destroy(gameObject);
                gameManager.LoseGame();
            }

            canBeHit = false;
            immuneTimer = 1;
        }
    }
}
