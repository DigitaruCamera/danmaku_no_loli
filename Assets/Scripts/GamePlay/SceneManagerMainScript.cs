using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainScript : MonoBehaviour
{
    public GameObject loadingImage;

    public void LoadScene(string SceneName)
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(SceneName);
    }

    public void LoadSameScene()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadSceneCredit(string SceneName)
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(SceneName);
        if (GetComponent<Ads>() != null)
        {
            GetComponent<Ads>().useCredit(1);
        }
    }

    public void LoadSameSceneCredit()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (GetComponent<Ads>() != null)
        {
            GetComponent<Ads>().useCredit(1);
        }
    }

    public void ContinueCredit()
    {
        if (FindObjectOfType<Player>() != null && FindObjectOfType<actionPhysics>() != null)
        {
            FindObjectOfType<actionPhysics>().becameInvinsible();
            FindObjectOfType<Player>().deathDisableCredit();
        }
    }

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void PlayGame()
	{
		Time.timeScale = 1;
	}
}
