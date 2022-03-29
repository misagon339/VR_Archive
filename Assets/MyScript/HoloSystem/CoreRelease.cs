using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static AudioController;
using static BGMComtroller;

public class CoreRelease : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform CenterPos;
	public Transform StartPos;
	public Material ReleaseMat;
	private Animator animator;

	public GameObject Box;
	private Animator BoxAnim;

	//public GameObject PrismTable;
	//private Animator PrismAnim;

	public GameObject ArtgalleryObj;
	private Animator ArtAnim;

	public GameObject DoorCol;
	public GameObject DoorCol_End;

	public GameObject AudioControllerObj;
	private AudioController audioController;

	public GameObject BGMControllerObj;
	private BGMComtroller bGMComtroller;

	public GameObject PrismAfterRelease;
	public GameObject PrismBeforeRelease;

	public bool isAnimation = false;
	public bool isShutDown = false;

	public GameObject UseAsset;
	public GameObject Omake;
	void Start()
	{
		animator = GetComponent<Animator>();
		BoxAnim = Box.GetComponent<Animator>();
		//PrismAnim = PrismTable.GetComponent<Animator>();
		ArtAnim = ArtgalleryObj.GetComponent<Animator>();
		audioController = AudioControllerObj.GetComponent<AudioController>();
		bGMComtroller = BGMControllerObj.GetComponent<BGMComtroller>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	//拡張モード時ミニチュアモデル読み込み機移動アニメーション
	public void CoreRecollection()
	{
		if (!isAnimation)
		{
			isAnimation = true;
			audioController.PlaySound((int)AudioController.State.Release);
			BoxAnim.SetBool("ON", true);
			Sequence seq = DOTween.Sequence();
			seq.Append(transform.DOMove(CenterPos.position, 5f));
			seq.Join(transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.LocalAxisAdd));

			seq.OnComplete(() =>
				{
					GetComponent<Renderer>().material = ReleaseMat;
					animator.enabled = true;
					PrismBeforeRelease.SetActive(false);
					PrismAfterRelease.SetActive(true);
					var mesh = Box.GetComponent<MeshRenderer>();
					mesh.enabled = false;
					isAnimation = false;
				});
		}
	}

	//チュートリアル終了時ミニチュアモデル読み込み機移動アニメーション関連処理
	public void CoreStart()
	{
		if (!isAnimation)
		{
			DoorCol.SetActive(false);
			isAnimation = true;
			audioController.PlaySound((int)AudioController.State.TutorialEnd);
			bGMComtroller.PlaySound((int)BGMComtroller.BGMState.Default);
			ArtAnim.SetBool("ON", true);
			Box.SetActive(true);
			BoxAnim.SetBool("ON", false);
			Sequence seq = DOTween.Sequence();
			seq.Append(transform.DOMove(StartPos.position, 5f));
			seq.Join(transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.LocalAxisAdd));

			seq.OnComplete(() =>
			{
				PrismBeforeRelease.SetActive(true);
				isAnimation = false;
				//audioController.PlaySE((int)AudioController.State.Start);
				//ArtgalleryObj.SetActive(false);
			});
		}
	}

	//システム終了時
	public void CoreShutDown()
	{
		if (!isShutDown)
		{
			isShutDown = true;
			audioController.PlaySound((int)AudioController.State.Shutdown);
			Box.SetActive(true);
			PrismAfterRelease.SetActive(false);
			BoxAnim.SetBool("ON", false);
			var mesh = Box.GetComponent<MeshRenderer>();
			mesh.enabled = true;
			ArtgalleryObj.SetActive(true);
			DoorCol_End.SetActive(true);
			Box.SetActive(false);
			UseAsset.SetActive(true);
			Omake.SetActive(true);
		}
	}

}
