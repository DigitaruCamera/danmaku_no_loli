using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainScript : MonoBehaviour {

	void Start () {
		Time.timeScale = 1;
	}
		
    public void LoadSceneCredit(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        if (GetComponent<Ads>() != null)
        {
            GetComponent<Ads>().useCredit(1);
        }
    }

    public void ContinueCredit()
    {
        if (FindObjectOfType<Player>() != null)
        {
            FindObjectOfType<Player>().deathDisableCredit();
        }
    }
}
