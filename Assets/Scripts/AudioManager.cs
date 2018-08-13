using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager Singleton;

	[SerializeField] AudioSource music1;
	[SerializeField] AudioSource music2;

	[SerializeField] float desiredMusicVolume = 0.5f;
	[SerializeField] float musicCrossfadeTime = 0.2f;

	[SerializeField] AudioClip normalMusic;
	[SerializeField] AudioClip exciteMusic;

	private AudioSource musicActive;
	private AudioSource musicInactive;

	private void Awake()
	{
		Singleton = this;
		musicActive = music1;
		musicInactive = music2;
	}

	private void OnDestroy()
	{
		Singleton = null;
	}

	public void PlayNormalMusic()
	{
		PlayMusic(normalMusic);
	}

	public void PlayExcitingMusic()
	{
		PlayMusic(exciteMusic);
	}

	enum State
	{
		Idle,
		Crossfading,
		Playing
	}

	State state = State.Idle;

	void PlayMusic(AudioClip clip)
	{
		switch(state)
		{
			case State.Idle:
			case State.Playing:

				if (musicActive.clip != clip)
				{
					state = State.Crossfading;

					musicInactive.clip = clip;
					musicInactive.volume = 0f;
					musicInactive.Play();

					StartCoroutine("DoCrossFade");
				}
				break;

			case State.Crossfading:

				StopCoroutine("DoCrossFade");

				state = State.Playing;

				musicActive.volume = desiredMusicVolume;
				musicActive.clip = clip;
				musicActive.Play();

				musicInactive.Stop();

				break;
			
		}
	}

	IEnumerator DoCrossFade()
	{
		float startTime = Time.time;
		while (Time.time - startTime < musicCrossfadeTime)
		{
			var volLerp = (Time.time - startTime) / musicCrossfadeTime;
			musicActive.volume = desiredMusicVolume * (1 - volLerp);
			musicInactive.volume = desiredMusicVolume * volLerp;
			yield return null;
		}

		var tmp = musicActive;
		musicActive = musicInactive;
		musicInactive = tmp;

		musicInactive.Stop();

		state = State.Playing;
	}

	/*private IEnumerator FadeIn(AudioClip clip)
	{
		
	}

	private IEnumerator Play(ClipInfo info)
	{
		if (info.opener != null)
		{
			musicActive.clip = info.opener;
			crossfade.Play(info.opener);
		}

		while (crossfade.isPlaying)
		{
			yield return null;
		}

		music.clip = info.c;

		music.Play();
	}*/
}
