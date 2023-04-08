using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class TypingControl : MonoBehaviour
{
    private TMP_Text timer;
    private float timeLeft;
    public GameObject keyboard;
    public bool timerActive = false;
    private TMP_Text textDisplay;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<TMP_Text>();
        timer.text = GameObject.Find("indestructable").GetComponent<StartTyping>().timer.ToString();
        Debug.Log(timer.text);
        timeLeft = float.Parse(timer.text);
        textDisplay = GameObject.Find("textDisplay").GetComponent<TMP_Text>();
    }

    void Update() {
        if (timerActive == true){
            timeLeft -= Time.deltaTime;
            timer.text = Math.Round(timeLeft).ToString();
            if(timeLeft < 0)
            {
                keyboard.SetActive(false);
                timerActive = false;
                GameObject.Find("DataWriter").GetComponent<dataWriter>().result = textDisplay.text.Remove(textDisplay.text.Length - 1);
                GameObject.Find("DataWriter").GetComponent<dataWriter>().writeResultData();
                GameObject.Find("DataWriter").GetComponent<dataWriter>().resultWriter.Close();
                GameObject.Find("DataWriter").GetComponent<dataWriter>().writer.Close();
                GameObject.Find("indestructable").GetComponent<StartTyping>().sendLSL("TypingEnd");
            }

        }
    }
    public void restart(){
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}