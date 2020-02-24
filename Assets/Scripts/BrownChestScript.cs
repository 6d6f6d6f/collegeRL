using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownChestScript : MonoBehaviour
{
    public ChestMechanic myMechanics;

    public Sprite openSprite;

    public float coinLow;
    public float coinHigh;

    public float gemLow;
    public float gemHigh;

    // Start is called before the first frame update
    void Start()
    {
        myMechanics = new ChestMechanic(openSprite, gameObject, coinLow, coinHigh, gemLow, gemHigh);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myMechanics.hitChest(collision, gameObject.transform.position);
    }
}
