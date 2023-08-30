using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject WinPanel;
    public GameObject LosePanel;
    public int totalLevel = 2;
    private Ball ballController;
    private CylinderRotate cylinderRotateController;
    public Status status = Status.PlayMode;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        ballController = FindObjectOfType<Ball>();
        cylinderRotateController = FindObjectOfType<CylinderRotate>();
    }

    public void Retry() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void NextLevel(Button btn)
    {
        if (SceneManager.GetActiveScene().buildIndex+1 < totalLevel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            btn.transform.GetChild(0).GetComponent<Text>().text = "No More Levels";
            btn.interactable = false;
        }
    }

    public void BackLevel(Button btn)
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        else
        {
            btn.transform.GetChild(0).GetComponent<Text>().text = "No More Back";
            btn.interactable = false;
        }
    }

    public void Quit() => Application.Quit();

    public void OpenWinPanel()
    {
        if(status is Status.LoseMode)return;
        status = Status.WinMode;
        DisableController();
        WinPanel.SetActive(true);
    }

    public void OpenLosePanel()
    {
        if(status is Status.WinMode)return;
        status = Status.LoseMode;
        DisableController();
        LosePanel.SetActive(true);
    }

    private void DisableController()
    {
        cylinderRotateController.enabled = false;
        ballController.enabled = false;
    }
}

public enum Status
{
    PlayMode,
    WinMode,
    LoseMode
}