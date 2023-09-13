using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private Deck deck;
    [SerializeField] Deck deckPrefab;
    [SerializeField] int deckSize;
    public int DeckSize
    {
        get { return deckSize; }
        set { deckSize = value; }
    }

    public Shuffler currentShuffler;
    private SingleCardShuffler singleCardShuffler = new SingleCardShuffler();
    public SingleCardShuffler SingleCardShuffler
    {
        get { return singleCardShuffler; }
    }

    private StaggeredShuffler staggeredShuffler = new StaggeredShuffler();
    public StaggeredShuffler StaggeredShuffler
    {
        get { return staggeredShuffler; }
    }

    private NormalShuffler normalShuffler = new NormalShuffler();
    public NormalShuffler NormalShuffler
    {
        get { return normalShuffler; }
    }

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        CreateNewDeck();
    }

    public void CreateNewDeck()
    {
        if(deck != null)
        {
            Destroy(deck.gameObject);
        }
        deck = Instantiate(deckPrefab);
        deck.DeckSize = deckSize;
        deck.InitializeDeck();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void ShuffleDeck()
    {
        if(currentShuffler != null)
        {
            currentShuffler.Shuffle(deck.Cards);
        }
    }
}
