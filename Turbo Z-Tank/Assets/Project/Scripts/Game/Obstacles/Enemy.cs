using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	float _health = 100.0f;
	float _speed = 3.0f;
	float _damage = 10.0f;

	Transform _player;

	int _coinValue = 5;

	EnemyRange _enemyRange;

	// Start is called before the first frame update
	void Start()
	{
		_player = GameObject.Find("Player").transform;
		_enemyRange = transform.GetChild(0).GetComponent<EnemyRange>();
	}

	// Update is called once per frame
	void Update()
	{
		if (_player != null && !GameManager.Instance.IsDead && !GameManager.Instance.IsWin && _enemyRange.PlayerInRange)
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
				Die();
			}
		}
	}

	// for later use
	public void TakeDamage(float damage)
	{
		_health -= damage;
		if (_health <= 0.0f)
		{
			Die();
		}
	}

	void Die()
	{
		AudioManager.Instance.PlaySFX("enemy");
		GameManager.Instance.AddCoin(_coinValue);
		Destroy(gameObject);
	}
}
