using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private int deckSize = 0;
    public int DeckSize
    {
        get {return deckSize;}
        set {deckSize = value;}
    }
    [SerializeField] Card cardPrefab;
    
    private List<Card> cards;
    public List<Card> Cards
    {
        get {return cards;}
    }

    private void Awake() {
        InitializeDeck();
    }

    public void InitializeDeck() {
        cards = new List<Card>();
        for(int i = 0; i < deckSize; i++){
            cards.Add(Instantiate(cardPrefab, this.transform));
            cards[i].InitializeCard(i, deckSize);
        }
        InitializePositions();
    }

    private void InitializePositions() // should be called by the deck
    {
        for(int i = 0; i < deckSize; i++){
            Vector3 newPosition = new Vector3(-6.0f + i * 12.0f / (deckSize -1), 0, 0);
            cards[i].transform.position = newPosition;
        }
    }
}
 