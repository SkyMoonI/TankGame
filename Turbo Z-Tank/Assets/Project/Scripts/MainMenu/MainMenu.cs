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
		SceneManager.LoadScene("SettingsScene");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
