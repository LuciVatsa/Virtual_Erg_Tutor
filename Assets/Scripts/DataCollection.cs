﻿using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class DataCollection : MonoBehaviour
{ 

    private int bStartRecording;
    private List<string[]> rowData = new List<string[]>();
    
    private void Start()
    {
        Save();
        bStartRecording = 0;
    }

    void Save()
    {
        string[] rowDataTemp = new string[8];
        rowDataTemp[0] = "Object Name";
        rowDataTemp[1] = "Time";
        rowDataTemp[2] = "PosX";
        rowDataTemp[3] = "PosY";
        rowDataTemp[4] = "PosZ";
        rowData.Add(rowDataTemp);
    }
    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            bStartRecording = 1;
            Debug.Log("Starting to Record Files");
        }
        if(Input.GetKeyDown("p"))
        {
            Debug.Log("Writing to File");
            bStartRecording = 2;
        }
        if(bStartRecording == 1)
        {
            string[] rowDataTemp = new string[5];
            rowDataTemp[0] = name;
            rowDataTemp[1] = Time.time.ToString();
            rowDataTemp[2] = gameObject.transform.position.x.ToString();
            rowDataTemp[3] = gameObject.transform.position.y.ToString();
            rowDataTemp[4] = gameObject.transform.position.z.ToString();
            rowData.Add(rowDataTemp);
        }
        else if(bStartRecording == 2)
        {
            WriteToFile();
            bStartRecording = 0;
        }
    }
    void WriteToFile()
    {
        Debug.Log("Writing to file Now");
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
        Debug.Log("Finished Writing to File");
    }

    private string getPath()
    {
      #if UNITY_EDITOR

      return Application.dataPath + "/CSV"+ "ObjectData" + name + DateTime.Now.Hour + DateTime.Now.Minute + ".csv";
      #else
      return Application.dataPath + "/"+"CurrentInfo.csv";
      #endif  
    }     
}

