using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
    public void SetContent(string clientName, string packageName, ITaskStatus status, UnityAction callback)
    {
        this.clientName.text = clientName;
        this.packageName.text = packageName;
        this.status.text = status.ToString().Replace("_", " ");
        if (status != ITaskStatus.STAND_BY)
        {
            this.actionBtn.enabled = false;
            this.actionBtn.gameObject.SetActive(false);
        }
        else
        {
            this.actionBtn.onClick.AddListener(callback);
        }
    }

    internal void SetContent(string name1, string name2, string v1, object v2)
    {
        throw new NotImplementedException();
    }
}
