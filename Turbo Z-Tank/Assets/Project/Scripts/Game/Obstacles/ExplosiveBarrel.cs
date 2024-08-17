using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
	[SerializeField] GameObject _explosionEffect;
	float _explosionRadius = 5.0f;
	float _explosionForce = 700.0f;
	int _damage = 50;


	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
		{
			Explode();
		}
	}

	void Explode()
	{
		transform.GetChild(0).GetComponent<AudioSource>().Play();
		GameObject effect = Instantiate(_explosionEffect, transform.position, transform.rotation);

		Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
		foreach (Collider nearbyObject in colliders)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
			}

			// Apply damage to the player or enemy
			if (nearbyObject.CompareTag("Player"))
			{
				PlayerController player = nearbyObject.GetComponent<PlayerController>();
				if (player != null)
				{
					player.TakeDamage(_damage);
				}
			}
			else if (nearbyObject.CompareTag("Enemy"))
			{
				Enemy enemy = nearbyObject.GetComponent<Enemy>();
				if (enemy != null)
				{
					Destroy(enemy.gameObject);
				}
			}
		}
		transform.GetComponent<MeshRenderer>().enabled = false;
		transform.GetComponent<MeshCollider>().enabled = false;
		Destroy(effect, 2.0f);
	}
}
