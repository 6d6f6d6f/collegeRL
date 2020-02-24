using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBulletBehavior : MonoBehaviour
{
    public GameObject AcidPuddle;

    float timer;
    GameObject player;
    Vector3 toPos;

    public float bulletSpeed = 5.0f;
    private void Start()
    {
        Debug.Log(transform.position);
        timer = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        toPos = player.transform.position;

    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, toPos , bulletSpeed * Time.deltaTime);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(onHitAnimation, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        if (!collision.gameObject.CompareTag("BadGuy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject spawnedAcidPuddle = Object.Instantiate(AcidPuddle) as GameObject;
        spawnedAcidPuddle.transform.position = gameObject.transform.position;
    }
}
