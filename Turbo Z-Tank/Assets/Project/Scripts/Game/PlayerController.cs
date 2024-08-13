using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	PlayerInputAction _inputActions;
	Rigidbody _rigidbody;
	[SerializeField] Tank tank;

	public float CurrentSpeed { get; private set; }

	public float CurrentHealth { get; private set; }

	void Awake()
	{
		_inputActions = new PlayerInputAction();
		_rigidbody = GetComponent<Rigidbody>();
	}
	void Start()
	{
		CurrentSpeed = tank.Speed;
		CurrentHealth = tank.Health;
	}

	void OnEnable()
	{
		_inputActions.Enable();
	}

	void OnDisable()
	{
		_inputActions.Disable();
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < -10.0f)
		{
			Die();
		}
		if (!GameManager.Instance.IsDead && !GameManager.Instance.IsWin)
		{
			Vector2 moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
			Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
			transform.Translate(moveDir * Time.deltaTime * CurrentSpeed, Space.World);
		}

	}

	public void ModifySpeed(float factor)
	{
		CurrentSpeed *= factor;
	}

	public void ResetSpeed()
	{
		CurrentSpeed = tank.Speed;
	}

	public void BoostSpeed(float multipiler, float duration)
	{
		CurrentSpeed *= multipiler;
		Invoke(nameof(ResetSpeed), duration);
	}

	public void TakeDamage(float damage)
	{
		CurrentHealth -= damage;
		if (CurrentHealth <= 0.0f)
		{
			CurrentHealth = 0.0f;
			Die();
		}
	}
	public void Die()
	{
		GameManager.Instance.IsDead = true;
		Destroy(gameObject);
		GameManager.Instance.TriggerGameEnd();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("FinishLine"))
		{
			GameManager.Instance.IsWin = true;
			GameManager.Instance.TriggerGameEnd();
		}
	}
}
