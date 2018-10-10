using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    bool pressed = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!pressed)
            {

                pressed = true;
                this.GetComponent<Animator>().SetBool("shot", true);
            } 
        }
    }

    public void ResetAnim(){
        pressed = false;
        this.GetComponent<Animator>().SetBool("shot", false);
    }
}
