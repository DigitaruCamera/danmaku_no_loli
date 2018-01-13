﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainScript : MonoBehaviour {

	void Start () {
		Time.timeScale = 1;
	}
		
    public void LoadSceneCredit(string SceneName)
    {
        int _Credit = 1;
        SceneManager.LoadScene(SceneName);
        if (GetComponent<Ads>() != null)
        {
            GetComponent<Ads>().useCredit(_Credit);
        }
    }
}
