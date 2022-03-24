using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
	public GameObject DoorObj;
	private Animator animator;
	private bool isAnimation = false;

	public bool isOpen { get; set; }
	// Start is called before the first frame update
	void Start()
	{
		animator = DoorObj.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DoorState(bool state)
	{
		if (!isAnimation)
		{
			isOpen = state;
		}

		if (!isAnimation)
		{
			IsAnimationStart();
			if (isOpen)
			{
				animator.SetBool("Open", true);
			}
			else
			{
				animator.SetBool("Open", false);
			}
		}
	}

	public void IsAnimationStart()
	{
		isAnimation = true;
		Invoke("IsAnimationStop", 3.5f);
	}

	public void IsAnimationStop()
	{
		isAnimation = false;
	}

}
