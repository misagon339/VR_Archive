using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioController;
using static SoundController;

public class ModelController : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject[] HoloGuards;
	public GameObject[] Models;
	public GameObject PrismCore;
	CoreRelease core;

	public GameObject SEControllerObj;
	private SEController SECon;

	public GameObject BGMControllerObj;
	private BGMComtroller BGM;

	public GameObject SkyBoxControllerObj;
	private SkyBoxController skyBoxCon;

	public GameObject PrismAnimObj;

	public bool BeforeAjisai = false;
	public GameObject Umbrella;
	void Start()
	{
		core = PrismCore.GetComponent<CoreRelease>();
		SECon = SEControllerObj.GetComponent<SEController>();
		BGM = BGMControllerObj.GetComponent<BGMComtroller>();
		skyBoxCon = SkyBoxControllerObj.GetComponent<SkyBoxController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}


	public void ModelInitialize(string prismname, bool isReleased)
	{

		//視界遮蔽オブジェ表示
		HoloGuardOn(prismname, isReleased);

		//全モデルを非表示にして次のモデルの表示準備
		StartCoroutine(DelayMethod(0.45f, () => { HoloGuardOff(isReleased); }));

		//全モデルを非表示にして次のモデルの表示準備
		StartCoroutine(DelayMethod(0.45f, () => { AllModelOFF(isReleased); }));

		//遮蔽後に表示
		StartCoroutine(DelayMethod(0.5f, () => { ModelActivate(prismname); }));
	}

	public void AllModelOFF(bool isReleased)
	{
		for (int i = 0; i < Models.Length; i++)
		{
			Models[i].SetActive(false);
		}
		if (isReleased)
		{

		}

	}

	public void ModelActivate(string prismname)
	{
		SECon.PlaySound((int)SEType.Generate);
		switch (prismname)
		{
			case "Prism_ModelRoom":
				Models[0].SetActive(true);
				BGM.PlaySound((int)BGMState.ModelRoom);
				break;

			case "Prism_SunFlower":
				skyBoxCon.SkyBoxChange(prismname);
				Models[1].SetActive(true);
				CheckAjisai();
				BGM.PlaySound((int)BGMState.SunFlower);
				break;
			case "Prism_Cafe":
				Models[2].SetActive(true);
				BGM.PlaySound((int)BGMState.Cafe);
				break;
			case "Prism_Shrine":
				skyBoxCon.SkyBoxChange(prismname);
				Models[3].SetActive(true);
				CheckAjisai();
				BGM.PlaySound((int)BGMState.Shrine);
				break;
			case "Prism_ClassRoom":
				Models[4].SetActive(true);
				BGM.PlaySound((int)BGMState.ClassRoom);
				break;

			case "Prism_Washitsu":
				Models[5].SetActive(true);
				BGM.PlaySound((int)BGMState.Washitsu);
				break;

			case "Prism_Ajisai":
				Models[6].SetActive(true);
				BGM.PlaySound((int)BGMState.Ajisai);
				BeforeAjisai = true;
				skyBoxCon.SkyBoxChange(prismname);
				break;

			case "Prism_Release":
				core.CoreRecollection();
				BGM.PlaySound((int)BGMState.Release);
				break;

			case "Prism_ShutDown":
				core.CoreShutDown();
				BGM.PlaySound((int)BGMState.Default);
				CheckAjisai();
				skyBoxCon.SkyBoxChange(prismname);
				break;

			case "Prism_Start":
				core.CoreStart();
				BGM.PlaySound((int)BGMState.Default);
				PrismAnimObj.SetActive(false);
				break;
		}
		if (prismname != "Prism_Release")
		{
			Invoke("HoloGuardOff", 0.6f);
		}
	}

	public void HoloGuardOn(string prismname, bool isReleased)
	{
		if (prismname != "Prism_Release" || prismname != "Prism_Start")
		{
			if (!isReleased)
			{
				HoloGuards[0].SetActive(true);
			}
			else
			{
				HoloGuards[1].SetActive(true);
			}
		}
	}

	public void HoloGuardOff(bool isReleased)
	{
		if (!isReleased)
		{
			HoloGuards[0].SetActive(false);
		}
		else
		{
			HoloGuards[1].SetActive(false);
		}
	}

	public void CheckAjisai()
	{
		if (BeforeAjisai)
		{
			Umbrella.SetActive(false);
		}
	}
}
