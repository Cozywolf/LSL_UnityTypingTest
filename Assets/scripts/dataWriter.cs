using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class dataWriter : MonoBehaviour
{
    public string data;
    public string result;
    public StreamWriter writer;
    public StreamWriter resultWriter;
    private string fileName, dataName, resultName;

    void Awake(){
        fileName = GameObject.Find("indestructable").GetComponent<StartTyping>().fileName;
        dataName = fileName + "_data.txt";
        fileName = GameObject.Find("indestructable").GetComponent<StartTyping>().fileName;
        resultName = fileName + "_result.txt";
        // writer = new StreamWriter("Assets/Outputs/" + fullName, true);    
        writer = new StreamWriter(Application.persistentDataPath + dataName, true);
        resultWriter = new StreamWriter(Application.persistentDataPath + resultName, true);
        // writer.WriteLine(System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + ",ExpStart\n");
    }
    public void writeData(){
        writer.WriteLine(data);
        print(data);
    }

    public void writeResultData(){
        resultWriter.WriteLine(result);
        print(result);
    }

}
