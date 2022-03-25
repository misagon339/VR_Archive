using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTime : MonoBehaviour
{
    // Start is called before the first frame update

    private int Hour = 0;
    private int Minute = 0;

    public GameObject BigHand;
    public GameObject LittleHand;
    private int defaultRotation = 0;

    private int BigRotation = 0;
    private float LittleRotation = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //現在時刻取得
        Hour = int.Parse(System.DateTime.Now.Hour.ToString());
        //現在分取得
        Minute = int.Parse(System.DateTime.Now.Minute.ToString());

        //長針
        Transform BigTransform = BigHand.transform;
        Vector3 BigAngle = BigTransform.eulerAngles;
        BigAngle.z = Minute * 6;
        BigTransform.eulerAngles = BigAngle;

        //短針
        Transform LittleTransform = LittleHand.transform;
        Vector3 LittleAngle = LittleTransform.eulerAngles;
        LittleRotation = (Hour * 60) + Minute;
        LittleAngle.z = LittleRotation * 0.5f;
        LittleTransform.eulerAngles = LittleAngle;


    }
}
