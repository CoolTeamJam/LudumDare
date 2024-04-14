using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CreditsMenuManager : MonoBehaviour
{
    [SerializeField] private UIDocument UiDocument;
    private VisualElement rootElement;
    private VisualElement mainMenuButton;


    private void OnEnable()
    {
        rootElement = UiDocument.rootVisualElement;

        mainMenuButton = rootElement.Q("mainMenuCreditButton");
        mainMenuButton.RegisterCallback<ClickEvent>(OnClickmainMenuButton);

    }

    private void OnClickmainMenuButton(ClickEvent evt)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
