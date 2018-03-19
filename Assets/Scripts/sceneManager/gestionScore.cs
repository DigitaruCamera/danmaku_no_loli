using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using dnl;

public class gestionScore : MonoBehaviour {
    Score scoreManager = new Score();
	void Update () {
        foreach(GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            if (score.GetComponent<Text>() != null) score.GetComponent<Text>().text = "" + scoreManager.getSceneScore(score.name);
        }
	}
}
