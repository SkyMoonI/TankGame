using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum UpgradeType
{
	Cannon,
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
	int _cannonLevel = 1;
	int _armorLevel = 1;
	int _speedLevel = 1;
	int _healthLevel = 1;
	int _maxUpgradeLevel = 5;

	[Header("Costs")]
	int _cannonUpgradeCost = 200;
	int _armorUpgradeCost = 150;
	int _speedUpgradeCost = 100;
	int _healthUpgradeCost = 150;

	[Header("Buttons")]
	[SerializeField] Button _cannonUpgradeButton;
	[SerializeField] Button _armorUpgradeButton;
	[SerializeField] Button _speedUpgradeButton;
	[SerializeField] Button _healthUpgradeButton;

	[Header("Sliders")]
	[SerializeField] Slider _cannonSlider;
	[SerializeField] Slider _armorSlider;
	[SerializeField] Slider _speedSlider;
	[SerializeField] Slider _healthSlider;

	// Start is called before the first frame update
	void Start()
	{
		UpdateUI();
		LoadUpgradeLevels();
		_cannonUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Cannon));
		_armorUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Armor));
		_speedUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Speed));
		_healthUpgradeButton.onClick.AddListener(() => UpgradePower(UpgradeType.Health));

		_cannonSlider.maxValue = _maxUpgradeLevel;
		_armorSlider.maxValue = _maxUpgradeLevel;
		_speedSlider.maxValue = _maxUpgradeLevel;
		_healthSlider.maxValue = _maxUpgradeLevel;
	}

	void UpdateUI()
	{
		_coinsText.text = "Coins: " + _playerCoins.ToString();

		_cannonSlider.value = _cannonLevel;
		_armorSlider.value = _armorLevel;
		_speedSlider.value = _speedLevel;
		_healthSlider.value = _healthLevel;
	}

	void UpgradePower(UpgradeType upgradeType)
	{
		switch (upgradeType)
		{
			case UpgradeType.Cannon:
				if (_playerCoins >= _cannonUpgradeCost * _cannonLevel && _cannonLevel <= _maxUpgradeLevel)
				{
					_playerCoins -= _cannonUpgradeCost * _cannonLevel;
					_cannonLevel++;
					_cannonUpgradeCost *= 2;
					UpdateUI();
					SaveUpgradeLevels();
				}
				break;
			case UpgradeType.Armor:
				if (_playerCoins >= _armorUpgradeCost * _armorLevel && _armorLevel <= _maxUpgradeLevel)
				{

					_playerCoins -= _armorUpgradeCost * _armorLevel;
					_armorLevel++;
					_armorUpgradeCost *= 2;
					UpdateUI();
					SaveUpgradeLevels();
				}
				break;
			case UpgradeType.Speed:
				if (_playerCoins >= _speedUpgradeCost * _speedLevel && _speedLevel <= _maxUpgradeLevel)
				{

					_playerCoins -= _speedUpgradeCost * _speedLevel;
					_speedLevel++;
					_speedUpgradeCost *= 2;
					UpdateUI();
					SaveUpgradeLevels();
				}
				break;
			case UpgradeType.Health:
				if (_playerCoins >= _healthUpgradeCost * _healthLevel && _healthLevel <= _maxUpgradeLevel)
				{

					_playerCoins -= _healthUpgradeCost * _healthLevel;
					_healthLevel++;
					_healthUpgradeCost *= 2;
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
		PlayerPrefs.SetInt("cannonLevel", _cannonLevel);
		PlayerPrefs.SetInt("armorLevel", _armorLevel);
		PlayerPrefs.SetInt("speedLevel", _speedLevel);
		PlayerPrefs.SetInt("healthLevel", _healthLevel);
		PlayerPrefs.SetInt("playerCoins", _playerCoins);
	}

	void LoadUpgradeLevels()
	{
		_cannonLevel = PlayerPrefs.GetInt("cannonLevel", 1);
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
