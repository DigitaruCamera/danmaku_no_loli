using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dnl;

public class Player : MonoBehaviour {
    public GameObject UI_death;
    public GameObject UI_pause;
    public Image UI_bombBar;
    bool pause = true;
    bool death = true;

    public void pauseDisable()
    {
        pause = false;
        if (UI_pause != null) UI_pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void pauseEnable()
    {
        pause = true;
        if (UI_pause != null) UI_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void deathDisableFree()
    {
        death = false;
        if (UI_death != null) UI_death.SetActive(false);
        Time.timeScale = 1;
    }

    public void deathDisableCredit()
    {
        if (FindObjectOfType<Ads>() != null && FindObjectOfType<Ads>().getCredit() > 0)
        {
            death = false;
            if (UI_death != null) UI_death.SetActive(false);
            Time.timeScale = 1;
            if (FindObjectOfType<Ads>() != null) FindObjectOfType<Ads>().useCredit(1);
        }
    }

    public void deathEnable()
    {
        death = true;
        if (UI_death != null) UI_death.SetActive(true);
        Time.timeScale = 0;
    }

    public void BombBar (float timebomb, float delay_bomb)
    {
        float percent_bomb = Mathf.Clamp((timebomb - Time.time) / delay_bomb, 0f, 1f);
        if (UI_bombBar != null) UI_bombBar.fillAmount = 1 - percent_bomb;
    }
}
