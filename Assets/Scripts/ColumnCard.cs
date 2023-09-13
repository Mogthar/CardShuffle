using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnCard : Card
{
    public override void InitializeCard(int number, int deckSize)
    {
        this.Number = number;
        this.Position = number;
        this.GetComponent<SpriteRenderer>().color = MapNumberToColor(number);
        this.transform.localScale = new Vector3(12.0f * 0.66f/ (deckSize - 1), (1.0f + number) / deckSize * 5, 1);
    }

    private Color MapNumberToColor(int number)
    {
        return new Color(255,0,79);
    }

}