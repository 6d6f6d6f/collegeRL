using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //public GameObject onHitAnimation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(onHitAnimation, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
