using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	PlayerInputAction _inputActions;
	Rigidbody _rigidbody;
	float _speed;
	public float Speed
	{
		get
		{
			return _speed;
		}
	}
	float _health = 100.0f;
	public float Health
	{
		get
		{
			return _health;
		}
	}
	float _originalSpeed = 5.0f;
	void Awake()
	{
		_inputActions = new PlayerInputAction();
		_rigidbody = GetComponent<Rigidbody>();
	}
	void Start()
	{
		_speed = _originalSpeed;
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
		Vector2 moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
		Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
		transform.Translate(moveDir * Time.deltaTime * _speed, Space.World);
	}

	public void ModifySpeed(float factor)
	{
		_speed *= factor;
	}

	public void ResetSpeed()
	{
		_speed = _originalSpeed;
	}

	public void BoostSpeed(float multipiler, float duration)
	{
		_speed *= multipiler;
		Invoke(nameof(ResetSpeed), duration);
	}

	public void TakeDamage(float damage)
	{
		_health -= damage;
		if (_health <= 0.0f)
		{
			Destroy(gameObject);
		}
	}
}
