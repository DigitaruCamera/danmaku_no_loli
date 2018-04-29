using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

[Serializable]
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
        if (PlayerPrefs.GetInt(sceneName + "Score") < _score)
        {
            PlayerPrefs.SetInt(sceneName + "Score", _score);
        }
    }

    public void setSceneLastScore(int _score)
    {
        PlayerPrefs.SetInt(sceneName + "LastScore", _score);
    }
}

[Serializable]
public class User
{
    public string name, mail;
    public Score score;
    public User(string _name, string _mail)
    {
        name = _name;
        mail = _mail;
    }
}


public class connectScript : MonoBehaviour {
    public InputField username, password, passwordB;
    public Text error;
    public User user;
    public void register()
    {
        if (password.text == passwordB.text)
        {
            FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(username.text, password.text).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    error.text = "CreateUserWithEmailAndPasswordAsync was canceled.";
                    return;
                }
                if (task.IsFaulted)
                {
                    error.text = "CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception;
                    return;
                }

                // Firebase user has been created.
                Firebase.Auth.FirebaseUser newUser = task.Result;
                error.text = "Firebase user created successfully: {" + newUser.DisplayName + "} ({"+ newUser.UserId + "})";
            });
        } else
        {
            error.text = "not same password";
        }
    }

    public void connect()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(username.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                error.text = "SignInWithEmailAndPasswordAsync was canceled.";
                return;
            }
            if (task.IsFaulted)
            {
                error.text = "SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception;
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            error.text = "User signed in successfully: {" + newUser.DisplayName + "} ({" + newUser.UserId + "})";
        });
    }

    public void connectWithGoogle()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.Credential credential =
        Firebase.Auth.GoogleAuthProvider.GetCredential("876083363494-gj340344fknakjriiu685etf9cup72c9.apps.googleusercontent.com", "9nNI1bMSQsIMHa50m1bkcqsb");
        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            string name = user.DisplayName;
            string email = user.Email;
            System.Uri photo_url = user.PhotoUrl;
            // The user's Id, unique to the Firebase project.
            // Do NOT use this value to authenticate with your backend server, if you
            // have one; use User.TokenAsync() instead.
            string uid = user.UserId;
            error.text = "name : " + name + "\n" +
                "email : " + email + "\n" +
                "photo_url : " + photo_url + "\n" +
                "uid : " + uid;
        }
    }

    void loadUser()
    {
        string jsonUser = PlayerPrefs.GetString("user");
        JsonUtility.FromJson<User>(jsonUser);
        Debug.Log("loadUser");
        Debug.Log(jsonUser);
    }

    void saveUser()
    {
        string jsonUser = JsonUtility.ToJson(user);
        PlayerPrefs.SetString("user", jsonUser);
        Debug.Log("saveUser");
        Debug.Log(jsonUser);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://danmakunololi.firebaseio.com/");

        Firebase.Databases.DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        mDatabaseRef.Child("users").Child("id_player").SetRawJsonValueAsync(json);
    }
}
