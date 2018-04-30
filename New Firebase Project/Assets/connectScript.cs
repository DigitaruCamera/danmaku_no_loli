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
public class Score
{
    public string sceneName = "";
    public long score = 0L;

    public Score(string _sceneName, long _score)
    {
        sceneName = _sceneName;
        score = _score;
    }
}

[Serializable]
public class User
{
    public string name = "";
    public string email = "";
    public string uid;
    public Score []scores;
    public User(string _name, string _email, string _uid)
    {
        Debug.Log("name" + _name + " ;; email" + _email + " ;; uid" + _uid);
        name = _name;
        email = _email;
        uid = _uid;
    }

    public void addScore(long score)
    {
        bool changed = false;
        string sceneName = SceneManager.GetActiveScene().name;
        foreach (Score current in scores)
        {
            if (current.sceneName == sceneName && current.score <= score)
            {
                current.score = score;
                changed = true;
            }
        }
        if (changed == false)
        {
            List<Score> scoresList = new List<Score>(scores);
            scoresList.Add(new Score(sceneName, score));
            scores = scoresList.ToArray();
        }
    }
}


public class connectScript : MonoBehaviour {
    public InputField username, password, passwordB;
    public Text error;
    public User user;

    public void register()
    {
        error.text = "register";
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
                user = new User(newUser.DisplayName, newUser.Email, newUser.UserId);
                saveUser();
            });
        } else
        {
            error.text = "not same password";
        }
    }

    public void connect()
    {
        error.text = "connect";
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
            user = new User(newUser.DisplayName, newUser.Email, newUser.UserId);
            saveUser();
        });
    }

    public void connectWithGoogle()
    {
        Firebase.Auth.FirebaseUser newUser;
        error.text = "connectWithGoogle";
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

            newUser = task.Result;
            if (newUser != null)
            {
                string name = newUser.DisplayName;
                string email = newUser.Email;
                System.Uri photo_url = newUser.PhotoUrl;
                string uid = newUser.UserId;
                Debug.Log(user);
                error.text = "Aname : " + name + "\n" +
                    "email : " + email + "\n" +
                    "photo_url : " + photo_url + "\n" +
                    "uid : " + uid;
            }
            user = new User(newUser.DisplayName, newUser.Email, newUser.UserId);
            saveUser();
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
        newUser = auth.CurrentUser;
        user = new User(newUser.DisplayName, newUser.Email, newUser.UserId);
        saveUser();
        if (newUser != null)
        {
            string name = newUser.DisplayName;
            string email = newUser.Email;
            System.Uri photo_url = newUser.PhotoUrl;
            string uid = newUser.UserId;
            Debug.Log(user);
            error.text = "Bname : " + name + "\n" +
                "email : " + email + "\n" +
                "photo_url : " + photo_url + "\n" +
                "uid : " + uid;
        }
    }

    public void loadUser()
    {
        string jsonUser = PlayerPrefs.GetString("user");
        user = JsonUtility.FromJson<User>(jsonUser);
        error.text = "load: \n";
        error.text += jsonUser;
    }

    public void saveUser()
    {
        string jsonUser = JsonUtility.ToJson(user);
        PlayerPrefs.SetString("user", jsonUser);
        error.text = "save: \n";
        error.text += jsonUser;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://danmakunololi.firebaseio.com/");

        Firebase.Database.DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        reference.Child("user").Child(user.uid).SetRawJsonValueAsync(jsonUser);
    }

    public void AddScoreAndSave(long score)
    {
        user.addScore(score);
        saveUser();
    }

}
