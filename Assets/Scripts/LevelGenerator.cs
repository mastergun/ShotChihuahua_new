using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    enum STAGE
    {
        GROUND,
        CITY,
        SKY,
        GALAXY
    }

    //public methods
    public GameObject groundPrefab;
    public List<GameObject> cityPrefabs;
    public List<GameObject> skyPrefabs;
    public GameObject galaxyPrefab;

    public GameObject chihuahuaRef;
    public GameObject cameraActor;
    public Shooter foot;
    public Vector2 groundScale;
    public float maxDistSpawn;
    bool restartingGame = false;
    bool atachedCamera = false;
    Vector3 dinamicCameraPos = Vector3.zero;
    
    //private methods
    List<GameObject> groundsInGame;
    List<GameObject> citiesInGame;
    List<GameObject> skiesInGame;
    List<GameObject> galaxiesInGame;
    Vector3 cameraInitPos;
    int backgroundIndex = 1;

	// Use this for initialization
	void Start () {
        groundsInGame = new List<GameObject>();
        citiesInGame = new List<GameObject>();
        skiesInGame = new List<GameObject>();
        galaxiesInGame = new List<GameObject>();
        cameraInitPos = cameraActor.transform.position;
        //ResetGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (!restartingGame)
        {
            if (groundsInGame.Count != 0)
            {
                float dist = groundsInGame[groundsInGame.Count - 1].transform.position.x
                         - chihuahuaRef.transform.position.x;
                if (dist > maxDistSpawn)
                {
                    AddBackground(Random.Range(1,3),0,STAGE.GROUND);
                }
            }
        }
        if (atachedCamera)
        {
            SetCameraPos();
        }
        
        
	}

    void AddBackground(int numOfEnemies,float parentPosX, STAGE stage)
    {
        //groundsInGame.Add(InicializeGround(numOfEnemies));

        if (stage == STAGE.GROUND) groundsInGame.Add(InicializeGround(numOfEnemies));
        else if (stage == STAGE.CITY) citiesInGame.Add(InicializeBackGround(parentPosX, stage));
        else if (stage == STAGE.SKY) skiesInGame.Add(InicializeBackGround(parentPosX, stage));
        else if (stage == STAGE.GALAXY) galaxiesInGame.Add(InicializeBackGround(parentPosX, stage));
    }

    public void RemoveGround(GameObject ground, int type)
    {
        Destroy(ground);
        if (type == (int)STAGE.GROUND) groundsInGame.Remove(ground);
        else if (type == (int)STAGE.CITY)citiesInGame.Remove(ground);
        else if (type == (int)STAGE.SKY) skiesInGame.Remove(ground);
        else if (type == (int)STAGE.GALAXY) galaxiesInGame.Remove(ground);
    }


    GameObject InicializeGround(int numOfEnemies)
    {
        GameObject bg;
        float xPos = 0.0f;
        //set a new condition of spawning 
        if (groundsInGame.Count == 0)
        {
            bg = (GameObject)Instantiate(groundPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 1),transform.rotation);
        }
        else
        {
            xPos = groundsInGame[groundsInGame.Count-1].transform.position.x - (groundScale.x);
            bg = (GameObject)Instantiate(groundPrefab,new Vector3(xPos, this.transform.position.y,1), transform.rotation);
        }
        bg.GetComponent<Transform>().localScale = new Vector2(groundScale.x, groundScale.y);
        bg.GetComponent<AutoDestroy>().numOfEnemies = numOfEnemies;
        bg.GetComponent<AutoDestroy>().levelRef = this;
        AddBackground(0,xPos, STAGE.CITY);
        return bg;
    }

    GameObject InicializeBackGround(float groundPosX, STAGE stage)
    {
        GameObject bg;
        GameObject prefab;

        //set prefab
        Debug.Log((backgroundIndex % cityPrefabs.Count));
        if (stage == STAGE.CITY) prefab = cityPrefabs[(backgroundIndex % cityPrefabs.Count)];
        else if (stage == STAGE.SKY) prefab = skyPrefabs[(backgroundIndex % cityPrefabs.Count)];
        else prefab = galaxyPrefab;

        float xPos = groundPosX;
        float yPos = this.transform.position.y + groundScale.x/2 - groundScale.y;

        if (stage == STAGE.SKY) yPos += 52;
        if (stage == STAGE.GALAXY) yPos += 104;

        bg = (GameObject)Instantiate(prefab, new Vector3(xPos, yPos, 2.0f), transform.rotation);
        bg.GetComponent<AutoDestroy>().numOfEnemies = 0;
        bg.GetComponent<AutoDestroy>().levelRef = this;

        if (stage == STAGE.CITY) AddBackground(0, xPos, STAGE.SKY);
        if (stage == STAGE.SKY)
        {
            AddBackground(0, xPos, STAGE.GALAXY);
            backgroundIndex++;
        }
        return bg;
    }

    public void ResetGame()
    {

        restartingGame = true;
        DettachCamera();
        
        chihuahuaRef.GetComponent<ObjectMovement>().ResetObject();
        chihuahuaRef.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1) * 4000);
       
        ResetBackground();
        backgroundIndex = 1;
        AddBackground(0,0,STAGE.GROUND);
        AddBackground(0,0, STAGE.GROUND);
        AddBackground(0,0, STAGE.GROUND);
        //foot.ResetAnim();
        foot.ResetState();
        restartingGame = false;
    }

    void ResetBackground()
    {
        
        if (groundsInGame.Count != 0)
        {
            for (int i = 0; i < groundsInGame.Count; i++)
            {
                groundsInGame[i].GetComponent<AutoDestroy>().RemoveItems();
                Destroy(groundsInGame[i]);
            }
        }
        groundsInGame.Clear();
        if (citiesInGame.Count != 0)
        {
            for (int i = 0; i < citiesInGame.Count; i++)
            {
                citiesInGame[i].GetComponent<AutoDestroy>().RemoveItems();
                Destroy(citiesInGame[i]);
            }
        }
        citiesInGame.Clear();
        if (skiesInGame.Count != 0)
        {
            for (int i = 0; i < skiesInGame.Count; i++)
            {
                skiesInGame[i].GetComponent<AutoDestroy>().RemoveItems();
                Destroy(skiesInGame[i]);
            }
        }
        skiesInGame.Clear();
        if (galaxiesInGame.Count != 0)
        {
            for (int i = 0; i < galaxiesInGame.Count; i++)
            {
                galaxiesInGame[i].GetComponent<AutoDestroy>().RemoveItems();
                Destroy(galaxiesInGame[i]);
            }
        }
        galaxiesInGame.Clear();
    }
    public void AttachCamera()
    {
        atachedCamera = true;
        //cameraActor.transform.parent = chihuahuaRef.transform;
        //camera.transform.localPosition = chihuahuaRef.transform.localPosition;
    }

    public void DettachCamera()
    {
        //cameraActor.transform.parent = null;
        atachedCamera = false;
        cameraActor.transform.position = cameraInitPos;
    }

    void SetCameraPos()
    {
        dinamicCameraPos.x = chihuahuaRef.transform.position.x;
        if (chihuahuaRef.transform.position.y <= cameraInitPos.y) dinamicCameraPos.y = cameraInitPos.y;
        else dinamicCameraPos.y = chihuahuaRef.transform.position.y;
        dinamicCameraPos.z = cameraActor.transform.position.z;
        cameraActor.transform.position = dinamicCameraPos;
    }

    public void PauseGame(bool pause)
    {
        if (pause && Time.timeScale == 1.0) Time.timeScale = 0.0f;
        else if (!pause && Time.timeScale == 0.0) Time.timeScale = 1.0f;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
