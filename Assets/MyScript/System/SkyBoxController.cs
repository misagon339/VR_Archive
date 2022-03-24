using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
	// Start is called before the first frame update
	public Material[] SkyBoxMat;

	public enum SkyType
	{
		Default,
		SunSet,
		Night,
		DayTime,
		Cloudy,
	}



	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SkyBoxChange(string ModelName)
	{
		switch (ModelName)
		{
			case "Prism_ModelRoom":

				break;

			case "Prism_SunFlower":
				RenderSettings.skybox = SkyBoxMat[(int)SkyType.SunSet];
				break;
			case "Prism_Cafe":

				break;
			case "Prism_Shrine":
				RenderSettings.skybox = SkyBoxMat[(int)SkyType.DayTime];
				break;
			case "Prism_ClassRoom":

				break;

			case "Prism_Ajisai":
				RenderSettings.skybox = SkyBoxMat[(int)SkyType.Cloudy];
				break;
			case "Prism_Release":

				break;

			case "Prism_ShutDown":
				RenderSettings.skybox = SkyBoxMat[(int)SkyType.Default];
				break;
		}
	}
}

