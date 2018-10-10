using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateButton : MonoBehaviour {

    // Use this for initialization
    public GameObject button;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activateButton()
    {
        button.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void activateSelf(bool activate)
    {
        this.gameObject.SetActive(activate);
    }
}
