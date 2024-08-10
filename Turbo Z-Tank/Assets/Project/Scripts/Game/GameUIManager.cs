using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUIManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI _healthText;
	[SerializeField] TextMeshProUGUI _speedText;

	PlayerController _player;
	// Start is called before the first frame update
	void Start()
	{
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{

		_healthText.text = "Health: " + _player.Health.ToString();
		_speedText.text = "Speed: " + _player.Speed.ToString();
	}
}
