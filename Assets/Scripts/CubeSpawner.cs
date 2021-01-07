using UnityEngine;
using Valve.VR;

public class CubeSpawner : MonoBehaviour
{ 
    // a reference to the action
    public SteamVR_Action_Boolean SpawnCube;

    // a reference to the hand
    public SteamVR_Input_Sources handType;

    public GameObject CubetoSpawn;

    private void Start()
    {
        SpawnCube.AddOnStateDownListener(CubeMagic, handType);
    }

    public void CubeMagic(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Instantiate(CubetoSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }
    void LateUpdate()
    {
        if(Input.GetKeyDown("m"))
        {
            Instantiate(CubetoSpawn, gameObject.transform.position, gameObject.transform.rotation);
        }
        
    }
}
