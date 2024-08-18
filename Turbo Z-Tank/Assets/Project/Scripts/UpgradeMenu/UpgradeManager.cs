using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum UpgradeType
{
	Armor,
	Speed,
	Health
}
public class UpgradeManager : MonoBehaviour
{

	[Header("Coin")]
	int _playerCoins = 0;
	[SerializeField] TextMeshProUGUI _coinsText;

	[Header("Upgrades")]
	int _armorLevel = 1;
	int _speedLevel = 1;
	int _healthLevel = 1;
	int _maxUpgradeLevel = 10;

	[Header("Costs")]
	int _armorUpgradeCost = 150;
	int _speedUpgradeCost = 100;
	int _healthUpgradeCost = 150;

	[Header("Buttons")]
	[SerializeField] Button _armorUpgradeButton;
	[SerializeField] Button _speedUpgradeButton;
	[SerializeField] Button _healthUpgradeButton;

	[Header("Sliders")]
	[SerializeField] Slider _armorSlider;
	[SerializeField] Slider _speedSlider;
	[SerializeField] Slider _healthSlider;

	[SerializeField] TextMeshProUGUI _armorCoinsText;
	[SerializeField] TextMeshProUGUI _speedCoinsText;
	[SerializeField] TextMeshProUGUI _healthCoinsText;

	// Start is called before the first frame update
	void Start()
	{
		LoadUpgradeLevels();
		UpdateUI();
		_armorUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Armor));
		_speedUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Speed));
		_healthUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Health));

		_armorSlider.maxValue = _maxUpgradeLevel;
		_speedSlider.maxValue = _maxUpgradeLevel;
		_healthSlider.maxValue = _maxUpgradeLevel;
	}

	void UpdateUI()
	{
		_coinsText.text = "Coins: " + _playerCoins.ToString();

		_armorSlider.value = _armorLevel;
		_speedSlider.value = _speedLevel;
		_healthSlider.value = _healthLevel;

		_armorCoinsText.text = "ARMOR: " + (_armorUpgradeCost * _armorLevel * 2).ToString();
		_speedCoinsText.text = "SPEED: " + (_speedUpgradeCost * _speedLevel * 2).ToString();
		_healthCoinsText.text = "HEALTH: " + (_healthUpgradeCost * _healthLevel * 2).ToString();
	}

	void UpgradePower(UpgradeType upgradeType)
	{
		switch (upgradeType)
		{
			case UpgradeType.Armor:
				if (_playerCoins >= _armorUpgradeCost * _armorLevel * 2 && _armorLevel <= _maxUpgradeLevel)
				{
					_playerCoins -= _armorUpgradeCost * _armorLevel * 2;
					_armorLevel++;
					UpdateUI();
					SaveUpgradeLevels();
				}
				break;
			case UpgradeType.Speed:
				if (_playerCoins >= _speedUpgradeCost * _speedLevel * 2 && _speedLevel <= _maxUpgradeLevel)
				{
					_playerCoins -= _speedUpgradeCost * _speedLevel * 2;
					_speedLevel++;
					UpdateUI();
					SaveUpgradeLevels();
				}
				break;
			case UpgradeType.Health:
				if (_playerCoins >= _healthUpgradeCost * _healthLevel * 2 && _healthLevel <= _maxUpgradeLevel)
				{
					_playerCoins -= _healthUpgradeCost * _healthLevel * 2;
					_healthLevel++;
					UpdateUI();
					SaveUpgradeLevels();
				}
				break;
			default:
				break;
		}
	}

	void SaveUpgradeLevels()
	{
		PlayerPrefs.SetInt("armorLevel", _armorLevel);
		PlayerPrefs.SetInt("speedLevel", _speedLevel);
		PlayerPrefs.SetInt("healthLevel", _healthLevel);
		PlayerPrefs.SetInt("playerCoins", _playerCoins);
	}

	void LoadUpgradeLevels()
	{
		_armorLevel = PlayerPrefs.GetInt("armorLevel", 1);
		_speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
		_healthLevel = PlayerPrefs.GetInt("healthLevel", 1);
		_playerCoins = PlayerPrefs.GetInt("playerCoins", 0);
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	public void BackToLevelSelection()
	{
		SceneManager.LoadScene("LevelSelectScene");
	}
}
