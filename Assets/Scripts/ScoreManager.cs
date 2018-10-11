using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text score;
    public Text mainMenuMaxScore;
    float MaxScore;
    float currentScore;
    float initPoint;
    bool firstTimeGame = false;
    public bool parseScore = false;
	// Use this for initialization

	void Start () {
        LoadGame();
        initPoint = this.GetComponent<LevelGenerator>().chihuahuaRef.transform.position.x;
        currentScore = 0;
        if (!firstTimeGame) MaxScore = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (parseScore)
        {
            currentScore = -(this.GetComponent<LevelGenerator>().chihuahuaRef.transform.position.x + initPoint);
            score.text = currentScore.ToString("F1") + "m";
        }
	}
    
    void SetMaxScore(float score)
    {
        MaxScore = score;
        firstTimeGame = true;
        mainMenuMaxScore.text = MaxScore.ToString("F1") + "m";
        SaveGame();
    }

    public void CompareScore()
    {
        if (currentScore > MaxScore) SetMaxScore(currentScore); 
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
        score.text = currentScore.ToString();
        parseScore = false;
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.MaxScore = MaxScore;
        save.firstTimeGame = firstTimeGame;
        return save;
    }

    public void SaveGame()
    {
        // create a save data
        Save save = CreateSaveGameObject();

        // create save file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        //reset variable if you need

        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        // search if exist a save file
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // load file data
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // set variables
            MaxScore = save.MaxScore;
            SetMaxScore(MaxScore);
            firstTimeGame = save.firstTimeGame;
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
