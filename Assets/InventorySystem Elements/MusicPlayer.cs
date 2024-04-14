using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        int musicPlayerNum = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayerNum > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); //don't destroy the game object when the new scene is loaded
        }
    }
}
