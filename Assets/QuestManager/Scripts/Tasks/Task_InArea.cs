using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

[AddComponentMenu("Quest/Task/In Area")]
public class Task_InArea : QuestTask
{
    public string Description;

    [SerializeField]
    public TriggerArea TriggerArea;

    public override void EvaluateTask(QuestManager iQuestManager)
    {
        if(TriggerArea != null && TriggerArea.bIsTriggered)
        {
            bIsCompleted = true;
        }
    }

    public override TaskDescription GetTaskString()
    {
        TaskDescription wReturn = new TaskDescription();
        wReturn.mDescription = Description;
        wReturn.bIsCompleted = bIsCompleted;

        return wReturn;
    }
}
