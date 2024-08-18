using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	int damage = 10;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			if (player != null)
			{
				AudioManager.Instance.PlaySFX("spike");
				player.TakeDamage(damage);
				Destroy(gameObject);
			}
		}
	}
}
