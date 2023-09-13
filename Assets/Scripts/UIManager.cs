using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button createDeckButton;
    [SerializeField] Button shuffleButton;
    [SerializeField] TMP_InputField deckSizeInput;
    [SerializeField] TMP_Text numberfOfShufflesText;
    [SerializeField] Toggle singleCardShuffleToggle;
    [SerializeField] Toggle normalShuffleToggle;
    [SerializeField] Toggle staggeredShuffleToggle;

    private void Awake() {
        createDeckButton.onClick.AddListener(() => {
            GameManager gameManager = GameManager.GetInstance();
            gameManager.DeckSize = int.Parse(deckSizeInput.text);
            gameManager.CreateNewDeck();
            numberfOfShufflesText.text = "0";
        });
        shuffleButton.onClick.AddListener(() => {
            GameManager gameManager = GameManager.GetInstance();
            if(gameManager.currentShuffler != null)
            {
                gameManager.ShuffleDeck();
                int numberOfShuffles = int.Parse(numberfOfShufflesText.text);
                numberOfShuffles++;
                numberfOfShufflesText.text = numberOfShuffles.ToString();
            }
        });
        singleCardShuffleToggle.onValueChanged.AddListener((bool value) => {
            if(value)
            {
                GameManager gameManager = GameManager.GetInstance();
                gameManager.currentShuffler = gameManager.SingleCardShuffler;
            }
            else
            {
                GameManager gameManager = GameManager.GetInstance();
                gameManager.currentShuffler = null;
            }
        });
        staggeredShuffleToggle.onValueChanged.AddListener((bool value) => {
            if(value)
            {
                GameManager gameManager = GameManager.GetInstance();
                gameManager.currentShuffler = gameManager.StaggeredShuffler;
            }
            else
            {
                GameManager gameManager = GameManager.GetInstance();
                gameManager.currentShuffler = null;
            }
        });
        normalShuffleToggle.onValueChanged.AddListener((bool value) => {
            if(value)
            {
                GameManager gameManager = GameManager.GetInstance();
                gameManager.currentShuffler = gameManager.NormalShuffler;
            }
            else
            {
                GameManager gameManager = GameManager.GetInstance();
                gameManager.currentShuffler = null;
            }
        });
    }
}
