using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject aboutPanel;
    public GameObject exitPanel;


    void Start()
    {
       
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Level1-1");
    }

    public void About()
    {
        menuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void BackButton()
    {
        menuPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void QuitGame()
    {
        menuPanel.SetActive(false);
        exitPanel.SetActive(true);
    }

    public void ConfirmYes()
    {
        Application.Quit();
    }

    public void ConfirmNo()
    {
        exitPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
