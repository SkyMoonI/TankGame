using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public void TriggerGameOver()
	{
		StartCoroutine(GameOver());
	}
	IEnumerator GameOver()
	{
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("UpgradeMenuScene");
	}
}
