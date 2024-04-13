using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}

public interface QuestEvent
{
    void TriggerEvent();
}

[Serializable]
public class QuestStage
{
    public string QuestDescription = ""; 

    [SerializeReference]
    QuestTask[] Tasks;

    [SerializeReference]
    QuestEvent[] Events;

    public bool bIsCompleted { get; protected set; } = false;

    public void TriggerEvents()
    {
        foreach (QuestEvent wEvent in Events) {
            wEvent.TriggerEvent();
        }
    }

    public void EvaluateTasks(QuestManager iQuestManager)
    {
        if (bIsCompleted) return;


        int wCompletedTasks = 0;
        foreach(QuestTask wTask in Tasks)
        {
            if(!wTask.bIsCompleted) wTask.EvaluateTask(iQuestManager);

            if (wTask.bIsCompleted) wCompletedTasks++;
        }

        if(wCompletedTasks >= Tasks.Length)
        {
            bIsCompleted = true;
        }
    }

    public void GetQuestText(out string oStageString, out TaskDescription[] oTaskStrings)
    {
        oStageString = QuestDescription;

        List<TaskDescription> wTaskStringList = new List<TaskDescription>();
        foreach(QuestTask task in Tasks)
        {
            wTaskStringList.Add(task.GetTaskString());
        }

        oTaskStrings = wTaskStringList.ToArray();
    }
}

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    public InventoryManager Inventory;

    [SerializeField]
    public QuestStage[] Stages;

    int CurrentStageID = -1;

    private void Start()
    {
        if(Stages.Length > 0)  
        { 
            CurrentStageID = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentStageID < 0 || CurrentStageID >= Stages.Length) return;

        QuestStage CurrentStage = Stages[CurrentStageID];

        CurrentStage.EvaluateTasks(this);

        if(CurrentStage.bIsCompleted)
        {
            CurrentStage.TriggerEvents();
            CurrentStageID++;
            
            if(CurrentStageID >= Stages.Length)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    public QuestStage GetCurrentQuestStage() 
    {
        if(CurrentStageID < 0 || CurrentStageID > Stages.Length) return null;
        return Stages[CurrentStageID]; 
    }
}
