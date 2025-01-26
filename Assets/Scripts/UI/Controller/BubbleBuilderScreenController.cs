using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BubbleBuilderScreenController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text panjangText;

    [SerializeField]
    private TMP_Text lebarText;

    [SerializeField]
    private TMP_Text tinggiText;

    [SerializeField]
    private TMP_Text volumeText;

    [SerializeField]
    private TMP_Text beratText;
    [SerializeField]
    private TMP_Text maxVolText;
    [SerializeField]
    private TMP_Text maxWegText;
    [SerializeField]
    private TMP_Text priceText;
    [SerializeField]
    private TMP_Text goldText;

    [SerializeField]
    private GameObject bubbleListContainer;

    [SerializeField]
    private GameObject bubbleListItem;

    public Button submitBtn;

    GameManager gameManager;
    GameUIManager gameUIManager;

    private List<BubbleDefinition> bubbles;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
        bubbles = gameUIManager.GetBubbles();
        int p = gameManager.playerForm.panjang;
        int l = gameManager.playerForm.lebar;
        int t = gameManager.playerForm.tinggi;
        panjangText.text = p.ToString();
        lebarText.text = l.ToString();
        tinggiText.text = t.ToString();
        volumeText.text = (p * l * t).ToString();
        beratText.text = gameUIManager.FindTask().package.weight.ToString();
        goldText.text = gameUIManager.GetPlayerGold().ToString();

        GenerateBubbleList();

    }



    void GenerateBubbleList()
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            GameObject bubbleItem = Instantiate(bubbleListItem, bubbleListContainer.transform);
            BubbleItemController bubbleCtr = bubbleItem.GetComponent<BubbleItemController>();
            bubbleCtr.data = bubbles[i];
            bubbleCtr.bubbleName.text = bubbles[i].type;
        }
    }

    public void RenderBubbleForm()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        maxVolText.text = gameManager.bubbleForm.maxVolume.ToString();

        maxWegText.text = gameManager.bubbleForm.maxWeight.ToString();

        priceText.text = gameManager.bubbleForm.price.ToString();
    }

}
