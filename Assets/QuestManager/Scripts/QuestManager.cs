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
using UnityEngine.UIElements;

[AddComponentMenu("Quest/Quest Manager")]
public class QuestManager : MonoBehaviour
{

    [SerializeField] private EndMenuManager endMenuManager;
    [SerializeField] private UIDocument UiDocument;

    [SerializeField]
    public InventoryManager Inventory;

    [SerializeField]
    public List<QuestStage> Stages;

    int CurrentStageID = -1;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent(out QuestStage Stage))
            {
                Stages.Add(Stage);
            }
        }

        if (Stages.Count > 0)
        {
            CurrentStageID = 0;
        }
        
        endMenuManager.UiDocument = UiDocument;
    }

    void StartNextStage()
    {
        CurrentStageID++;

        if (CurrentStageID >= Stages.Count)
        {
            //SceneManager.LoadScene("Credits");
            endMenuManager.Open();
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
        if (CurrentStageID < 0 || CurrentStageID >= Stages.Count) return;

        QuestStage CurrentStage = Stages[CurrentStageID];

        CurrentStage.EvaluateTasks(this);

        if(CurrentStage.bIsCompleted)
        {
            StartNextStage();
        }
    }

    public QuestStage GetCurrentQuestStage() 
    {
        if(CurrentStageID < 0 || CurrentStageID > Stages.Count) return null;
        return Stages[CurrentStageID]; 
    }
}
