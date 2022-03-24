using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMComtroller : SoundController
{
	// Start is called before the first frame update



	void Start()
	{
		audio = GetComponent<AudioSource>();
		PlaySound((int)(BGMState.Tutorial));
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
