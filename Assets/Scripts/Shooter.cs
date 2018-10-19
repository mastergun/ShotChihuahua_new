using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour {
    bool pressed = false;
    public bool deactivateInput = true;
    public GameObject chihuahuaRef;
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && deactivateInput)
        {
            if (!pressed)
            {
                pressed = true;
                this.GetComponent<Animator>().SetBool("shot", true);
                chihuahuaRef.GetComponent<ObjectMovement>().ActivateVelocimeter(false);
            }
        }
    }

    public void ResetAnim(){
        this.GetComponent<Animator>().SetBool("shot", false);
        chihuahuaRef.GetComponent<ObjectMovement>().ActivateVelocimeter(true);
        pressed = false;
    }

    public void ResetState() {
        pressed = false;
        deactivateInput = true;
    }
}
