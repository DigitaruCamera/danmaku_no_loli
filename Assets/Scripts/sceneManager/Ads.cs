using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {
    public int Credit_max = 10;
    public int Credit_gain = 1;
    public int Credit_gain_delay = 3600;
    public Text Credit_Ui;

    private void Update()
    {
        if (Credit_Ui != null)
        {
            Credit_Ui.text = "" + getCredit();
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstCo") == 0)
        {
            PlayerPrefs.SetInt("FirstCo", 1);
            setCredit(10);
        }
    }

    private int getTime()
    {

        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
        return cur_time;
    }

    public int getCredit()
    {
        int old_time = PlayerPrefs.GetInt("time_credit");
        int old_credit = PlayerPrefs.GetInt("credit");
        int credit = old_credit + (int)((getTime() - old_time) / Credit_gain_delay) * Credit_gain;
        if (credit > Credit_max)
        {
            credit = Credit_max;
        }
        if (credit != old_credit)
        {
            setCredit(credit);
        }
        return (credit);
    }

    public void setCredit(int _credit)
    {
        PlayerPrefs.SetInt("time_credit", getTime());
        PlayerPrefs.SetInt("credit", _credit);
    }
    public void useCredit(int _credit)
    {
        PlayerPrefs.SetInt("credit", Mathf.Clamp(PlayerPrefs.GetInt("credit") - _credit, 0, Credit_max));
    }
    public void showAds()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                setCredit(Credit_max);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
