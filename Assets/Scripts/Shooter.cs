using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    bool pressed = false;
    public bool deactivateInput = false;
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
            } 
        }
    }

    public void ResetAnim(){
        this.GetComponent<Animator>().SetBool("shot", false);
    }

    public void ResetState() {
        pressed = false;
        deactivateInput = true;
    }
}
