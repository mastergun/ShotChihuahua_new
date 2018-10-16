using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class NewBehaviourScript1 : MonoBehaviour {

    // Use this for initialization
    public void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-8875687836686988~5528390280";
        //#elif UNITY_IPHONE
        //    string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
