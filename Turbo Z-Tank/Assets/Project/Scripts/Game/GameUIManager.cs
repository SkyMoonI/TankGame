using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUIManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI _healthText;
	[SerializeField] TextMeshProUGUI _speedText;
	[SerializeField] TextMeshProUGUI _coinsText;


	PlayerController _player;
	// Start is called before the first frame update
	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();

		_coinsText.text = "Coins: " + PlayerPrefs.GetInt("coins", 0).ToString();
	}

	// Update is called once per frame
	void Update()
	{
		_healthText.text = "Health: " + _player.CurrentHealth.ToString();
		_speedText.text = "Speed: " + _player.CurrentSpeed.ToString();
	}
}
