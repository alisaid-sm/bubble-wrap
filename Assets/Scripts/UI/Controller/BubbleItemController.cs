using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BubbleItemController : MonoBehaviour
{
    GameManager gameManager;
    public BubbleDefinition data;

    public TMP_Text bubbleName;

    [SerializeField]
    private Button addBtn;

    GameUIManager gameUIManager;
    int playerGold;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
        playerGold = gameUIManager.GetPlayerGold();
        addBtn.onClick.AddListener(AddBubbleForm);
    }

    void AddBubbleForm()
    {
        int maxVol = gameManager.bubbleForm.maxVolume;
        int maxWeg = gameManager.bubbleForm.maxWeight;
        int price = gameManager.bubbleForm.price;


        maxVol += data.maxStretch;
        maxWeg += data.maxWeight;
        price += data.price;

        if (price > playerGold)
        {
            gameUIManager._bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>().submitBtn.interactable = false;
            gameUIManager._bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>().submitBtn.enabled = false;
        }
        else
        {
            gameUIManager._bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>().submitBtn.interactable = true;
            gameUIManager._bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>().submitBtn.enabled = true;
        }


        gameManager.SetBubbleForm(maxVol, maxWeg, price);
        gameUIManager._bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>().RenderBubbleForm();

    }


}
