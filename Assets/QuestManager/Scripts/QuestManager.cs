using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
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

    public virtual void SetupTask() { }
}

[Serializable]
public abstract class QuestEvent : MonoBehaviour
{
    public abstract void TriggerEvent();
}

[Serializable]
public class QuestStage
{
    public string QuestDescription = ""; 

    [SerializeReference]
    QuestTask[] Tasks;

    [SerializeReference]
    QuestEvent[] Events;

    float GracePeriod = 2.0f;
    float TimeStart = -1f;

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
            if(TimeStart < 0)
            {
                TimeStart = Time.realtimeSinceStartup;
            }
            else if(Time.realtimeSinceStartup - TimeStart >= GracePeriod)
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

    void StartNextStage()
    {
        CurrentStageID++;

        if (CurrentStageID >= Stages.Length)
        {
            SceneManager.LoadScene("Credits");
        }
        else
        {
            Stages[CurrentStageID].SetupTasks();
            Stages[CurrentStageID].TriggerEvents();
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
            StartNextStage();
        }
    }

    public QuestStage GetCurrentQuestStage() 
    {
        if(CurrentStageID < 0 || CurrentStageID > Stages.Length) return null;
        return Stages[CurrentStageID]; 
    }
}
