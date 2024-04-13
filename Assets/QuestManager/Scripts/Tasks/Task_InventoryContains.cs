using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable, AddComponentMenu("Quest/Task/Inventory Contains")]
public class Task_InventoryContains : QuestTask
{

    public string ItemName;

    public override void EvaluateTask(QuestManager iQuestManager)
    {

    }

    public override TaskDescription GetTaskString()
    {
        TaskDescription wReturn;
        wReturn.mDescription = "Aquire " + ItemName;
        wReturn.bIsCompleted = bIsCompleted;

        return wReturn;
    }
}
