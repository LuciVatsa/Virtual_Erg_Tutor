using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingCalibrator : MonoBehaviour
{
    public Transform ChairBaseHeight;
    public Transform HMDHeight;
    public Transform DumHeadHeight;
    public Transform DumBaseHeight;
    // Private Members
    private float HumanTorsoSize;
    private float DummyTorsoHeight;

    void Calibrate(float RealTorso, float DummyTorso)
    {

        float SizeFactor = (RealTorso - DummyTorso) / DummyTorso;
        gameObject.transform.localScale *= SizeFactor;
        
    }
    private void Start()
    {
        DummyTorsoHeight = DumHeadHeight.localPosition.y - DumBaseHeight.localPosition.y;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            HumanTorsoSize = HMDHeight.localPosition.y - ChairBaseHeight.localPosition.y;
            Calibrate(HumanTorsoSize, DummyTorsoHeight);
        }
    }

}
