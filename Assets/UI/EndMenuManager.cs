using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenuManager : MonoBehaviour
{
    private readonly string activeClass = "pause-active";

    [SerializeField] private UIDocument UiDocument;
    private VisualElement rootElement;
    private VisualElement pauseElement;
    private VisualElement resumeButton;
    private VisualElement settingsButton;
    private VisualElement quitButton;


    private void Start()
    {
        rootElement = UiDocument.rootVisualElement;
        pauseElement = rootElement.Q(className: "pause");

        resumeButton = rootElement.Q("resumeButton");
        resumeButton.RegisterCallback<ClickEvent>(OnClickResumeButton);

        settingsButton = rootElement.Q("settingsButton");
        settingsButton.RegisterCallback<ClickEvent>(OnClickSettingsButton);

        quitButton = rootElement.Q("quitButton");
        quitButton.RegisterCallback<ClickEvent>(OnClickQuitButton);
    }


    private void OnEnable()
    {


    }

    private void OnClickQuitButton(ClickEvent evt)
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void OnClickSettingsButton(ClickEvent evt)
    {
        Debug.Log("Settings");
        SceneManager.LoadScene(0);
    }

    private void OnClickResumeButton(ClickEvent evt)
    {
        Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Open();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    public void Open()
    {
        pauseElement.AddToClassList(activeClass);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

    private void Close()
    {
        pauseElement.RemoveFromClassList(activeClass);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

}
