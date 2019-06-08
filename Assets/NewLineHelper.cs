using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewLineHelper : MonoBehaviour
{
    public Text[] texts;
    public string oldString;
    public bool wantTab = false;
    // Start is called before the first frame update
    void Start()
    {
        //  string newText = textUI.text.Replace ("tab", "\n");      
        //  textUI.text = newText;
        NewLineAll();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NewLineAll()
    {
        foreach (Text text in texts)
        {
            NewLine(text, oldString, wantTab ? "\n\t" : "\n");
        }
    }
    void NewLine(Text textUI, string replaceStr, string newStr)
    {
        string newText = textUI.text.Replace(replaceStr, newStr);
        textUI.text = newText;
    }



}
