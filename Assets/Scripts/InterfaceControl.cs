using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceControl : MonoBehaviour {

    enum stage
    {
        MAINMENU,
        TEAMMENU,
        SETTINGSMENU,
        PAUSEMENU,
        GAMELOOP,
        INGAMEUI,
        RESTARTMENU
    }

    public GameObject[] menus;
    public GameObject undoButton;
    public bool lastStageActivated = false;
    // Use this for initialization
    void Start()
    {
        SetMainMenu(true);
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void SetMainMenu(bool activated)
    {
        menus[(int)stage.MAINMENU].SetActive(activated);
        menus[(int)stage.SETTINGSMENU].SetActive(false);
        menus[(int)stage.TEAMMENU].SetActive(false);
        menus[(int)stage.GAMELOOP].SetActive(false);
        this.GetComponent<LevelGenerator>().PauseGame(false);
        menus[(int)stage.PAUSEMENU].SetActive(false);
        menus[(int)stage.INGAMEUI].SetActive(false);
        menus[(int)stage.RESTARTMENU].SetActive(false);
        undoButton.SetActive(false);
        lastStageActivated = false;
    }

    public void SetTeamMenu(bool activated)
    {
        menus[(int)stage.TEAMMENU].SetActive(activated);
        menus[(int)stage.MAINMENU].SetActive(false);
        menus[(int)stage.SETTINGSMENU].SetActive(false);
        menus[(int)stage.GAMELOOP].SetActive(false);
        menus[(int)stage.PAUSEMENU].SetActive(false);
        menus[(int)stage.INGAMEUI].SetActive(false);
        menus[(int)stage.RESTARTMENU].SetActive(false);
        undoButton.SetActive(true);
    }

    public void SetSettingsMenu(bool activated)
    {
        menus[(int)stage.SETTINGSMENU].SetActive(activated);
        menus[(int)stage.MAINMENU].SetActive(false);
        menus[(int)stage.TEAMMENU].SetActive(false);
        menus[(int)stage.GAMELOOP].SetActive(false);
        menus[(int)stage.PAUSEMENU].SetActive(false);
        menus[(int)stage.INGAMEUI].SetActive(false);
        menus[(int)stage.RESTARTMENU].SetActive(false);
        undoButton.SetActive(true);
    }

    public void SetGameLoop(bool activated)
    {
        menus[(int)stage.GAMELOOP].SetActive(activated);
        menus[(int)stage.MAINMENU].SetActive(false);
        menus[(int)stage.TEAMMENU].SetActive(false);
        menus[(int)stage.SETTINGSMENU].SetActive(false);
        menus[(int)stage.PAUSEMENU].SetActive(false);
        menus[(int)stage.INGAMEUI].SetActive(true);
        menus[(int)stage.RESTARTMENU].SetActive(false);
        undoButton.SetActive(false);
        this.GetComponent<LevelGenerator>().ResetGame();
        lastStageActivated = false;
    }

    public void ActivateRestartMenu()
    {
        menus[(int)stage.RESTARTMENU].SetActive(true);
        lastStageActivated = true;
    }

    public void PauseGame(bool pause)
    {
        if (!lastStageActivated) {
            menus[(int)stage.PAUSEMENU].SetActive(pause);
            this.GetComponent<LevelGenerator>().PauseGame(pause);
        }
    }
}



