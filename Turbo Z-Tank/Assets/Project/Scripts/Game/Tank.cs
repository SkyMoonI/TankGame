using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
	[Header("Base Features")]
	float _baseSpeed = 1.0f;
	float _baseHealth = 100.0f;
	float _baseArmor = 5.0f;

	[Header("Current Features")]
	float _speed;
	float _health;
	float _armor;

	[Header("Upgrades")]
	int _armorLevel = 1;
	int _speedLevel = 1;
	int _healthLevel = 1;

	public float Health => _health;
	public float Speed => _speed;
	public float Armor => _armor;

	// Start is called before the first frame update
	void Start()
	{
		LoadUpgradeLevels();
		// LoadUpgrades();
		SetFeatures();
	}

	// private void LoadUpgrades()
	// {
	// 	_baseHealth = PlayerPrefs.GetFloat("tankHealth", 100.0f);
	// 	_baseSpeed = PlayerPrefs.GetFloat("tankSpeed", 5.0f);
	// 	_baseArmor = PlayerPrefs.GetFloat("tankArmor", 10.0f);
	// }

	void LoadUpgradeLevels()
	{
		_armorLevel = PlayerPrefs.GetInt("armorLevel", 1);
		_speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
		_healthLevel = PlayerPrefs.GetInt("healthLevel", 1);
	}
	public void SetFeatures()
	{
		_armor = _baseArmor * _armorLevel;
		_speed = _baseSpeed * _speedLevel;
		_health = _baseHealth * _healthLevel;

	}

}
