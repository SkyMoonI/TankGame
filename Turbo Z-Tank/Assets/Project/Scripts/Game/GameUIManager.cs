using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GameUIManager : MonoBehaviour
{
	[Header("Game UI")]
	[SerializeField] TextMeshProUGUI _healthText;
	[SerializeField] TextMeshProUGUI _speedText;
	[SerializeField] TextMeshProUGUI _coinsText;
	public TextMeshProUGUI CoinsText { get { return _coinsText; } set { _coinsText = value; } }

	[Header("Game End Panel")]
	[SerializeField] GameObject _gameEndPanel;
	[SerializeField] TextMeshProUGUI _levelCompletedText;
	[SerializeField] TextMeshProUGUI _gameoverText;
	[SerializeField] TextMeshProUGUI _endLevelCoinText;
	public TextMeshProUGUI EndLevelCoinText { get { return _endLevelCoinText; } set { _endLevelCoinText = value; } }

	PlayerController _player;
	// Start is called before the first frame update
	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();

		_coinsText.text = "Coins: " + PlayerPrefs.GetInt("coins", 0).ToString();
		GameManager.Instance.NewGameStart();
	}

	// Update is called once per frame
	void Update()
	{
		_healthText.text = "Health: " + _player.CurrentHealth.ToString();
		_speedText.text = "Speed: " + _player.CurrentSpeed.ToString();
	}

	public void GameEnd()
	{
		_gameEndPanel.SetActive(true);

		if (GameManager.Instance.IsWin)
		{
			_levelCompletedText.gameObject.SetActive(true);
			_gameoverText.gameObject.SetActive(false);

		}
		if (GameManager.Instance.IsDead)
		{
			_levelCompletedText.gameObject.SetActive(false);
			_gameoverText.gameObject.SetActive(true);
		}
	}

	public void RetryLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SelectLevel()
	{
		// Load the next level based on your level management logic
		SceneManager.LoadScene("LevelSelectScene");
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}


}
