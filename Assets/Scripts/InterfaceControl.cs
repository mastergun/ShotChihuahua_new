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
    }

    public void ActivateRestartMenu()
    {
        menus[(int)stage.RESTARTMENU].SetActive(true);
    }

    void SetGameSizeAndPos()
    {
    //    logo.GetComponent<Transform>().localScale = new Vector2((Screen.height / 100) * logo.GetComponent<Transform>().localScale.x, (Screen.height / 100) * logo.GetComponent<Transform>().localScale.y);
    //    for (int i = 0; i < (int)stage.ENUMSIZE; i++)
    //    {
    //        backgrounds[i].GetComponent<Transform>().localScale = new Vector3(Screen.width / 100, Screen.height / 100, 1.0f);
    //        backgrounds[i].GetComponent<Transform>().position = new Vector3((Screen.width / 100) * i * 20, 0.0f, 1.0f);
    //    }
    //    Camera.main.orthographicSize = Screen.height / 100;
    }
}



