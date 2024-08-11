using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	[SerializeField] Slider _musicVolumeSlider;
	[SerializeField] Slider _sfxVolumeSlider;

	[SerializeField] AudioSource _musicSource;
	[SerializeField] AudioSource[] _sfxSource;
	// Start is called before the first frame update
	void Start()
	{
		_musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
		_sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.5f);

		SetMusicVolume(_musicVolumeSlider.value);
		SetSFXVolume(_sfxVolumeSlider.value);
	}

	public void SetMusicVolume(float volume)
	{
		_musicSource.volume = volume;
		PlayerPrefs.SetFloat("musicVolume", volume);
	}

	public void SetSFXVolume(float volume)
	{
		foreach (AudioSource audio in _sfxSource)
		{
			audio.volume = volume;
		}
		PlayerPrefs.SetFloat("sfxVolume", volume);
	}
}
