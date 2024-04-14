using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Quest/Task/Wait")]
public class Task_Wait : QuestTask
{
    [SerializeField] private string Description;
    private float StartTime;
    [SerializeField] private float WaitTime = 5f;

    public override void EvaluateTask(QuestManager iQuestManager)
    {
        if (bIsCompleted) return;

        if(Time.realtimeSinceStartup - StartTime >= WaitTime)
        {
            bIsCompleted = true;
        }
    }

    public override TaskDescription GetTaskString()
    {
        TaskDescription wDesc = new TaskDescription();
        wDesc.mDescription = Description;
        wDesc.bIsCompleted = bIsCompleted; 
        return wDesc;
    }

    public override void SetupTask()
    {
        StartTime = Time.realtimeSinceStartup;
    }
}
