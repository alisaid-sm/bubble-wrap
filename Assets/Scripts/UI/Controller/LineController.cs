using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text clientName;

    [SerializeField]
    private TMP_Text packageName;

    [SerializeField]
    private TMP_Text status;

    [SerializeField]
    private Button actionBtn;
    // Start is called before the first frame update
    public void SetContent(string clientName, string packageName, string status)
    {
        this.clientName.text = clientName;
        this.packageName.text = packageName;
        this.status.text = status;
    }
}
