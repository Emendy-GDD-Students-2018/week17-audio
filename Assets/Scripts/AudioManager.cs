using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;
	private AudioSource source;

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

		DontDestroyOnLoad(this);


		source = GetComponent<AudioSource>();
		GetAudioVolume();
	}

	public void CrossFadeToClip(float maxVolume, AudioClip clip)
	{
		StartCoroutine(CrossFade(maxVolume, clip));
	}

	protected IEnumerator CrossFade(float maxVolume, AudioClip clip)
	{
		while (source.volume > 0f)
		{
			source.volume -= Time.deltaTime;
			yield return null;
		}

		source.clip = clip;
		source.Play();

		while (source.volume <= maxVolume)
		{
			source.volume += Time.deltaTime;
			yield return null;
		}
	}

	public float GetAudioVolume()
	{
		return source.volume;
	}


	public static void PlayEffect(AudioClip[] selection, int index)
	{
		instance.source.PlayOneShot(selection[index]);
	}

	public static void PlayEffect(AudioClip clip)
	{
		instance.source.PlayOneShot(clip);
	}

	private void SetAudioVolume(float volume)
	{
		PlayerPrefs.SetFloat("volume", volume);
		PlayerPrefs.Save();
	}



	//public void GetAudioVolume()
	//{
	//	source.volume = PlayerPrefs.GetFloat("volume");
	//}
}