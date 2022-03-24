using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundController : MonoBehaviour
{
	// Start is called before the first frame update

	public AudioSource audio;
	public AudioClip[] Sound;


	public enum State
	{
		Start,
		Release,
		Shutdown,
		TutorialStart,
		TutorialEnd,
		Manual,
		
	}

	public enum BGMState
	{
		Tutorial,
		Default,
		ModelRoom,
		Cafe,
		ClassRoom,
		SunFlower,
		Shrine,
		Release,
		Washitsu,
		Ajisai,
	}

	public enum SEType
	{
		Generate,
		Bell
	}

	void Start()
	{
		audio = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update()
	{

	}

	public abstract void PlaySound(int i);

}
