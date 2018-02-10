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
    bool dialogFin = false;
    void Dialogue()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            || (Input.touchCount == 0 && Input.GetButtonDown("Fire1")))
        {
            if (currentText[2].Length <= iLetter && dialogFin == false)
            {
                iLetter = 0;
                dialogFin = true;
                if (iText < dialogues.Length - 1)
                {
                    dialogFin = false;
                    iText++;
                }
            }
            else if (dialogFin == false)
            {
                iLetter = currentText[2].Length;
            }
        }
        currentText = dialogues[iText].Split(';');
        if (delayedLetter < Time.time && currentText[2].Length > iLetter && dialogFin == false)
        {
            delayedLetter = Time.time + delayLetter;
            iLetter++;
        }
        GetComponent<Text>().text = currentText[2].Substring(0, iLetter);
    }
}
