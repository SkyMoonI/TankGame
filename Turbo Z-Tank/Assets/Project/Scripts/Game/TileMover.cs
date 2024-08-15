using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TileMover : MonoBehaviour
{
	float _tileSpeed = 10.0f;
	public float TileSpeed { get { return _tileSpeed; } set { _tileSpeed = value; } }

	// Update is called once per frame
	void Update()
	{
		MoveTiles();
	}
	public void MoveTiles()
	{
		if (!GameManager.Instance.IsDead && !GameManager.Instance.IsWin)
		{
			transform.position += Vector3.back * _tileSpeed * Time.deltaTime;
			if (transform.position.z < -50f)
			{
				Destroy(gameObject);
			}
		}
	}
}
