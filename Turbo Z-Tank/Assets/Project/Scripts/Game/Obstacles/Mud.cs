using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
	float _slowDownFactor = 0.5f;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerController player = other.GetComponent<PlayerController>();
			if (player != null)
			{
				player.ModifySpeed(_slowDownFactor);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerController player = other.GetComponent<PlayerController>();
			if (player != null)
			{
				player.ResetSpeed();
			}
		}
	}
}
