using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typing : MonoBehaviour
{

    Camera cam;
    private string output;
    private TMP_Text textDisplay;
    private GameObject timer;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        textDisplay = GameObject.Find("textDisplay").GetComponent<TMP_Text>();
        timer = GameObject.Find("EventSystem");
    }

    void OnMouseDown()
    {
        timer.GetComponent<TypingControl>().timerActive = true;
        Vector3 screenPos = cam.WorldToScreenPoint(this.transform.position);
        try
        {
            Touch touch = Input.GetTouch(0);
            output = "Hit, " + System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + ",Target:," + this.name + ",Target Position:, " + screenPos + ",Touch Position:, " + touch.position + "\n";
        }
        catch
        {
            output = "Hit, " + System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + ",Target:," + this.name + ",Target Position:, " + screenPos + ",Touch Position:, " + Input.mousePosition + "\n";
        }

        if (this.name == "backspace"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 2) + textDisplay.text[textDisplay.text.Length-1];
        }
        else if (this.name == "quote"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + "'" + textDisplay.text[textDisplay.text.Length-1];
        }
        else if (this.name == "enter"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + "\n" + textDisplay.text[textDisplay.text.Length-1];
        }        
        else if (this.name == "question"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + "?" + textDisplay.text[textDisplay.text.Length-1];
        }        
        else if (this.name == "comma"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + "," + textDisplay.text[textDisplay.text.Length-1];
        }        
        else if (this.name == "dot"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + "." + textDisplay.text[textDisplay.text.Length-1];
        }
        else if (this.name == "space"){
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + " " + textDisplay.text[textDisplay.text.Length-1];
        }  
        else if (this.name == "shiftL" || this.name == "shiftR" || this.name == "voice" || this.name == "special"){
            ;
        }        
        else{
            textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1) + this.name + textDisplay.text[textDisplay.text.Length-1];
        }
        GameObject.Find("DataWriter").GetComponent<dataWriter>().data = output;
        GameObject.Find("DataWriter").GetComponent<dataWriter>().writeData();
        GameObject.Find("indestructable").GetComponent<StartTyping>().sendLSL(this.name + "_h");
    }

}
