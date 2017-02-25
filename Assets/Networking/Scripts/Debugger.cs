using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debugger : MonoBehaviour {
    public static Debugger instance { get; set; }
    Text debugText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        debugText = GetComponent<Text>();
    }

    public void DebugOut(string msg)
    {
        debugText.text = msg;
    }

    public void AppendMsg(string msg)
    {
        debugText.text = "\n" + msg;
    }
}
