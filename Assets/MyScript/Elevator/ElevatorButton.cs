using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
	public GameObject ElevatorControllerObj;
	private ElevatorController elevatorController;
	// Start is called before the first frame update
	void Start()
	{
		elevatorController = ElevatorControllerObj.GetComponent<ElevatorController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnCollisionEnter(Collision collision)
	{
		var ButtonName = transform.name;
		if (collision.gameObject.tag == "hand")
		{
			if (ButtonName.Contains("Open"))
			{
				elevatorController.DoorState(true);
			}
			if (ButtonName.Contains("Close"))
			{
				elevatorController.DoorState(false);
			}

			
		}
	}
}
