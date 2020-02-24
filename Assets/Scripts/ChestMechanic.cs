using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMechanic
{
    public DropMechanics myDrop;
    private bool wasHit = false;

    public Sprite openSprite;
    public GameObject myObject;

    public float coinLow;
    public float coinHigh;

    public float gemLow;
    public float gemHigh;

    public ChestMechanic(Sprite openSprite, GameObject myObject, float coinLow, float coinHigh, float gemLow, float gemHigh)
    {
        this.openSprite = openSprite;
        this.myObject = myObject;
        this.coinLow = coinLow;
        this.coinHigh = coinHigh;
        this.gemLow = gemLow;
        this.gemHigh = gemHigh;

        myDrop = new DropMechanics((int)Random.Range(coinLow, coinHigh), (int)Random.Range(gemLow, gemHigh), false);
    }

    public void hitChest(Collision2D collision, Vector2 myPos)
    {
        if (collision.gameObject.CompareTag("Player") && !wasHit)
        {
            myDrop.dropItems(myPos);
            wasHit = true;
            myObject.GetComponent<SpriteRenderer>().sprite = openSprite;
        }
    }
}
