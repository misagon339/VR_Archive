using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fingerPoint;
    public GameObject Finger;

    void Start()
    {
        Invoke("FingerPointOn", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FingerPointOn()
	{
        fingerPoint.transform.parent = Finger.transform;
        fingerPoint.transform.position = Finger.transform.position;
    }
}
