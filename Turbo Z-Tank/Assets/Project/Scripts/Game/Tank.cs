using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
	float _speed = 5.0f;
	float _weaponDamage = 20.0f;
	float _health = 100.0f;
	float _armor = 10.0f;

	[Header("Upgrades")]
	int _cannonLevel = 1;
	int _armorLevel = 1;
	int _speedLevel = 1;
	int _healthLevel = 1;
	int _maxUpgradeLevel = 5;

	public float Health => _health;
	public float Speed => _speed;
	public float Armor => _armor;
	public float WeaponDamage => _weaponDamage;

	// Start is called before the first frame update
	void Start()
	{
		LoadUpgradeLevels();
		LoadUpgrades();
	}

	private void LoadUpgrades()
	{
		_health = PlayerPrefs.GetFloat("tankHealth", 100.0f);
		_speed = PlayerPrefs.GetFloat("tankSpeed", 5.0f);
		_armor = PlayerPrefs.GetFloat("tankArmor", 10.0f);
		_weaponDamage = PlayerPrefs.GetFloat("tankWeaponDamage", 20.0f);
	}

	void LoadUpgradeLevels()
	{
		_cannonLevel = PlayerPrefs.GetInt("cannonLevel", 1);
		_armorLevel = PlayerPrefs.GetInt("armorLevel", 1);
		_speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
		_healthLevel = PlayerPrefs.GetInt("healthLevel", 1);
	}


}
