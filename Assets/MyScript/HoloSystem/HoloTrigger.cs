using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloTrigger : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform PrismPos;

	public GameObject ModelControllerObj;
	ModelController modelController;

	public GameObject PrismDeleteObj;
	PrismDelete prismDelete;

	public bool isReleased = false;

	public GameObject PrismName = null;

	void Start()
	{
		modelController = ModelControllerObj.GetComponent<ModelController>();
		prismDelete = PrismDeleteObj.GetComponent<PrismDelete>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.name.Contains("Prism"))
		{
			if (other.CompareTag("Prism"))
			{
				PrismSetting(other);
				PrismActivate(other, isReleased);
				NameCheck(other.gameObject);
				other.gameObject.tag = "None";
			}
		}
	}

	public void PrismSetting(Collider other)
	{
		if (other.transform.name != "Prism_Release")
		{
			other.transform.position = PrismPos.position;
			other.transform.rotation = PrismPos.rotation;
			var rb = other.GetComponent<Rigidbody>();
			var col = other.GetComponent<BoxCollider>();
			rb.isKinematic = true;
			col.enabled = false;
			other.gameObject.transform.parent = this.gameObject.transform;
		}
		else
		{
			other.transform.position = PrismPos.position;
			other.transform.rotation = PrismPos.rotation;
			var rb = other.GetComponent<Rigidbody>();
			var col = other.GetComponent<BoxCollider>();
			rb.isKinematic = true;
			col.enabled = false;
			other.gameObject.transform.parent = this.gameObject.transform;
			isReleased = true;
		}
	}

	public void PrismActivate(Collider other, bool isReleased)
	{
		var tag = other.transform.name;
		modelController.ModelInitialize(tag, isReleased);
	}

	public void PrismDestroy(GameObject obj)
	{
		prismDelete.PrismDestroy(obj);
	}

	public void NameCheck(GameObject obj)
	{
		if (PrismName == null)
		{
			PrismName = obj;
		}

		if (PrismName != obj)
		{
			PrismDestroy(PrismName);
			PrismName = obj;
		}

	}

}
