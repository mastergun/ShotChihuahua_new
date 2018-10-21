using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBackground : MonoBehaviour {
    Vector2 offset = Vector2.zero;
    public float speed = 2f;
    public Vector3 initPos;
    public GameObject FlyingObjectRef;
	// Use this for initialization
	void Start () {
        this.transform.position = initPos;
	}
	
	// Update is called once per frame
	void Update () {
        offset.x = (offset.x - speed * Time.deltaTime) % 1;
        if (offset.x < -0.5f) offset.x += 0.5f;
        this.GetComponent<SpriteRenderer>().material.mainTextureOffset = offset;
        
        Vector3 newPos = Vector3.zero;
        if (FlyingObjectRef.transform.position.y > initPos.y) newPos.y = FlyingObjectRef.transform.position.y;
        else newPos.y = initPos.y;
        newPos.x = FlyingObjectRef.transform.position.x;
        newPos.z = initPos.z;
        this.transform.position = newPos;
    }
}
