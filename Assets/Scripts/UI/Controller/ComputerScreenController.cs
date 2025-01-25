using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComputerScreenController : MonoBehaviour
{
    private GameUIManager gameUIManager;
    [SerializeField]
    private GameObject itemLine;
    [SerializeField]
    private GameObject spawnPoint;
    void Start()
    {
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
        RenderTasks();
    }

    void RenderTasks()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        List<ITask> tasks = gameUIManager._itemTasks;
        for (int i = 0; i < tasks.Count; i++)
        {
            int taskIndex = i;
            LineController line = Instantiate(itemLine, this.transform).GetComponent<LineController>();
            line.SetContent(tasks[i].client.clientName, tasks[i].package.packageName, tasks[i].status, () => SetOnProgress(taskIndex));
        }
    }

    void SetOnProgress(int index)
    {
        foreach (Transform child in spawnPoint.transform)
        {
            Destroy(child.gameObject);
        }
        List<ITask> tasks = gameUIManager._itemTasks;
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].status == ITaskStatus.ON_PROGRESS)
            {
                tasks[i].status = ITaskStatus.STAND_BY;
            }
        }
        tasks[index].status = ITaskStatus.ON_PROGRESS;
        Instantiate(tasks[index].package.prefab, spawnPoint.transform);
        RenderTasks();
    }
}
