using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	GameUIManager _gameUIManager;

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
		_gameUIManager.GameEnd();
		_gameUIManager.EndLevelCoinText.text = "Coins: " + _totalCoins.ToString();
		_totalCoins += PlayerPrefs.GetInt("playerCoins", 0);
		PlayerPrefs.SetInt("playerCoins", _totalCoins);
	}

	public void AddCoin(int amount)
	{
		_totalCoins += amount;
		_gameUIManager.CoinsText.text = "Coins: " + _totalCoins.ToString();
	}

}
