using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			transform.GetChild(0).GetComponent<AudioSource>().Play();
			GameManager.Instance.IsWin = true;
			GameManager.Instance.TriggerGameEnd();
		}
	}
}
