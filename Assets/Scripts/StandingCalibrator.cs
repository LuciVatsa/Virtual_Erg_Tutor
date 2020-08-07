using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCalibrator : MonoBehaviour
{
    public Transform HMDHeight;
    public Transform DumHeadHeight;
    // Private Members
    private float HumanSize;
    private float DummyHeight;

    void Calibrate(float RealTorso, float DummyTorso)
    {

        float SizeFactor = (RealTorso - DummyTorso) / DummyTorso;
        gameObject.transform.localScale *= SizeFactor;

    }
    private void Start()
    {
        DummyHeight = DumHeadHeight.localPosition.y;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            HumanSize = HMDHeight.localPosition.y;
            Calibrate(HumanSize, DummyHeight);
        }
    }
}
