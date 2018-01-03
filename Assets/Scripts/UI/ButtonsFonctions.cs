using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ButtonsFonctions : MonoBehaviour 
{
		public GameObject Player;
		public GameObject loadingImage;

		public void LoadScene(int level)
		{
			loadingImage.SetActive(true);
			SceneManager.LoadScene(level);
		}

		public void LoadSameScene()
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		public void PauseGame()
		{
			Time.timeScale =0;
			GameObject.Find ("Player_physic").GetComponent<PlayerMainScript_old>().enabled = false;
		}

		public void PlayGame()
		{
			Time.timeScale =1;
			GameObject.Find ("Player_physic").GetComponent<PlayerMainScript_old>().enabled = true;
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
