using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject player;

    public static bool isGameOver;

    public Text gameOverText;
    public Text gemCountText;
    public Text coinCountText;
    public Text GameTimerText;

    public static int gemCount = 0;
    public static int coinCount = 0;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        gemCountText.text = "Gems: " + gemCount;
        coinCountText.text = "Coins: " + coinCount;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            GameTimerText.text = "Timer: " + (int)timer;
            if (player == null)
            {
                isGameOver = true;
            }
            if (timer <= 0)
            {
                LoseGame();
            }
        }
    }

    public void LoseGame()
    {
        isGameOver = true;
        gameOverText.text = "Game Over";
    }

    public void GemPickUp()
    {
        gemCount++;
        gemCountText.text = "Gems: " + gemCount;
    }

    public void CoinPickUp()
    {
        Debug.Log("Coin");
        coinCount++;
        coinCountText.text = "Coins: " + coinCount;
    }
}
