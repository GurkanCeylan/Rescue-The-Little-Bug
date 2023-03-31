using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADBanner : MonoBehaviour
{
    public static ADBanner Instance;
    private BannerView bannerAd;
    string bannerAdID = "ca-app-pub-2471083137131993/3037434093";

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        this.RequestBanner();
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        this.bannerAd = new BannerView(bannerAdID, AdSize.SmartBanner, AdPosition.Top);
        this.bannerAd.LoadAd(this.CreateAdRequest());
    }

  

}
