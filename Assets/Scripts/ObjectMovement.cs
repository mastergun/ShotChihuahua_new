using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public float forceBase;
    public LevelGenerator gameControlRef;
    public Vector3 initPos;
    // Use this for initialization
    void Start () {
        //initPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetObject()
    {
        this.transform.position = initPos;
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Shooter")
        {   
            Vector2 dir= new Vector2(this.transform.position.x, this.transform.position.y) - col.contacts[0].point;
            this.GetComponent<Rigidbody2D>().AddForce(dir * forceBase);
            gameControlRef.AttachCamera();
        }else if(col.gameObject.tag == "Enemy")
        {
            Vector2 dir = new Vector2(-1,1);
            this.GetComponent<Rigidbody2D>().AddForce(dir * forceBase);
        }
    }

   
}
