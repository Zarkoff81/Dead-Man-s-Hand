using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSkript : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject inputControlPanel;

    private void Awake()
    {
        menuPanel.gameObject.SetActive(true);
        optionsPanel.gameObject.SetActive(false);
        inputControlPanel.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        menuPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(true);
    }

    public void BackToMain()
    {
        optionsPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
    }

    public void ControlPanel()
    {
        inputControlPanel.gameObject.SetActive(true);
        optionsPanel.gameObject.SetActive(false);
    }

    public void BackToOptions()
    {
        optionsPanel.gameObject.SetActive(true);
        inputControlPanel.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
