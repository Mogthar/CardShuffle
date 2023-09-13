using System.Collections.Generic;
using UnityEngine;

public class Shuffler
{
    public void Shuffle(List<Card> cards) {
        AssignNewPositions(cards);
        MoveCards(cards);
    }
    virtual protected void AssignNewPositions(List<Card> cards) {}
    virtual protected void MoveCards(List<Card> cards) {
        for(int i = 0; i < cards.Count; i++){
            Vector3 newPosition = new Vector3(-6.0f + cards[i].Position * 12.0f / (cards.Count -1), 0, 0);
            cards[i].transform.position = newPosition;
        }
    } 
};

public class SingleCardShuffler : Shuffler
{
    override protected void AssignNewPositions(List<Card> cards) {
        int newPosition = Random.Range(0, cards.Count - 2);
        List<Card> cardsToMove = new List<Card>
        {
            // move the last card to the new position
            cards[cards.Count - 1]
        };
        cards[cards.Count - 1].Position = newPosition;
        // move the rest of the cards to the right
        for(int i = newPosition; i < cards.Count - 1; i++){
            cardsToMove.Add(cards[i]);
            cards[i].Position = i + 1;
        }
        // split the original card list into two lists, keep left side and patch right side
        cards.RemoveRange(newPosition, cards.Count - newPosition);
        cards.AddRange(cardsToMove);
    }
};

public class StaggeredShuffler : Shuffler
{
    override protected void AssignNewPositions(List<Card> cards) {
        List<Card> bottomHalfDeck = cards.GetRange(0, (int) Mathf.Floor(cards.Count / 2.0f));
        List<Card> topHalfDeck = cards.GetRange((int) Mathf.Floor(cards.Count / 2.0f), (int) Mathf.Ceil(cards.Count / 2.0f));
        int bottomHalfDeckPosition = 0;
        int topHalfDeckPosition = 0;
        List<Card> newDeck = new List<Card>();
        while(bottomHalfDeckPosition < bottomHalfDeck.Count && topHalfDeckPosition < topHalfDeck.Count){
            float randomNumber = Random.Range(0.0f, 1.0f);
            if(randomNumber < 0.5f){
                newDeck.Add(bottomHalfDeck[bottomHalfDeckPosition]);
                bottomHalfDeckPosition++;
            } else {
                newDeck.Add(topHalfDeck[topHalfDeckPosition]);
                topHalfDeckPosition++;
            }
        }
        if(bottomHalfDeckPosition < bottomHalfDeck.Count){
            newDeck.AddRange(bottomHalfDeck.GetRange(bottomHalfDeckPosition, bottomHalfDeck.Count - bottomHalfDeckPosition));
        }
        if(topHalfDeckPosition < topHalfDeck.Count){
            newDeck.AddRange(topHalfDeck.GetRange(topHalfDeckPosition, topHalfDeck.Count - topHalfDeckPosition));
        }
        cards.Clear();
        cards.AddRange(newDeck);
        for(int i = 0; i < cards.Count; i++){
            cards[i].Position = i;
        }
    }
};

public class NormalShuffler : Shuffler
{
    override protected void AssignNewPositions(List<Card> cards) {
        List<Card> newDeck = new List<Card>();
        bool isShuffled = false;
        // empirical formula for average chunk size and the standard deviation
        int averageChunkSize = Mathf.Min(5, (int) Mathf.Ceil(cards.Count / 3.0f));
        int standardDeviation = 1;
        int originalDeckSize = cards.Count;
        while(!isShuffled){
            int actualChunkSize = 0;
            while(actualChunkSize < 1 || actualChunkSize >= originalDeckSize)
            {
                float randomNumber = Random.Range(0.0f, 1.0f);
                if(randomNumber < 0.09f)
                {
                    actualChunkSize = averageChunkSize - standardDeviation * 2;
                } else if(randomNumber < 0.33f)
                {
                    actualChunkSize = averageChunkSize - standardDeviation;
                } else if(randomNumber < 0.67f)
                {
                    actualChunkSize = averageChunkSize;
                } else if(randomNumber < 0.91f)
                {
                    actualChunkSize = averageChunkSize + standardDeviation;
                } else
                {
                    actualChunkSize = averageChunkSize + standardDeviation * 2;
                }
            }
            if(actualChunkSize < cards.Count){
                newDeck.AddRange(cards.GetRange(cards.Count - actualChunkSize, actualChunkSize));
                cards.RemoveRange(cards.Count - actualChunkSize, actualChunkSize);
            }
            else{
                newDeck.AddRange(cards.GetRange(0, cards.Count));
                cards.Clear();
                isShuffled = true;
            }
        }
        cards.AddRange(newDeck);
        for(int i = 0; i < cards.Count; i++){
            cards[i].Position = i;
        }
    }
};



