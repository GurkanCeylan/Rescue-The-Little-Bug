using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    public static ADManager Instance;
    private RewardedAd rewardedAd;
    string rewardedAdID = "ca-app-pub-2471083137131993/4074108195";
    public bool isRewarded = false;

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
        RequestRewardedAd();
    }

    private void Update() 
    {
        if (isRewarded)
        {
            GameManager.Instance.ReviveUsed();
        }  
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
    
    public void RequestRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardedAdID);
        this.rewardedAd.OnUserEarnedReward += HandleRewardAdRewarded;
        rewardedAd.LoadAd(CreateAdRequest());
    }

    public void HandleRewardAdRewarded(object sender, Reward args)
    {
        if (isRewarded)
        {
            GameManager.Instance.RevivePlayer();
        }

        print("Reward given to the player");
    }

     public void HandleRewardAdClosed(object sender, Reward args)
    {
       RequestRewardedAd();
    }
  
    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        
        RequestRewardedAd();
        isRewarded = true;
    }

}
