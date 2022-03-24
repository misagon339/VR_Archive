using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLabo : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject AudioControllerObj;
	private AudioController audio;
	public GameObject Artgallery;
	public GameObject DoorCol;
	public GameObject TextObj;
	public Transform Pos;
	public GameObject CallButtonObj;
	public GameObject ManualObj;
	public GameObject PrismMachine;

	void Start()
	{
		audio = AudioControllerObj.GetComponent<AudioController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			audio.PlaySound((int)AudioController.State.Start);
			CallButtonObj.SetActive(false);
			PrismMachine.SetActive(false);
			ManualObj.SetActive(false);
			DoorCol.SetActive(true);
			Artgallery.SetActive(false);
			Artgallery.transform.position = Pos.transform.position;
			Artgallery.transform.rotation = Pos.transform.rotation;
			TextObj.SetActive(true);
			StartCoroutine(DelayMethod(5f, () => { TextOff(); }));
		}
	}

	public IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}

	public void TextOff()
	{
		TextObj.SetActive(false);
		this.gameObject.SetActive(false);
	}
}
