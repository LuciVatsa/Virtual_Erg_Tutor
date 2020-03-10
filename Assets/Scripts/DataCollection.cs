using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class DataCollection : MonoBehaviour
{ 
    private List<string[]> rowData = new List<string[]>();
    
    private void Start()
    {
        Save();
        
    }

    void Save()
    {
        string[] rowDataTemp = new string[8];
        rowDataTemp[0] = "Object Name";
        rowDataTemp[1] = "Time";
        rowDataTemp[2] = "PosX";
        rowDataTemp[3] = "PosY";
        rowDataTemp[4] = "PosZ";
        rowDataTemp[5] = "RotX";
        rowDataTemp[6] = "RotY";
        rowDataTemp[7] = "RotZ";
        rowData.Add(rowDataTemp);
    }
    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            string[] rowDataTemp = new string[8];
            rowDataTemp[0] = name;
            Debug.Log("Writing To List");
            rowDataTemp[1] = Time.time.ToString();
            rowDataTemp[2] = gameObject.transform.position.x.ToString();
            rowDataTemp[3] = gameObject.transform.position.y.ToString();
            rowDataTemp[4] = gameObject.transform.position.z.ToString();
            rowDataTemp[5] = gameObject.transform.rotation.eulerAngles.x.ToString();
            rowDataTemp[6] = gameObject.transform.rotation.eulerAngles.y.ToString();
            rowDataTemp[7] = gameObject.transform.rotation.eulerAngles.z.ToString();
            rowData.Add(rowDataTemp);
        }
        else
        {
            Debug.Log("Writing to File Now");
            WriteToFile();
        }
    }
    void WriteToFile()
    {
        Debug.Log("Writing to File");
        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
        {
            sb.AppendLine(string.Join(delimiter, output[index]));
        }
        string filePath = getPath();
        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    private string getPath()
    {
      #if UNITY_EDITOR
      return Application.dataPath + "/CSV" + "CurrentInfo.csv";
      #else
      return Application.dataPath + "/"+"CurrentInfo.csv";
      #endif  
    }     
}

