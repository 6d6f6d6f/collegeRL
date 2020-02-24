using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotBehavior : MonoBehaviour
{
    public GameObject player;

    public Rigidbody2D rb;

    public float moveSpeed;
    public float hitPoints = 2;
    public float damagePoints = 1;

    private HealthSystem myHealth;

    public static DropMechanics myDrop;

    private Vector3 moveToPos;

    Vector3 lastPos;

    public Transform shootPoint;

    public GameObject acidBullet;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myHealth = new HealthSystem((int)hitPoints);
        myDrop = new DropMechanics(1, 0, true);
        moveToPos = new Vector3();

        //starting movement
        randMove();
    }

    private void FixedUpdate()
    {
        var curPos = transform.position;
        if (curPos == lastPos)
        {
            shoot();
            randMove();
        }
        lastPos = curPos;

        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector2.Lerp(transform.position, moveToPos, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDamage"))
        {
            myHealth.Damage(Shoot.bulletDamage);
            if (myHealth.GetHealth() <= 0)
            {
                Destroy(gameObject);
                myDrop.dropItems(gameObject.transform.position);
            }
        }
    }

    private void randMove()
    {
        double myRnd = ((Random.Range(0, 100) / 50.0) - 50) * Mathf.PI;
        moveToPos.x = Mathf.Cos((float)myRnd);
        moveToPos.y = Mathf.Sin((float)myRnd);
        moveToPos.z = 0;
        moveToPos = transform.position + moveToPos * 3;
    }

    private void shoot()
    {
        GameObject acidShot = Instantiate(acidBullet);
        acidShot.transform.position = transform.position;
    }
}
