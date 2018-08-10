using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioSource[] ambientSource;
	public AudioSource sfxAudioSource;

	void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void FadeInSource(AudioSource source)
	{
		StartCoroutine(FadeIn(source));
	}

	public void FadeOutSource(AudioSource source)
	{
		StartCoroutine(FadeOut(source));
	}

	public void PlayEffect(AudioClip[] selection, int index, AudioSource source)
	{
		source.clip = selection[index];
		source.Play();
	}

	public void PlayEffect(AudioClip clip, AudioSource source)
	{
		source.clip = clip;
		source.Play();
	}

	private void SetAudioVolume(float volume)
	{
		PlayerPrefs.SetFloat("volume", volume);
		PlayerPrefs.Save();
	}

	public float GetAudioVolume()
	{
		return PlayerPrefs.GetFloat("volume", 1);
	}

	private IEnumerator FadeOut(AudioSource source)
	{
		while (source.volume>0)
		{
			source.volume -= Time.deltaTime;
			yield return null;
		}
	}

	private IEnumerator FadeIn(AudioSource source)
	{
		while (source.volume < 1f)
		{
			source.volume += Time.deltaTime;
			if (source.volume>.98f)
			{
				source.volume = 1f;
			}
			yield return null;
		}
	}
}
