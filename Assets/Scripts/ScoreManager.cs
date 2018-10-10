using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        mainMenuMaxScore.text = MaxScore.ToString("F1") + "m";
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
}
