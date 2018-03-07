using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dnl;

public class Player : MonoBehaviour
{
    public GameObject UI_death;
    public GameObject UI_pause;
    public Image UI_bombBar;
    public Text UI_point;
    public Text UI_timer_min;
    public Text UI_timer_sec;
    public Text UI_timer_mil;
    float unscaledTime;
    bool pause = false;
    bool death = false;

    void Update()
    {
        affTimer();
        Dialogue();
        unscaledTime += Time.unscaledDeltaTime;
    }

    public void pauseDisable()
    {
        if (pause == true)
        {
            pause = false;
            if (UI_pause != null) UI_pause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void pauseEnable()
    {
        if (pause == false)
        {
            pause = true;
            if (UI_pause != null) UI_pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void deathDisableFree()
    {
        if (death == true)
        {
            death = false;
            if (UI_death != null) UI_death.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void deathDisableCredit()
    {
        if (death == true)
        {
            if (FindObjectOfType<Ads>() != null && FindObjectOfType<Ads>().getCredit() > 0)
            {
                death = false;
                if (UI_death != null) UI_death.SetActive(false);
                Time.timeScale = 1;
                if (FindObjectOfType<Ads>() != null) FindObjectOfType<Ads>().useCredit(1);
            }
        }
    }

    public void deathEnable()
    {
        if (death == false)
        {
            death = true;
            if (UI_death != null) UI_death.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BombBar(float timebomb, float delay_bomb)
    {
        float percent_bomb = Mathf.Clamp((timebomb - Time.time) / delay_bomb, 0f, 1f);
        if (UI_bombBar != null) UI_bombBar.fillAmount = 1 - percent_bomb;
    }

    public void affScore(int currentScore)
    {
        if (UI_point != null) UI_point.text = "" + currentScore;
    }

    public void saveScore(int currentScore)
    {
        Debug.Log("score saved :" + currentScore);
        new Score().setSceneScore(currentScore);
        new Score().setSceneLastScore(currentScore);
    }

    public void affTimer()
    {
        if (UI_timer_min != null) UI_timer_min.text = "" + ((int)((Time.fixedTime / 60) % 60)).ToString("00");
        if (UI_timer_sec != null) UI_timer_sec.text = "" + ((int)(Time.fixedTime % 60)).ToString("00");
        if (UI_timer_mil != null) UI_timer_mil.text = "" + ((int)((Time.fixedTime * 100) % 100)).ToString("00");
    }

    public Text UI_dialogue;
    public Image imgRightDialogue;
    public Image imgLeftDialogue;
    public Image imgRightEmotion;
    public Image imgLeftEmotion;
    public float delayLetterDialogue = 0.1f;
    public float delayBeforeStart = 0.5f;
    public string[] dialogues;
    public Sprite[] spriteDialogue;
    public Sprite[] spriteEmotion;
    float delayedLetter = 0;
    int iLetter = 0;
    int iText = 0;
    string[] currentDialogue;
    bool sensImage = true;
    bool allDialogueEnd = false;

    IEnumerator Depart()
    {
        if (UI_dialogue != null) UI_dialogue.text = "Ready ?";
        yield return new WaitForSecondsRealtime(delayBeforeStart);
        if (UI_dialogue != null) UI_dialogue.text = "GO";
        yield return new WaitForSecondsRealtime(delayBeforeStart);
        Time.timeScale = 1;
        imgRightDialogue.gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 0;
        currentDialogue = dialogues[iText].Split(';');
        setImage();
    }

    void Dialogue()
    {
        if (dialogues.Length == iText && allDialogueEnd == false)
        {
            allDialogueEnd = true;
            StartCoroutine(Depart());
        }
        else if (dialogues.Length != iText)
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                || (Input.touchCount == 0 && Input.GetButtonDown("Fire1")))
            {
                clickDialogue();
            }
            if (delayedLetter < unscaledTime && currentDialogue[2].Length > iLetter)
            {
                delayedLetter = unscaledTime + delayLetterDialogue;
                iLetter++;
            }
            if (UI_dialogue != null && allDialogueEnd == false) UI_dialogue.text = currentDialogue[2].Substring(0, iLetter);
        }
    }

    void setImage()
    {
        if (sensImage)
        {
            for (int i = 0; i < spriteDialogue.Length; i++)
            {
                if (spriteDialogue[i].name == currentDialogue[0])
                {
                    if (imgLeftDialogue != null) imgLeftDialogue.enabled = false;
                    if (imgRightDialogue != null) imgRightDialogue.enabled = true;
                    if (imgRightDialogue != null) imgRightDialogue.sprite = spriteDialogue[i];
                }
            }
            for (int i = 0; i < spriteEmotion.Length; i++)
            {
                if (spriteEmotion[i].name == currentDialogue[1])
                {
                    if (imgLeftEmotion != null) imgLeftEmotion.enabled = false;
                    if (imgRightEmotion != null) imgRightEmotion.enabled = true;
                    if (imgRightEmotion != null) imgRightEmotion.sprite = spriteEmotion[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < spriteDialogue.Length; i++)
            {
                if (spriteDialogue[i].name == currentDialogue[0])
                {
                    if (imgRightDialogue != null) imgRightDialogue.enabled = false;
                    if (imgLeftDialogue != null) imgLeftDialogue.enabled = true;
                    if (imgLeftDialogue != null) imgLeftDialogue.sprite = spriteDialogue[i];
                }
            }
            for (int i = 0; i < spriteEmotion.Length; i++)
            {
                if (spriteEmotion[i].name == currentDialogue[1])
                {
                    if (imgRightEmotion != null) imgRightEmotion.enabled = false;
                    if (imgLeftEmotion != null) imgLeftEmotion.enabled = true;
                    if (imgLeftEmotion != null) imgLeftEmotion.sprite = spriteEmotion[i];
                }
            }
        }
        if (dialogues.Length <= iText)
        {
            if (imgRightDialogue != null) imgRightDialogue.enabled = false;
            if (imgLeftDialogue != null) imgLeftDialogue.enabled = false;
            if (imgRightEmotion != null) imgRightEmotion.enabled = false;
            if (imgLeftEmotion != null) imgLeftEmotion.enabled = false;
        }
    }

    void clickDialogue()
    {
        if (currentDialogue[2].Length <= iLetter)
        {
            iLetter = 0;
            iText++;
            if (dialogues.Length > iText)
                currentDialogue = dialogues[iText].Split(';');
            sensImage = !sensImage;
            setImage();
        }
        else
        {
            iLetter = currentDialogue[2].Length;
        }
    }
}