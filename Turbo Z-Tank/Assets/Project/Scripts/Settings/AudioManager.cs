using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }
	[SerializeField] AudioSource _musicSource;
	[SerializeField] AudioSource[] _sfxSources;
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	// Start is called before the first frame update
	void Start()
	{
		SetMusicVolume(PlayerPrefs.GetFloat("musicVolume", 0.5f));
		SetSFXVolume(PlayerPrefs.GetFloat("sfxVolume", 0.5f));
	}

	public void SetMusicVolume(float volume)
	{
		_musicSource.volume = volume;
	}

	public void SetSFXVolume(float volume)
	{
		foreach (var source in _sfxSources)
		{
			source.volume = volume;
		}
	}


}
