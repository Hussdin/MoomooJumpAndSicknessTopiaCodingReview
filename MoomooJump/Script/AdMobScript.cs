using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{

    #if UNITY_ANDROID
    string App_ID = "ca-app-pub-7318907042461228~7278581725";
    string Banner_Ad_ID = "ca-app-pub-7318907042461228/6420723214";
    string Interstitial_Ad_ID = "ca-app-pub-7318907042461228/4967492007";
    string Reward_Ad_ID = "ca-app-pub-7318907042461228/5989763786";

    #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
                string adUnitId = "unexpected_platform";
    #endif


    BannerView bannerView;
    private RewardedAd shopRewardedAds;
    private RewardedAd gameOverRewardedAds;

    public static AdMobScript instance;
    PlayAgainPanel Playad;

    private InterstitialAd interstitial;


    private void Awake()
    {
        instance = this;
        Playad = PlayAgainPanel.instance;
    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();

        this.RequestInterstitial();


        shopRewardedAds = CreateAndLoadRewardedAds(Reward_Ad_ID);
        gameOverRewardedAds = CreateAndLoadRewardedAds(Reward_Ad_ID);
    }

    private void RequestBanner()
    {
        this.bannerView = new BannerView(Banner_Ad_ID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        if (PlayerPrefs.GetString("RemoveAds") != "Purchases")
        {
            this.bannerView.LoadAd(request);
        }
    }

    public RewardedAd CreateAndLoadRewardedAds(string Reward_Ad_ID)
    {

        RewardedAd rewardedAd = new RewardedAd(Reward_Ad_ID);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
        return rewardedAd;
    }


    public void UserChoseToWatchGameOverRewardAds() 
    {
        if (gameOverRewardedAds.IsLoaded())
        {
            gameOverRewardedAds.Show();
        }
    }
    public void UserChoseToWatchShoprRewardAds()
    {
        if (shopRewardedAds.IsLoaded())
        {
            shopRewardedAds.Show();
        }
    }

    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_Ad_ID);


        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    public void showInterstitialAds() 
    {
        if (PlayerPrefs.GetString("RemoveAds") != "Purchases")
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        }
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Ads Loaded");
    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Ads Failed to Load");
    }
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        Time.timeScale = 0;
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Time.timeScale = 1;

    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLeavingApplication event received");
    }

    //RewardAds
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("RewardedAdOpening");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.Log("HandleRewardedAdFailedToShow");
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Debug.Log("RewardedAdClosed");

    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Playad.revive();
    }


}
