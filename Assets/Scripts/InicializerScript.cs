using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class InicializerScript : MonoBehaviour {

    private BannerView bannerView;
    private InterstitialAd interstitial;
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
    public void ShowBanner()
    {
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-8875687836686988/1453020698";
        #elif UNITY_IPHONE
              string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
          string adUnitId = "unexpected_platform";
        #endif

        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        //AdRequest request = new AdRequest.Builder()
        //.AddTestDevice(AdRequest.TestDeviceSimulator)
        //.AddTestDevice("ca-app-pub-3940256099942544/6300978111")
        //.Build();
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        
        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

        // Load the banner with the request.
        bannerView.LoadAd(request);
        
        // Called when an ad request has successfully loaded.
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    #endregion
}
