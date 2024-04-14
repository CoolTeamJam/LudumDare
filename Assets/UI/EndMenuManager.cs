using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenuManager : MonoBehaviour
{
    private readonly string activeClass = "pause-active";

    [SerializeField] public UIDocument UiDocument;
    [SerializeField] public UIDocument pauseMenu;
    private VisualElement rootElement;
    private VisualElement pauseElement;
    private VisualElement resumeButton;
    private VisualElement settingsButton;
    private VisualElement quitButton;


    private void Start()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }


    private void OnEnable()
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

    private void OnClickQuitButton(ClickEvent evt)
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void OnClickSettingsButton(ClickEvent evt)
    {
        SceneManager.LoadScene(0);

    }

    private void OnClickResumeButton(ClickEvent evt)
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {

    }

    public void Open()
    {
        Time.timeScale = 0;
        if (pauseMenu != null)
        {
            pauseMenu.enabled = false;
        }
       
        pauseElement.AddToClassList(activeClass);
        
    }

    private void Close()
    {
        pauseElement.RemoveFromClassList(activeClass);
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

}
