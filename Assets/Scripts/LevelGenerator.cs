using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    //public methods
    public GameObject groundPrefab;
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
    Vector3 cameraInitPos;

	// Use this for initialization
	void Start () {
        groundsInGame = new List<GameObject>();
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
                    AddGround(Random.Range(1,3));
                }
            }
        }
        if (atachedCamera)
        {
            SetCameraPos();
        }
        
        
	}

    void AddGround(int numOfEnemies)
    {
        groundsInGame.Add(InicializeGround(numOfEnemies));
    }

    public void RemoveGround(GameObject ground)
    {
        Destroy(ground);
        groundsInGame.Remove(ground);
    }

    GameObject InicializeGround(int numOfEnemies)
    {
        GameObject ground;
        float xPos = 0.0f;
        if (groundsInGame.Count == 0)
        {
            ground = (GameObject)Instantiate(groundPrefab, new Vector2(this.transform.position.x, this.transform.position.y),transform.rotation);
        }
        else
        {
            xPos = groundsInGame[groundsInGame.Count-1].transform.position.x - (groundScale.x);
            ground = (GameObject)Instantiate(groundPrefab,new Vector2(xPos, this.transform.position.y), transform.rotation);
        }
        ground.GetComponent<Transform>().localScale = new Vector2(groundScale.x, groundScale.y);
        ground.GetComponent<AutoDestroy>().numOfEnemies = numOfEnemies;
        ground.GetComponent<AutoDestroy>().levelRef = this;
        return ground;
    }

    public void ResetGame()
    {

        restartingGame = true;
        DettachCamera();
        chihuahuaRef.GetComponent<ObjectMovement>().ResetObject();
        chihuahuaRef.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1) * 4000);
        if (groundsInGame.Count != 0)
        {
            for(int i = 0; i < groundsInGame.Count; i++)
            {
                groundsInGame[i].GetComponent<AutoDestroy>().RemoveItems();
                Destroy(groundsInGame[i]);
            }
        }
        groundsInGame.Clear();
        AddGround(0);
        AddGround(0);
        AddGround(0);
        //foot.ResetAnim();
        foot.ResetState();
        restartingGame = false;
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
