using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Remove : QuestEvent
{
    public GameObject[] EntitiesToRemove;

    public override void TriggerEvent()
    {
        foreach (var entity in EntitiesToRemove)
        {
            entity.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
