using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    //public methods
    public GameObject groundPrefab;
    public GameObject chihuahuaRef;
    public GameObject camera;
    public Vector2 groundScale;
    public float maxDistSpawn;
    
    //private methods
    List<GameObject> groundsInGame;
    Vector3 cameraInitPos;

	// Use this for initialization
	void Start () {
        groundsInGame = new List<GameObject>();
        cameraInitPos = camera.transform.position;
        //ResetGame();
    }
	
	// Update is called once per frame
	void Update () {
        float dist = groundsInGame[groundsInGame.Count-1].transform.position.x 
                     - chihuahuaRef.transform.position.x;
        if (dist > maxDistSpawn)
        {
            AddGround();
        }
	}

    void AddGround()
    {
        groundsInGame.Add(InicializeGround());
    }

    public void RemoveGround(GameObject ground)
    {
        Destroy(ground);
        groundsInGame.Remove(ground);
    }

    GameObject InicializeGround()
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
        ground.GetComponent<AutoDestroy>().levelRef = this;
        return ground;
    }

    public void ResetGame()
    {
        DettachCamera();
        chihuahuaRef.GetComponent<ObjectMovement>().ResetObject();
        if (groundsInGame.Count != 0)
        {
            foreach (GameObject grounds in groundsInGame)
            {
                Destroy(grounds);
            }
        }
        groundsInGame.Clear();
        AddGround();
        AddGround();
        AddGround();
        //myGameObject.transform.parent = wallGameObject.transform;
        //myGameObject.transform.localPosition = wallGameObject.GetComponent<PositionReferences>().GetNextPosition();
    }
    public void AttachCamera()
    {
        camera.transform.parent = chihuahuaRef.transform;
        //camera.transform.localPosition = chihuahuaRef.transform.localPosition;
    }

    public void DettachCamera()
    {
        camera.transform.parent = null;
        camera.transform.position = cameraInitPos;
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
