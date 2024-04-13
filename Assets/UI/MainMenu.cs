using System;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public VisualElement startButton;
    private void Start()
    {
        startButton = GetComponent<UIDocument>().rootVisualElement.Q("StartButton");
        startButton.RegisterCallback<ClickEvent>(OnClickStartButton);
    }

    private void OnClickStartButton(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
    }
}
