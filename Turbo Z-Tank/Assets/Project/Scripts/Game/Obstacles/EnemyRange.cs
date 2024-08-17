using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
	bool _playerInRange = false;
	public bool PlayerInRange { get { return _playerInRange; } set { _playerInRange = value; } }
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerInRange = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerInRange = false;
		}
	}
}
