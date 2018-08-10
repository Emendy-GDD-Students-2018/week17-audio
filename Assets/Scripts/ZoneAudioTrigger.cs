using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAudioTrigger : MonoBehaviour
{
	public AudioClip clip;

	private void Start()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			AudioManager.instance.CrossFadeToClip(.8f, clip);
		}
	}
}
