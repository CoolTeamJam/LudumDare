using System;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private VisualElement startButton;
    private VisualElement settingsButton;
    private VisualElement creditsButton;
    private VisualElement exitButton;

    private void Start()
    {
        startButton = GetComponent<UIDocument>().rootVisualElement.Q("StartButton");
        startButton.RegisterCallback<ClickEvent>(OnClickStartButton);

        settingsButton = GetComponent<UIDocument>().rootVisualElement.Q("SettingsButton");
        settingsButton.RegisterCallback<ClickEvent>(OnClickSettingsButton);

        creditsButton = GetComponent<UIDocument>().rootVisualElement.Q("CreditsButton");
        creditsButton.RegisterCallback<ClickEvent>(OnClickCreditsButton);

        exitButton = GetComponent<UIDocument>().rootVisualElement.Q("ExitButton");
        exitButton.RegisterCallback<ClickEvent>(OnClickExitButton);
    }


    private void OnClickStartButton(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
    }

    private void OnClickSettingsButton(ClickEvent evt)
    {
        Debug.Log("Settings");
    }

    private void OnClickCreditsButton(ClickEvent evt)
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    private void OnClickExitButton(ClickEvent evt)
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    

   

   
}
