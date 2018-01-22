using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dnl;

public class Player : MonoBehaviour {
    public GameObject UI_death;
    public GameObject UI_pause;
    bool pause = true;
    bool death = true;

    public void pauseDisable()
    {
        pause = false;
        UI_pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void pauseEnable()
    {
        pause = true;
        UI_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void deathDisableFree()
    {
        death = false;
        UI_death.SetActive(false);
        Time.timeScale = 1;
    }

    public void deathDisableCredit()
    {
        if (FindObjectOfType<Ads>() != null && FindObjectOfType<Ads>().getCredit() > 0)
        {
            death = false;
            UI_death.SetActive(false);
            Time.timeScale = 1;
            FindObjectOfType<Ads>().useCredit(1);
        }
    }

    public void deathEnable()
    {
        death = true;
        UI_death.SetActive(true);
        Time.timeScale = 0;
    }
}
