using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismGetter : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject[] Prisms;
	public Vector3[] StartPos;
	void Start()
	{
		for (int i = 0; i < Prisms.Length; i++)
		{
			StartPos[i] = Prisms[i].transform.position;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}


	public void OnTriggerEnter(Collider other)
	{
		switch (other.transform.name)
		{
			case "Prism_ModelRoom":
				Prisms[0].transform.position = StartPos[0];
				break;

			case "Prism_SunFlower":
				Prisms[1].transform.position = StartPos[1];
				break;

			case "Prism_Cafe":
				Prisms[2].transform.position = StartPos[2];
				break;

			case "Prism_Shrine":
				Prisms[3].transform.position = StartPos[3];
				break;

			case "Prism_Release":
				Prisms[4].transform.position = StartPos[4];
				break;

			case "Prism_ClassRoom":
				Prisms[5].transform.position = StartPos[5];
				break;

			case "Prism_ShutDown":
				Prisms[6].transform.position = StartPos[6];
				break;

			case "Prism_Start":
				Prisms[7].transform.position = StartPos[7];
				break;

			case "Prism_Washitsu":
				Prisms[8].transform.position = StartPos[8];
				break;

			case "Prism_Ajisai":
				Prisms[9].transform.position = StartPos[9];
				break;
		}
	}


}
