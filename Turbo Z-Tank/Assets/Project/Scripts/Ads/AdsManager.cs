using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
	public static AdsManager Instance { get; private set; }
	public AdsInitializer _adsInitializer;
	public InterstitialAds _interstitialAds;
	public BannerAds _bannerAds;
	public RewardedAds _rewardedAds;


	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		_interstitialAds.LoadAd();
		_bannerAds.LoadAd();
		_rewardedAds.LoadAd();
	}
}
