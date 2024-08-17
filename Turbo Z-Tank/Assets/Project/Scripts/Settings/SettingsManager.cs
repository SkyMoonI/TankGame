using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
	[SerializeField] Slider _musicVolumeSlider;
	[SerializeField] Slider _sfxVolumeSlider;

	void Start()
	{
		_musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
		_sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
	}

	public void SetMusicVolume(float volume)
	{
		_musicVolumeSlider.value = volume;
		AudioManager.Instance.SetMusicVolume(volume);
		PlayerPrefs.SetFloat("musicVolume", volume);
	}

	public void SetSFXVolume(float volume)
	{
		_sfxVolumeSlider.value = volume;
		AudioManager.Instance.SetSFXVolume(volume);
		PlayerPrefs.SetFloat("sfxVolume", volume);
	}
	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

}
