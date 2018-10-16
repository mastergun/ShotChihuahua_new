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
    bool menusInPause = false;
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
        menusInPause = false;
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
        menusInPause = false;
    }

    public void ActivateRestartMenu()
    {
        menus[(int)stage.RESTARTMENU].SetActive(true);
    }

    public void PauseGame(bool pause)
    {
        menus[(int)stage.PAUSEMENU].SetActive(true);
        if (pause)
        {
            if (menus[(int)stage.RESTARTMENU].activeInHierarchy)
            {
                menusInPause = true;
            }
        }
        else
        {
            menus[(int)stage.PAUSEMENU].SetActive(false);
            if (menusInPause)
            {
                menus[(int)stage.RESTARTMENU].SetActive(true);
            }
            menusInPause = false;
        }
    }  
}



