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
				transform.GetChild(0).GetComponent<AudioSource>().Play();
				player.TakeDamage(damage);
				transform.GetComponent<BoxCollider>().enabled = false;
				foreach (Transform child in transform)
				{
					if (child.gameObject.name != "SpikeAudioSource")
						Destroy(child.gameObject);
				}
			}
		}
	}
}
