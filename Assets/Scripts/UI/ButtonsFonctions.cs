using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ButtonsFonctions : MonoBehaviour 
{
		public GameObject loadingImage;

		public void LoadScene(int level)
		{
			loadingImage.SetActive(true);
			SceneManager.LoadScene(level);
		}

		public void LoadScene(string SceneName)
		{
			loadingImage.SetActive(true);
			SceneManager.LoadScene(SceneName);
		}

		public void LoadSameScene()
		{
			loadingImage.SetActive(true);
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		public void PauseGame()
		{
			Time.timeScale = 0;
		}

		public void PlayGame()
		{
			Time.timeScale = 1;
		}

		public void HideCursor()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		public void ShowCursor()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
}