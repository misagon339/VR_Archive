using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioController;
using static SoundController;

public class CallButton : MonoBehaviour
{
	public GameObject AudioControllerObj;
	private AudioController audioController;

	public GameObject SEControllerObj;
	private SEController SE;

	public GameObject PlayManual;
	public bool Pressed = false;
	public GameObject CallButtonObj;

	// Start is called before the first frame update
	void Start()
	{
		audioController = AudioControllerObj.GetComponent<AudioController>();
		SE = SEControllerObj.GetComponent<SEController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "hand")
		{
			if (!Pressed)
			{
				audioController.PlaySound((int)AudioController.State.Manual);
				SE.PlaySound((int)SEType.Bell);
				PlayManual.SetActive(true);
				CallButtonObj.SetActive(false);
			}
		}
	}

}
