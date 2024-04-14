using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TaskDescription
{
    public string mDescription;
    public bool bIsCompleted;
}

[Serializable]
public abstract class QuestTask : MonoBehaviour
{
    public bool bIsCompleted { get; protected set; } = false;

    public abstract void EvaluateTask(QuestManager iQuestManager);

    public abstract TaskDescription GetTaskString();

    public virtual void SetupTask() { }
}

[Serializable]
public abstract class QuestEvent : MonoBehaviour
{
    public abstract void TriggerEvent();
}

[Serializable, AddComponentMenu("Quest/Quest Stage")]
public class QuestStage : MonoBehaviour
{
    public string QuestDescription = "";

    //[SerializeReference]
    List<QuestTask> Tasks;

    //[SerializeReference]
    List<QuestEvent> Events;

    float GracePeriod = 2.0f;
    float TimeStart = -1f;

    public bool bIsCompleted { get; protected set; } = false;

    private void Start()
    {
        Tasks = new List<QuestTask>();
        Events = new List<QuestEvent>();

        foreach (Transform child in transform)
        {
            if (child.name.CompareTo("Events") == 0)
            {
                foreach (Transform subChild in child.transform)
                {
                    if (subChild.TryGetComponent(out QuestEvent qEvent))
                    {
                        Events.Add(qEvent);
                    }
                }

                continue;
            }
            else if (child.name.CompareTo("Tasks") == 0)
            {
                foreach (Transform subChild in child.transform)
                {
                    if (subChild.TryGetComponent(out QuestTask qTask))
                    {
                        Tasks.Add(qTask);
                    }
                }
            }
        }
    }

    public void TriggerEvents()
    {
        foreach (QuestEvent wEvent in Events)
        {
            wEvent.TriggerEvent();
        }
    }

    public void EvaluateTasks(QuestManager iQuestManager)
    {
        if (bIsCompleted) return;

        int wCompletedTasks = 0;
        foreach (QuestTask wTask in Tasks)
        {
            if (!wTask.bIsCompleted) wTask.EvaluateTask(iQuestManager);

            if (wTask.bIsCompleted) wCompletedTasks++;
        }

        if (wCompletedTasks >= Tasks.Count)
        {
            if (TimeStart < 0)
            {
                TimeStart = Time.realtimeSinceStartup;
            }
            else if (Time.realtimeSinceStartup - TimeStart >= GracePeriod)
            {
                bIsCompleted = true;
            }
        }
    }

    public void SetupTasks()
    {
        foreach (QuestTask wTask in Tasks)
        {
            wTask.SetupTask();
        }
    }

    public void GetQuestText(out string oStageString, out TaskDescription[] oTaskStrings)
    {
        oStageString = QuestDescription;

        List<TaskDescription> wTaskStringList = new List<TaskDescription>();
        foreach (QuestTask task in Tasks)
        {
            wTaskStringList.Add(task.GetTaskString());
        }

        oTaskStrings = wTaskStringList.ToArray();
    }
}
