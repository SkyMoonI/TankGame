using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }
	[SerializeField] AudioSource _musicSource, _sfxSources;
	public AudioSource MusicSource { get { return _musicSource; } set { _musicSource = value; } }
	[SerializeField] AudioClip[] _musicClips, _sfxClips;
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
		_sfxSources.volume = volume;
	}

	public void PlayMusic(string name)
	{
		AudioClip temp = Array.Find(_musicClips, clip => clip.name == name);
		if (temp == null)
		{
			Debug.Log("Music not found: " + name);
			return;
		}
		else
		{
			_musicSource.clip = temp;
			_musicSource.Play();
		}
	}
	public void PlaySFX(string name)
	{
		AudioClip temp = Array.Find(_sfxClips, clip => clip.name == name);
		if (temp == null)
		{
			Debug.Log("SFX not found: " + name);
			return;
		}
		else
		{
			_sfxSources.clip = temp;
			_sfxSources.Play();
		}
	}
}
