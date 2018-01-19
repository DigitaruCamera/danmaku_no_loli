using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour {
    public float delayLetter = 0.1f;
    public string[] dialogues;
    public GameObject[] prefabs;
    float delayedLetter = 0;
    int iLetter = 0;
    int iText = 0;
    string[] currentText;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void Update()
    {
        currentText = dialogues[iText].Split(';');
        if (delayedLetter < Time.time && currentText[2].Length > iLetter)
        {
            delayedLetter = Time.time + delayLetter;
            iLetter++;
        }
        GetComponentInChildren<Text>().text = currentText[2].Substring(0, iLetter);
    }
    
    void OnClick()
    {
        print("is clicked");
        currentText = dialogues[iText].Split(';');
        if (currentText[2].Length <= iLetter)
        {
            print("change text");
            iLetter = 0;
            iText++;
        } else
        {
            print("full");
            iLetter = currentText[2].Length;
        }
    }
}
