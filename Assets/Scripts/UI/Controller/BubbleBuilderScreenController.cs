using TMPro;
using UnityEngine;

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

    GameManager gameManager;
    GameUIManager gameUIManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
        int p = gameManager.playerForm.panjang;
        int l = gameManager.playerForm.lebar;
        int t = gameManager.playerForm.tinggi;
        panjangText.text = p.ToString();
        lebarText.text = l.ToString();
        tinggiText.text = t.ToString();
        volumeText.text = (p * l * t).ToString();
        beratText.text = gameUIManager.FindTask().package.weight.ToString();
    }
}
