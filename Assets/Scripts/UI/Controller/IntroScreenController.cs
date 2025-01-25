using UnityEngine;
using UnityEngine.UI;

public class IntroScreenController : MonoBehaviour
{
    [SerializeField]
    private Button _startBtn, _creditBtn, _quitBtn, _volBtn, _creditBackBtn;

    private UIController _uiController;


    void Awake()
    {
        _uiController = GameObject.FindWithTag("UIController").GetComponent<UIController>();
        _startBtn.onClick.AddListener(OnStartClick);
        _creditBtn.onClick.AddListener(OnCreditClick);
        _quitBtn.onClick.AddListener(OnQuitClick);
        _volBtn.onClick.AddListener(OnVolClick);
        _creditBackBtn.onClick.AddListener(OnCreditClose);
    }

    void Start()
    {
        _uiController.Route("Intro");
        _uiController.Popup("");
    }

    private void OnVolClick()
    {
        Debug.Log("OK");
    }

    private void OnQuitClick()
    {
        _uiController.Popup("Quit");
    }

    private void OnCreditClick()
    {
        _uiController.Route("Credit");
    }

    private void OnStartClick()
    {
        Debug.Log("OK");
    }

    void OnCreditClose()
    {
        _uiController.Route("Intro");
    }

    public void OnCancelQuit()
    {
        _uiController.Popup("");
    }

    public void OnQuitConfirm()
    {
        Application.Quit();
    }
}
