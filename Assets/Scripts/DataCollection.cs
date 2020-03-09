using System.Collections;
using System.IO;
using UnityEngine;

public class DataCollection : MonoBehaviour
{   void Update()
    {
         using (StreamWriter sw = new StreamWriter("Assets/CurrentInfo.csv", append:true))
        {
            sw.WriteLine(name + "," + Time.time + "," 
            + gameObject.transform.position.x + "," + gameObject.transform.position.y 
            + "," + gameObject.transform.position.z + "," + gameObject.transform.rotation.eulerAngles.x 
            + "," + gameObject.transform.rotation.eulerAngles.y + "," + gameObject.transform.rotation.eulerAngles.z);
        }
    }
}
