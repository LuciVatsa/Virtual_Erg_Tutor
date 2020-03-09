using System.Collections;
using System.IO;
using UnityEngine;

public class DataCollectionTxT : MonoBehaviour
{
    string object_name;
    // Start is called before the first frame update
    void Start()
    {
        object_name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        using (StreamWriter sw = new StreamWriter("Assets/CurrentInfo"+ object_name +".txt", append:true))
        {
            sw.WriteLine(object_name + "  " + Time.time + "  " 
            + gameObject.transform.position.x + "  " + gameObject.transform.position.y 
            + "  " + gameObject.transform.position.z + "  " + gameObject.transform.rotation.eulerAngles.x 
            + "  " + gameObject.transform.rotation.eulerAngles.y + "  " + gameObject.transform.rotation.eulerAngles.z + "  ");
        }
    }
}
