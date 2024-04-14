using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_Construct : QuestTask
{
    public string Verb = "Build";
    public Interactable_Buildable Buildable;

    public override void EvaluateTask(QuestManager iQuestManager)
    {
        if (Buildable != null && Buildable.bIsBuilt)
        {
            bIsCompleted = true;
        }
    }

    public override TaskDescription GetTaskString()
    {
        TaskDescription wReturn = new TaskDescription();

        if (Buildable != null)
        {
            wReturn.mDescription = Verb + " the " + Buildable.ConstructName;
            wReturn.bIsCompleted = bIsCompleted;
        }
        else
        {
            wReturn.mDescription = "ERROR: MISSING BUILDABLE";
            wReturn.bIsCompleted = false;
        }

        return wReturn;
    }
}
