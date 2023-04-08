using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class getKeyInfo : MonoBehaviour
{
    public Camera cam;
    string m_name;
    Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;
    StreamWriter infoWriter;
    private string fileName, infoName;

    // Start is called before the first frame update
    void Start()
    {
        fileName = GameObject.Find("indestructable").GetComponent<StartTyping>().fileName;
        infoName = fileName + "_keyInfo.txt";
        infoWriter = new StreamWriter(Application.persistentDataPath + infoName, true);
        GameObject[] keys = GameObject.FindGameObjectsWithTag("keyInput");

        foreach(GameObject key in keys)
        {
            m_name = key.name;
            m_Collider = key.GetComponent<Collider>();
            //Fetch the center of the Collider volume
            m_Center = m_Collider.bounds.center;
            //Fetch the size of the Collider volume
            m_Size = m_Collider.bounds.size;
            //Fetch the minimum (bottom left) and maximum (top right) bounds of the Collider volume
            m_Min = m_Collider.bounds.min;
            m_Max = m_Collider.bounds.max;
            //Output this data into the console
            Vector3 m_Min_screen = cam.WorldToScreenPoint(m_Min);
            Vector3 m_Max_screen = cam.WorldToScreenPoint(m_Max);
            // Vector2 topLeft = (m_Min_screen.x, m_Min_screen.y);
            Debug.Log(m_name + "," + new Vector2(m_Min_screen.x, m_Max_screen.y) + "," + new Vector2(m_Max_screen.x, m_Max_screen.y) + "," + new Vector2(m_Max_screen.x, m_Min_screen.y) + "," + new Vector2(m_Min_screen.x, m_Min_screen.y));
            infoWriter.WriteLine(m_name + "," + new Vector2(m_Min_screen.x, m_Max_screen.y) + "," + new Vector2(m_Max_screen.x, m_Max_screen.y) + "," + new Vector2(m_Max_screen.x, m_Min_screen.y) + "," + new Vector2(m_Min_screen.x, m_Min_screen.y));
            // Debug.Log(new Vector2(m_Max_screen.x, m_Max_screen.y));
            // Debug.Log(new Vector2(m_Max_screen.x, m_Min_screen.y));
            // Debug.Log(new Vector2(m_Min_screen.x, m_Min_screen.y));
            // Debug.Log("Collider name : " + m_name);
            // OutputData();
        }   
        infoWriter.Close();
    }
    // void OutputData()
    // {
    //     //Output to the console the center and size of the Collider volume
    //     Debug.Log("Collider name : " + m_name);
    //     Debug.Log("Collider Center : " + m_Center);
    //     Debug.Log("Collider Size : " + m_Size);
    //     Debug.Log("Collider bound Minimum : " + m_Min);
    //     Debug.Log("Collider bound Maximum : " + m_Max);
    // }
}
