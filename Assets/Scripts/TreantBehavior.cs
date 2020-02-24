using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantBehavior : MonoBehaviour
{
    public GameObject player;

    public Rigidbody2D rb;

    public float moveSpeed;
    public float hitPoints = 4;
    public float damagePoints = 1;

    private HealthSystem myHealth;

    private bool onPlayer = false;

    public static DropMechanics myDrop;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myHealth = new HealthSystem((int)hitPoints);
        myDrop = new DropMechanics(2, 0, false);
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        float step = moveSpeed * Time.deltaTime;
        if (!onPlayer && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDamage"))
        {
            myHealth.Damage(Shoot.bulletDamage);
            if(myHealth.GetHealth() <= 0)
            {
                Destroy(gameObject);
                myDrop.dropItems(gameObject.transform.position);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onPlayer = true;
            KnockBack(collision.gameObject, 25f);
        }
        else
        {
            //line below causing sliding backwards when sliding along wall while chasing player
            //KnockBack(collision.gameObject, 2f);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onPlayer = false;
        }
    }

    public void KnockBack(GameObject other, float knockBackAmount)
    {
        Vector2 hitDirection = (transform.position - other.transform.position).normalized;
        float timer = 0;
        float knockTime = .5f;
        while (knockTime > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(hitDirection * knockBackAmount);
        }
    }
}
