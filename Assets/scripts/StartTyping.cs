using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using LSL;

public class StartTyping : MonoBehaviour
{
    // define LSL stream
    private StreamInfo streamInfo;
    private StreamOutlet outlet;
    private XMLElement chans;
    private string[] currentSample;
    public string StreamName = "UnityTypingStream";
    public string StreamType = "Markers";
    public string StreamId = "UnityTyping";

    private Camera cam;
    public Vector3 point = new Vector3();
    public float screenW;
    public float screenH;

    public string ppName;
    public string sessionName;
    public int timer;
    public string paragraphName;

    public string fileName;

    void Start(){
        DontDestroyOnLoad(gameObject);
        cam = Camera.main;
        point = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        streamInfo = new StreamInfo(StreamName, StreamType, 1, 0, LSL.channel_format_t.cf_string, "unityLSLtyping");
        chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "target");
        outlet = new StreamOutlet(streamInfo);
        currentSample = new string[1];
    }

    public void initTyping(){
        ppName = GameObject.Find("ParticipantIDField").GetComponent<TMP_InputField>().text;
        sessionName = GameObject.Find("SessionField").GetComponent<TMP_InputField>().text;
        timer = int.Parse(GameObject.Find("TimerField").GetComponent<TMP_InputField>().text);
        paragraphName = GameObject.Find("ParagraphField").GetComponent<TMP_InputField>().text;
        
        fileName = ppName + "_" + sessionName + "_" + timer.ToString() + "_" + paragraphName;
        Debug.Log(fileName);
        sendLSL(DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
        sendLSL("TypingScreenInitiated");

        SceneManager.LoadScene("Typing", LoadSceneMode.Single);        
    }

    public void sendLSL(string target){
        currentSample[0] = target;
        outlet.push_sample(currentSample);
    }

}
