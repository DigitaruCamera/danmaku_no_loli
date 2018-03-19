using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnload : MonoBehaviour {
	void Start () {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            DontDestroyOnLoad(go);
        }
        Destroy(GetComponent<DontDestroyOnload>());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
