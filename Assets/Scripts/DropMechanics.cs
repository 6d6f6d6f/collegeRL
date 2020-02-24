using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMechanics
{
    public GameObject coinObject;
    public GameObject gemObject;

    bool dropOnMe;

    private int coinAmount;
    private int gemAmount;
    public DropMechanics(int coinAmount, int gemAmount, bool dropOnMe)
    {
        this.coinAmount = coinAmount;
        this.gemAmount = gemAmount;
        coinObject = Resources.Load("Coin") as GameObject;
        gemObject = Resources.Load("Gem") as GameObject;
        this.dropOnMe = dropOnMe;
    }
    public void dropItems(Vector2 dropPosition)
    {
        for(int i = coinAmount; i > 0; i--)
        {
            dropCoinScript(dropPosition);
        }

        for(int g = gemAmount; g > 0; g--)
        {
            dropGemScript(dropPosition);
        }
    }

    private void dropCoinScript(Vector2 dropPosition)
    {
        GameObject coinDrop = Object.Instantiate(coinObject) as GameObject;
        if (dropOnMe)
        {
            coinDrop.transform.position = dropPosition;
        }
        else
        {
            coinDrop.transform.position = randomDropNear(dropPosition);
        }
    }

    private void dropGemScript(Vector2 dropPosition)
    {
        GameObject gemDrop = Object.Instantiate(gemObject) as GameObject;
        if (dropOnMe)
        {
            gemDrop.transform.position = dropPosition;
        }
        else
        {
            gemDrop.transform.position = randomDropNear(dropPosition);
        }
    }

    private Vector2 randomDropNear(Vector2 myPos)
    {
        Vector2 dropLine = new Vector2();
        Vector2 dropPos = new Vector2();
        double myRnd = ((Random.Range(0, 100) / 50.0) - 50) * Mathf.PI;
        dropLine.x = Mathf.Cos((float)myRnd);
        dropLine.y = Mathf.Sin((float)myRnd);
        dropPos = myPos + dropLine;
        return dropPos;
    }
}
