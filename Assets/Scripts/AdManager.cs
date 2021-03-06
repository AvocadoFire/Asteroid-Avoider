using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour

#if UNITY_ANDROID || UNITY_IOS
, IUnityAdsListener
#endif

{
#if UNITY_ANDROID || UNITY_IOS
    [SerializeField] private bool testMode = true;

    public static AdManager Instance;

#if UNITY_ANDROID
    private string gameId = "4372035";
#elif UNITY_IOS
    private string gameId = "4372034";
#endif

    private GameOverHandler gameOverHandler;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
       else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            //advertisement will call these methods when they should get called
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Unity Ads Error: " + message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
                break;
            case ShowResult.Skipped:
                //Ad was skipped
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Unity Ads Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }
#endif
}
