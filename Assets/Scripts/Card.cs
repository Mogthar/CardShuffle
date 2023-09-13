using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    protected int position;
    virtual public int Position 
    {
        get {return position;}
        set {position = value;}
    }
    private int number;
    protected int Number
    {
        get {return number;}
        set {number = value;}
    }
    virtual public void InitializeCard(int number, int deckSize){}
}
