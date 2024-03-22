using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject menuButtton;

    void Start()
    {
        menuPanel.SetActive(false);
        menuButtton.SetActive(true);
    }

    public void MenuPanel()
    {
        menuPanel.SetActive(true);
        menuButtton.SetActive(false);
        Debug.Log("Menu");
    }

    public void Continue()
    {
        menuPanel.SetActive(false);
        menuButtton.SetActive(true);
    }
}
