using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioGroupFader : MonoBehaviour
{
	[SerializeField]
	protected AudioMixerGroup m_Group;

	[SerializeField]
	protected float m_FadeTime = 1f;

	protected float m_FadeTimer;

	protected bool m_Fade;

	void Start()
	{
		m_FadeTimer = 0f;
	}

	void Update()
	{
		if (m_Fade)
		{
			m_FadeTimer += Time.deltaTime;
			if (m_FadeTimer >= m_FadeTime)
			{
				m_Fade = false;
				m_FadeTimer = 0f;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			m_Fade = true;
		}
	}
}