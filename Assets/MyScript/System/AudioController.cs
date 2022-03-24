using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : SoundController
{
	// Start is called before the first frame update



	void Start()
	{
		audio = GetComponent<AudioSource>();
		PlaySound((int)(State.TutorialStart));
	}

	// Update is called once per frame
	void Update()
	{

	}

	public override void PlaySound(int i)
	{
		audio.Stop();
		audio.PlayOneShot(Sound[i]);
	}

}
