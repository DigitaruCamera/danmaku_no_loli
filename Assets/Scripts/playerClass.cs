using UnityEngine;
using System.Collections;
//using UnityEditor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace dnl
{
    public class Score
    {
        string sceneName;
        public void Start()
        {
            sceneName = SceneManager.GetActiveScene().name;
        }

        int getSceneScore()
        {
            return PlayerPrefs.GetInt(sceneName + "Score");
        }

        string[] getAllScore()
        {
            List<string> scores = new List<string>();
            int i = 0;
            int nbScene = SceneManager.sceneCount;
            while (i < nbScene)
            {
                int score = PlayerPrefs.GetInt(SceneManager.GetSceneAt(i).name + "Score");
                scores.Add(sceneName + " : " + score);
                i++;
            }
            return scores.ToArray();
        }

        void setSceneScore(int _score)
        {
            if (PlayerPrefs.GetInt(sceneName + "Score") < _score)
            {
                PlayerPrefs.SetInt(sceneName + "Score", _score);
            }
        }
    }

    public class User
    {
        bool pause = false;
        Score score;
        
        void changePause()
        {
            pause = !pause;
        }

        bool getPause()
        {
            return pause;
        }
    }
}