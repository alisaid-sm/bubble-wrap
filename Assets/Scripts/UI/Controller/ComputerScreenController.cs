using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreenController : MonoBehaviour
{
    private GameUIManager gameUIManager;
    [SerializeField]
    private GameObject itemLine;
    void Start()
    {
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
        RenderTasks();
    }

    void RenderTasks()
    {
        List<ITask> tasks = gameUIManager._itemTasks;
        Debug.Log(tasks.Count);
        for (int i = 0; i < tasks.Count; i++)
        {
            LineController line = Instantiate(itemLine, this.transform).GetComponent<LineController>();
            line.SetContent(tasks[i].client.name, tasks[i].package.name, tasks[i].status.ToString().Replace("_", " "));
        }
    }
}
