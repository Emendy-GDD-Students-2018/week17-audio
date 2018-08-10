using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Triggers a clip to play when Player enters the Trigger
/// </summary>
public class AudioZoneTrigger : MonoBehaviour
{
	[Header("Clip to Play when Triggered")]
	public AudioClip clip;
	public AudioSource source;

	private void Start()
	{
		source.volume = 0f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			AudioManager.instance.FadeInSource(source);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			AudioManager.instance.FadeOutSource(source);
		}
	}
}
