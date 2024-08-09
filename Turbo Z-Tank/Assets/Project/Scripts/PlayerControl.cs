using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	PlayerInputAction _inputActions;
	Rigidbody _rigidbody;
	float _speed = 5.0f;
	void Awake()
	{
		_inputActions = new PlayerInputAction();
		_rigidbody = GetComponent<Rigidbody>();
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
}
