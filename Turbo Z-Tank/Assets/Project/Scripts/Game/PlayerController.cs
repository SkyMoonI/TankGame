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
		AudioManager.Instance.PlayMusic("bgmusic");
		CurrentSpeed = tank.Speed;
		CurrentHealth = tank.Health;
		GameManager.Instance.NewGameStart();
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
		CurrentHealth -= damage * ((100 - tank.Armor) / 100);
		if (CurrentHealth <= 0.0f && !GameManager.Instance.IsDead && !GameManager.Instance.IsWin)
		{
			CurrentHealth = 0.0f;
			Die();
		}
	}
	public void Die()
	{
		AudioManager.Instance.PlaySFX("death");
		GameManager.Instance.IsDead = true;
		GameManager.Instance.TriggerGameEnd();
		Destroy(gameObject);
	}

}
