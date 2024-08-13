using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	int _coinValue = 1;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameManager.Instance.AddCoin(_coinValue);
			Destroy(gameObject);
		}
	}
}
