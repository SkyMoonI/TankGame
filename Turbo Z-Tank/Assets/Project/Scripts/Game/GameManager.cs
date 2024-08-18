using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	GameUIManager _gameUIManager;

	// ads
	int _gamePlayed = 0;
	bool _isRewarded = false;
	public bool IsRewarded { get { return _isRewarded; } set { _isRewarded = value; } }

	// game state
	bool _isDead = false;
	public bool IsDead { get { return _isDead; } set { _isDead = value; } }
	bool _isWin = false;
	public bool IsWin { get { return _isWin; } set { _isWin = value; } }

	int _totalCoins = 0;
	public int TotalCoins { get { return _totalCoins; } set { _totalCoins = value; } }

	void Awake()
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

		StartCoroutine(DisplayBannerWithDelay());
	}
	IEnumerator DisplayBannerWithDelay()
	{
		yield return new WaitForSeconds(1.0f);
		AdsManager.Instance._bannerAds.ShowAd();
	}

	public void NewGameStart()
	{
		_isDead = false;
		_isWin = false;
		_totalCoins = 0;
		_gameUIManager = GameObject.Find("UIManager").GetComponent<GameUIManager>();
		_gameUIManager.CoinsText.text = "Coins: " + _totalCoins.ToString();
	}
	public void TriggerGameEnd()
	{
		StartCoroutine(GameEnd());
	}
	IEnumerator GameEnd()
	{
		yield return new WaitForSeconds(1.0f);
		if (_isWin)
		{
			LevelComplete.Instance.CompleteLevel();
		}

		// Show intersitialads
		_gamePlayed++;
		if (_gamePlayed % 3 == 0)
		{
			AdsManager.Instance._interstitialAds.ShowAd();
		}

		AdsManager.Instance._bannerAds.HideAd();

		// rewarded ads restart
		_isRewarded = false;

		//Game End
		AudioManager.Instance.MusicSource.Stop();
		_gameUIManager.GameEnd();
		_gameUIManager.EndLevelCoinText.text = "Coins: " + _totalCoins.ToString();
		int finalCoins = PlayerPrefs.GetInt("playerCoins", 0) + _totalCoins;
		PlayerPrefs.SetInt("playerCoins", finalCoins);
	}

	public void AddCoin(int amount)
	{
		if (_isRewarded)
		{
			_totalCoins += amount * 2;
		}
		else
		{
			_totalCoins += amount;

		}
		_gameUIManager.CoinsText.text = "Coins: " + _totalCoins.ToString();
	}

}
