using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
	public static LevelComplete Instance { get; private set; }
	int _completionCoinReward = 25;
	int _level;
	public int Level { get { return _level; } }

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
	public void CompleteLevel()
	{
		GameManager.Instance.AddCoin(_completionCoinReward * _level);
		PlayerPrefs.SetInt("Level" + Level + "Completed", 1);

	}

	public void SetLevel(int level)
	{
		_level = level;
	}
}
