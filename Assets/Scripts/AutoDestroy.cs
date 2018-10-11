using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public LevelGenerator levelRef;
    public float maxDistDestroy;
    public GameObject enemiePrefab;
    List<GameObject> enemies;
    public int numOfEnemies = 0;
    // Use this for initialization
    void Start () {
        enemies = new List<GameObject>();
        //numOfEnemies = nEnemies;
        for (int i = 0; i < numOfEnemies; i++)
        {
            enemies.Add(InicializeEnemy());
        }
	}
	
	// Update is called once per frame
	void Update () {
        float dist = levelRef.chihuahuaRef.transform.position.x - this.transform.position.x;
        if (dist < maxDistDestroy)
        {
            RemoveGroundAndItems();
        }
    }

    GameObject InicializeEnemy()
    {
        GameObject enemy;
        float xPos = 0.0f;
        xPos = (this.transform.position.x - this.transform.localScale.x/2) + Random.Range(0, this.transform.localScale.x);
        enemy = (GameObject)Instantiate(enemiePrefab, new Vector2(xPos, -3), transform.rotation);
        return enemy;
    }

    public void RemoveGroundAndItems()
    {
        if (enemies.Count != 0)
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
        
        enemies.Clear();
        levelRef.RemoveGround(this.gameObject);
        
        //levelRef.RemoveGround(this.gameObject);
    }

    public void RemoveItems()
    {
        if (enemies.Count != 0)
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }

        enemies.Clear();
    }
}
