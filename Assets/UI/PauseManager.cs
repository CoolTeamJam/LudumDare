using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private UIDocument UiDocument;
    private VisualElement rootElement;
    private VisualElement pauseElement;
    private string activeClass = "pause-active";

    private void OnEnable()
    {
        rootElement = UiDocument.rootVisualElement;
        pauseElement = rootElement.Q(className: "pause");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Open();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    private void Open()
    {
        pauseElement.AddToClassList(activeClass);
        Time.timeScale = 0;
    }

    private void Close()
    {
        pauseElement.RemoveFromClassList(activeClass);
        Time.timeScale = 1;
    }


}
