using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUIScript : MonoBehaviour
{
    public QuestManager mQuestManager;

    public InteractComponent mInteractComp;

    public TMPro.TMP_Text InteractText;

    public GameObject QuestPanel;

    public TMPro.TMP_Text QuestStageDescription;

    public TMPro.TMP_Text[] SubTaskTexts;

    public Color SubtaskColorActive;
    public Color SubtaskColorInactive;

    private void Start()
    {
        if(mQuestManager == null)
        {
            mQuestManager = GameObject.Find("QuestObserver").GetComponent<QuestManager>();
        }

        if(mInteractComp == null)
        {
            mInteractComp = GameObject.Find("Player").GetComponent<InteractComponent>();
        }

        InteractText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (mQuestManager != null && mQuestManager.GetCurrentQuestStage() != null)
        {
            QuestStage wCurrentStage = mQuestManager.GetCurrentQuestStage();

            wCurrentStage.GetQuestText(out string oStageText, out TaskDescription[] oTaskDescriptions);

            QuestStageDescription.text = oStageText;

            for (int c = 0; c < SubTaskTexts.Length; c++)
            {
                if (c < oTaskDescriptions.Length)
                {
                    TaskDescription wTask = oTaskDescriptions[c];

                    SubTaskTexts[c].text = wTask.mDescription;
                    if (wTask.bIsCompleted)
                    {
                        SubTaskTexts[c].color = SubtaskColorInactive;
                    }
                    else
                    {
                        SubTaskTexts[c].color = SubtaskColorActive;
                    }

                    SubTaskTexts[c].gameObject.SetActive(true);
                }
                else
                {
                    SubTaskTexts[c].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            QuestPanel.SetActive(false);
        }

        if(mInteractComp != null && mInteractComp.GetInteractMessage(out string oInteractMessage))
        {
            InteractText.text = "Press 'E' to " + oInteractMessage;
            InteractText.gameObject.SetActive(true);
        }
        else
        {
            InteractText.gameObject.SetActive(false);
        }
    }
}
