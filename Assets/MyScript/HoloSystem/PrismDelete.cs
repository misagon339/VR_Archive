using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismDelete : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject Effect;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void PrismDestroy(GameObject prismobj)
	{
		EffectOn();
		Effect.transform.position = prismobj.transform.position;
		Destroy(prismobj);
		Invoke("EffectOff", 5f);
	}

	public void EffectOn()
	{
		Effect.SetActive(true);
	}

	public void EffectOff()
	{
		Effect.SetActive(false);
	}
}
