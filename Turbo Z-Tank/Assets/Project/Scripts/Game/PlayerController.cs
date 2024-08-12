using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	GameManager _gameManager;
	PlayerInputAction _inputActions;
	Rigidbody _rigidbody;
	[SerializeField] Tank tank;

	public float CurrentSpeed { get; private set; }

	public float CurrentHealth { get; private set; }
	void Awake()
	{
		_inputActions = new PlayerInputAction();
		_rigidbody = GetComponent<Rigidbody>();
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
		Vector2 moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
		Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
		transform.Translate(moveDir * Time.deltaTime * CurrentSpeed, Space.World);
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
			Destroy(gameObject);
			_gameManager.TriggerGameOver();
		}
	}
}
