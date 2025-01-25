using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScreenController : MonoBehaviour
{
    [SerializeField]
    private Button _startBtn, _creditBtn, _quitBtn, _volBtn, _creditBackBtn;
    private UIController _uiController;
    private AudioSource _bgm;

    [SerializeField]
    private Sprite soundOn;

    [SerializeField]
    private Sprite soundOff;

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

        _bgm = _uiController.mainBgm.GetComponent<AudioSource>();
        _bgm.Play();
        LoadVolBtnImage();
    }

    private void OnVolClick()
    {
        bool isMuted = PlayerPrefs.GetString("muted") == "true";

        if (isMuted)
        {
            PlayerPrefs.SetString("muted", "false");
            _bgm.mute = false;
            SetVolBtnImg(true);
        }
        else
        {
            PlayerPrefs.SetString("muted", "true");
            _bgm.mute = true;
            SetVolBtnImg(false);
        }
        PlayerPrefs.Save();
    }

    void LoadVolBtnImage()
    {
        bool isMuted = PlayerPrefs.GetString("muted") == "true";
        SetVolBtnImg(!isMuted);
    }

    void SetVolBtnImg(bool isMuted)
    {
        Image btnImage = _volBtn.GetComponent<Image>();
        if (isMuted)
        {
            btnImage.sprite = soundOn;
        }
        else
        {
            btnImage.sprite = soundOff;
        }
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
        SceneManager.LoadScene(1);
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
