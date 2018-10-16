﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    public List<Sprite> frames;
    public float forceBase;
    public float enemiesForceBase;
    public LevelGenerator gameControlRef;
    public Vector3 initPos;
    public AudioClip hitChihuahua;

    private AudioSource source;
    bool flying = false;
    bool activatedCollisions = false;
    // Use this for initialization
    void Start () {
        //initPos = this.transform.position;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (flying)
        {

            if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= 3 && this.transform.position.y < -1)
            {
                this.GetComponent<SpriteRenderer>().sprite = frames[0];
                this.transform.rotation = Quaternion.identity;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                gameControlRef.GetComponent<ScoreManager>().parseScore = false;
                gameControlRef.GetComponent<ScoreManager>().CompareScore();
                activatedCollisions = false;
                flying = false;
                gameControlRef.GetComponent<InterfaceControl>().ActivateRestartMenu();
            }
        }else if (this.GetComponent<Rigidbody2D>().velocity.magnitude <0.1 && this.transform.position.y < -1)
        {
            this.GetComponent<SpriteRenderer>().sprite = frames[0];
            this.transform.rotation = Quaternion.identity;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0;
            gameControlRef.GetComponent<ScoreManager>().parseScore = false;
            flying = false;
            activatedCollisions = false;
            gameControlRef.foot.deactivateInput = false;
            gameControlRef.GetComponent<InterfaceControl>().ActivateRestartMenu();
        }
        //else
        //{
        //    if (this.GetComponent<Rigidbody2D>().velocity.x < 0) flying = true;
        //}
    }

    public void ResetObject()
    {
        this.GetComponent<SpriteRenderer>().sprite = frames[1];
        this.transform.position = initPos;
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        activatedCollisions = true;
        flying = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (activatedCollisions)
        {
            //Debug.Log(this.GetComponent<Rigidbody2D>().velocity.y);
            //if(this.GetComponent<Rigidbody2D>().velocity.y < 0.6) 
            if (col.gameObject.tag == "Shooter")
            {
                source.PlayOneShot(hitChihuahua, 1.0f);
                this.GetComponent<SpriteRenderer>().sprite = frames[1];
                Vector2 dir = new Vector2(this.transform.position.x, this.transform.position.y) - col.contacts[0].point;
                this.GetComponent<Rigidbody2D>().AddForce(dir * forceBase);
                this.GetComponent<Rigidbody2D>().AddTorque(-200);
                gameControlRef.GetComponent<ScoreManager>().parseScore = true;
                gameControlRef.AttachCamera();
                gameControlRef.foot.deactivateInput = false;
                Debug.Log("input deactivated");
                flying = true;
            }
            else if (col.gameObject.tag == "Enemy")
            {
                Vector2 dir = new Vector2(-1, 1).normalized;
                this.GetComponent<Rigidbody2D>().AddForce(dir * enemiesForceBase);
                this.GetComponent<Rigidbody2D>().AddTorque(5.0f);
            }
        }
        
    }

   
}
