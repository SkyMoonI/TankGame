using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
	float boostMultiplier = 1.5f;
	float boostDuration = 2.0f;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			if (player != null)
			{
				AudioManager.Instance.PlaySFX("ramp");
				player.BoostSpeed(boostMultiplier, boostDuration);
			}
		}
	}
}
