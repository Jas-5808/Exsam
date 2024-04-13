using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _settingsCamera;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingPanel;

    public void Play()
    {
        SceneManager.LoadScene("street-1");
    }
    private void Settings()
    {
        _mainCamera.SetActive(false);
        _menuPanel.SetActive(false);
        _settingsCamera.SetActive(true);
        _settingPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
