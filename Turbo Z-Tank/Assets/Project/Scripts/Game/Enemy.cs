using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	float _health = 100.0f;
	float _speed = 3.0f;
	float _damage = 10.0f;

	Transform _player;

	// Start is called before the first frame update
	void Start()
	{
		_player = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update()
	{
		if (_player != null)
		{
			Vector3 direction = _player.position - transform.position;
			transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			if (player != null)
			{
				player.TakeDamage(_damage);
				Destroy(gameObject); // Destroy enemy on contact
			}
		}
	}

	// for later use
	public void TakeDamage(float damage)
	{
		_health -= damage;
		if (_health <= 0.0f)
		{
			Destroy(gameObject);
		}
	}
}
