using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void SelectLevels()
	{
		SceneManager.LoadScene("LevelSelectScene");
	}

	public void UpgradeMenu()
	{
		SceneManager.LoadScene("UpgradeMenuScene");
	}

	public void Options()
	{
		SceneManager.LoadScene("OptionsScene");
	}

	public void Quit()
	{
		if (Application.isEditor)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
		else
		{
			Application.Quit();
		}
	}
}
