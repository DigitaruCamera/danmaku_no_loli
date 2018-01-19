using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class connectScript : MonoBehaviour {
    public InputField username, password, passwordB;
    public Text error;

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
}
