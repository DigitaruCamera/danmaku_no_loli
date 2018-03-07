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
    
        // use to Get bestScore and LastScore
        // scenename = "XXXLastScore" give last score do
        // scenename = "XXXScore" give best score ever do
        public int getSceneScore(string scenename)
        {
            Debug.Log(scenename);
            return PlayerPrefs.GetInt(sceneName);
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
            Debug.Log(sceneName + "Score");
            if (PlayerPrefs.GetInt(sceneName + "Score") < _score)
            {
                PlayerPrefs.SetInt(sceneName + "Score", _score);
            }
        }

        public void setSceneLastScore(int _score)
        {
            Debug.Log(sceneName + "LastScore");
            PlayerPrefs.SetInt(sceneName + "LastScore", _score);
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