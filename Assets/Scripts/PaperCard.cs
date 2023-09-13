using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class PaperCard : Card
{
    [SerializeField] SpriteShapeRenderer cardSpriteRenderer;
    [SerializeField] TMP_Text[] numberTexts;


    override public int Position
    {
        get { return position; }
        set { 
            position = value;
            cardSpriteRenderer.sortingOrder = position;
            foreach(TMP_Text text in numberTexts){
                MeshRenderer meshRenderer = text.GetComponent<MeshRenderer>();
                meshRenderer.sortingOrder = position;
            } 
        }
    }

    public override void InitializeCard(int number, int deckSize)
    {
        foreach(TMP_Text text in numberTexts){
            text.text = number.ToString();
        }
        this.Number = number;
        this.Position = number;
    }
}



