using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dnl;

public class Player : MonoBehaviour {
    public GameObject UI_death;
    public GameObject UI_pause;
    public Image UI_bombBar;
    public Text UI_point;
    float unscaledTime;
    bool pause = false;
    bool death = false;

    void Update ()
    {
        unscaledTime += Time.unscaledDeltaTime;
        Dialogue();
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

    public void BombBar (float timebomb, float delay_bomb)
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
        new Score().setSceneScore(currentScore);
    }

    public Text UI_dialogue;
    public Image imgRightDialogue;
    public Image imgLeftDialogue;
    public float delayLetterDialogue = 0.1f;
    public string[] dialogues;
    public Sprite[] spriteDialogue;
    float delayedLetter = 0;
    int iLetter = 0;
    int iText = 0;
    string[] currentDialogue;
    bool dialogFin = false;
    bool sensImage = true;
    bool allDialogueEnd = false;
    IEnumerator Depart()
    {
        if (UI_dialogue != null) UI_dialogue.text = "3";
        yield return new WaitForSecondsRealtime(1);
        if (UI_dialogue != null) UI_dialogue.text = "2";
        yield return new WaitForSecondsRealtime(1);
        if (UI_dialogue != null) UI_dialogue.text = "1";
        yield return new WaitForSecondsRealtime(1);
        if (UI_dialogue != null) UI_dialogue.text = "GO";
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1;
        imgRightDialogue.gameObject.transform.parent.gameObject.SetActive(false);
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
            Time.timeScale = 0;
            currentDialogue = dialogues[iText].Split(';');
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                || Input.GetButtonDown("Fire1"))
            {
                clickDialogue();
            }
            if (delayedLetter < unscaledTime && currentDialogue[2].Length > iLetter && dialogFin == false)
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
            foreach (Sprite img in spriteDialogue)
            {
                print(img.name + " == " + currentDialogue[0]);
                if (img.name == currentDialogue[0])
                {
                    print("oui");
                    if (imgRightDialogue != null) imgRightDialogue.sprite = img;
                    if (imgLeftDialogue != null) imgRightDialogue.sprite = null;
                }
            }
        } else
        {
            foreach (Sprite img in spriteDialogue)
            {
                if (img.name == currentDialogue[0])
                {
                    if (imgLeftDialogue != null) imgRightDialogue.sprite = img;
                    if (imgRightDialogue != null) imgRightDialogue.sprite = null;
                }
            }
        }
    }

    void clickDialogue()
    {
        setImage();
        if (currentDialogue[2].Length <= iLetter && dialogFin == false)
        {
            iLetter = 0;
            dialogFin = true;
            if (iText < dialogues.Length)
            {
                sensImage = !sensImage;
                dialogFin = false;
                iText++;
            }
        }
        else if (dialogFin == false)
        {
            iLetter = currentDialogue[2].Length;
        }
    }
}
