using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace dnl
{

    class Score
    {
        string sceneName;
        public void Start()
        {
            sceneName = SceneManager.GetActiveScene().name;
        }

        public int getCurrentSceneScore()
        {
            return PlayerPrefs.GetInt(sceneName + "Score");
        }

        public int getSceneScore(string scenename)
        {
            return PlayerPrefs.GetInt(sceneName + "Score");
        }

        public string[] getAllScore()
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

        public void setSceneScore(int _score)
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