using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceControl : MonoBehaviour {

    enum stage
    {
        MAINMENU,
        TEAMMENU,
        SETTINGSMENU,
        GAMELOOP
    }

    public GameObject[] menus;
    public GameObject pauseButton;
    public GameObject undoButton;

    Vector3 scoreGamePos;
    Vector2 scoreGameSize;
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
        pauseButton.SetActive(false);
        undoButton.SetActive(false);
    }

    public void SetTeamMenu(bool activated)
    {
        menus[(int)stage.TEAMMENU].SetActive(activated);
        menus[(int)stage.MAINMENU].SetActive(false);
        menus[(int)stage.SETTINGSMENU].SetActive(false);
        menus[(int)stage.GAMELOOP].SetActive(false);
        pauseButton.SetActive(false);
        undoButton.SetActive(true);
    }

    public void SetSettingsMenu(bool activated)
    {
        menus[(int)stage.SETTINGSMENU].SetActive(activated);
        menus[(int)stage.MAINMENU].SetActive(false);
        menus[(int)stage.TEAMMENU].SetActive(false);
        menus[(int)stage.GAMELOOP].SetActive(false);
        pauseButton.SetActive(false);
        undoButton.SetActive(true);
    }

    public void SetGameLoop(bool activated)
    {
        menus[(int)stage.GAMELOOP].SetActive(activated);
        menus[(int)stage.MAINMENU].SetActive(false);
        menus[(int)stage.TEAMMENU].SetActive(false);
        menus[(int)stage.SETTINGSMENU].SetActive(false);
        pauseButton.SetActive(true);
        undoButton.SetActive(false);
        this.GetComponent<LevelGenerator>().ResetGame();
    }

    //public void FirstPageCharge()
    //{
    //    buttons[(int)stage.FIRSTPAGE].GetComponent<DeactivateButton>().activateSelf(true);
    //    buttons[(int)stage.GAMELOOP].GetComponent<DeactivateButton>().activateSelf(false);
    //    buttons[(int)stage.SCORESCREEN].GetComponent<DeactivateButton>().activateSelf(false);
    //    scoreText.GetComponent<DeactivateButton>().activateSelf(false);
    //    spawnerRef.Reset();
    //    inputHandRef.ActiveGame(false);
    //    SetMainGame(false);
    //    this.gameObject.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
    //}

    //public void GameLoopCharge()
    //{
    //    buttons[(int)stage.FIRSTPAGE].GetComponent<DeactivateButton>().activateSelf(false);
    //    buttons[(int)stage.GAMELOOP].GetComponent<DeactivateButton>().activateSelf(true);
    //    buttons[(int)stage.SCORESCREEN].GetComponent<DeactivateButton>().activateSelf(false);
    //    scoreText.GetComponent<DeactivateButton>().activateSelf(true);
    //    playerRef.RestartPlayer();
    //    scoreText.GetComponent<RectTransform>().position = scoreGamePos;
    //    scoreText.GetComponent<RectTransform>().localScale = scoreGameSize;
    //    inputHandRef.ActiveGame(true);
    //    SetMainGame(true);
    //    this.gameObject.transform.position = new Vector3((Screen.width / 100) * 20, 0.0f, -10.0f);
    //}

    //public void ScooreScreenCharge()
    //{
    //    buttons[(int)stage.FIRSTPAGE].GetComponent<DeactivateButton>().activateSelf(false);
    //    buttons[(int)stage.GAMELOOP].GetComponent<DeactivateButton>().activateSelf(false);
    //    buttons[(int)stage.SCORESCREEN].GetComponent<DeactivateButton>().activateSelf(true);
    //    scoreText.GetComponent<DeactivateButton>().activateSelf(true);
    //    scoreText.GetComponent<RectTransform>().position = new Vector3(Screen.width / 2 + 2.0f, Screen.height / 1.7f, Camera.main.nearClipPlane);
    //    scoreText.GetComponent<RectTransform>().localScale = scoreGameSize * 2f;
    //    inputHandRef.ActiveGame(false);
    //    SetMainGame(false);
    //    this.gameObject.transform.position = new Vector3((Screen.width / 100) * 40, 0.0f, -10.0f);
    //}

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



