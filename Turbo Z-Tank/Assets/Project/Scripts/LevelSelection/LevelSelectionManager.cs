using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelectionManager : MonoBehaviour
{
	[SerializeField] List<Button> _levelButtons;
	int _currentLevel = 1;


	private void Start()
	{
		SetupLevelButtons();
	}

	private void SetupLevelButtons()
	{
		for (int i = 0; i < _levelButtons.Count; i++)
		{
			Button button = _levelButtons[i];

			int capturedIndex = i;
			capturedIndex++;

			button.onClick.AddListener(() => SelectLevel(capturedIndex));
			// Example of locking a level until the previous level is completed
			if (PlayerPrefs.GetInt("Level" + capturedIndex + "Completed", 0) == 0)
			{
				if (capturedIndex < _levelButtons.Count)
				{
					_levelButtons[capturedIndex].interactable = false;

				}
			}
		}
	}

	public void SelectLevel(int level)
	{
		SceneManager.LoadScene("Level" + level);
		LevelComplete.Instance.SetLevel(level);
		if (GameManager.Instance != null)
		{
			GameManager.Instance.IsDead = false;
			GameManager.Instance.IsWin = false;
			GameManager.Instance.TotalCoins = 0;
		}

	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}
}
