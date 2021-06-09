using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUIController : MonoBehaviour
{
    public static TextUIController textUI;
    public Text nameText;
    public Text speechText;
    public GameObject textObject;
    public float textDelay = 0.1f;

    void Start()
    {
        textObject.SetActive(false);
        if (textUI == null) textUI = this;
    }

    public void DisplayText(string name, string text)
    {
        StartCoroutine(DisplayTextCoroutine(name, text));
    }
    IEnumerator DisplayTextCoroutine(string name, string text)
    {
        textObject.SetActive(true);
        speechText.text = "";
        nameText.text = name;
        for (int i = 0; i < text.Length; i ++)
        {
            speechText.text = (speechText.text + text[i]);
            yield return new WaitForSeconds(textDelay);
        }
        yield return new WaitForSeconds(5);
        textObject.SetActive(false);
    }
}
