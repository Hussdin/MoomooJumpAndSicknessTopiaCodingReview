using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class LongClickScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    ListeningMiniGame listeningMiniGame;
    TroatMiniGame troatMiniGame;
    EyeMiniGame eyeMiniGame;
    TempMiniGame tempMiniGame;
    SoundManager sound;
    PredictionSystem patientidentify;

    bool pointerDown;
    float PDTimer;
    public float requredHoldTime;
    public UnityEvent onLongClick;
    [SerializeField]
    Image fillImage;

    [SerializeField]
    Image Me;
    [SerializeField]
    Sprite doneimage,circle;

    Vector3 startscale;
    bool togglePlay;

    string currenttool;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = transform;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }
    private void Awake()
    {
        startscale = this.gameObject.transform.localScale;
        idleThis(this.gameObject);  
    }
    private void Update()
    {
        checkMiniGameToDo();
    }
    private void Reset()
    {
        pointerDown = false;
        PDTimer = 0;
        fillImage.fillAmount = PDTimer / requredHoldTime;

        sound = SoundManager.sound;
        sound.BadLung.Stop();
        sound.Heart.Stop();
        sound.NormalLung.Stop();
        sound.LoadingSound.Stop();
        togglePlay = false;
    }
    private void OnDisable()
    {
        Me.sprite = circle;
    }
    public void WhenListeningDone()
    {
        Me.sprite = doneimage;
        setthistofalse();
        listeningMiniGame = ListeningMiniGame.listeningMiniGame;
        listeningMiniGame.counttoend -= 1;
        if (listeningMiniGame.counttoend <= 0)
        {
            sound.PlayeMinigameSuccess();
            listeningMiniGame.minigameDone();
        }
    }
    public void WhenTroatDone()
    {
        Me.sprite = doneimage;
        setthistofalse();
        troatMiniGame = TroatMiniGame.TroatMiniGames;
        troatMiniGame.counttoend -= 1;
        if (troatMiniGame.counttoend <= 0)
        {
            sound.PlayeMinigameSuccess();
            troatMiniGame.minigameDone();
        }
    }
    public void WhenEyeDone()
    {
        Me.sprite = doneimage;
        setthistofalse();
        eyeMiniGame = EyeMiniGame.EyeMiniGames;
        eyeMiniGame.counttoend -= 1;
        if (eyeMiniGame.counttoend <= 0)
        {
            sound.PlayeMinigameSuccess();
            eyeMiniGame.minigameDone();
        }
    }
    public void WhenTempDone()
    {
        Me.sprite = doneimage;
        setthistofalse();
        tempMiniGame = TempMiniGame.tempMiniGame;
        tempMiniGame.counttoend -= 1;
        if (tempMiniGame.counttoend <= 0)
        {
            sound.PlayeMinigameSuccess();
            tempMiniGame.minigameDone();
        }
    }
    void setthistofalse()
    {
        this.gameObject.SetActive(false);
    }

    void checkMiniGameToDo()
    {
        string currentminigame = PlayerPrefs.GetString("MiniGameMode");
        switch (currentminigame)
        {
            case "Eye":
                if (PlayerPrefs.GetString("currenttool") == "Flashlight")
                {
                    if (pointerDown)
                    {
                        PlayLoding();
                        PDTimer += Time.deltaTime;
                        if (PDTimer >= requredHoldTime)
                        {
                            if (onLongClick != null)
                            {
                                onLongClick.Invoke();
                                Reset();
                            }
                        }
                        fillImage.fillAmount = PDTimer / requredHoldTime;
                    }
                }
                break;

            case "Troat":
                if (PlayerPrefs.GetString("currenttool") == "Flashlight")
                {
                    if (pointerDown)
                    {
                        PlayLoding();
                        PDTimer += Time.deltaTime;
                        if (PDTimer >= requredHoldTime)
                        {
                            if (onLongClick != null)
                            {
                                onLongClick.Invoke();
                                Reset();
                            }
                        }
                        fillImage.fillAmount = PDTimer / requredHoldTime;
                    }
                }
                break;

            case "Listening":
                    if (PlayerPrefs.GetString("currenttool") == "Stethoscope")
                    {
                        if (pointerDown)
                        {
                            checkdisease();
                            PDTimer += Time.deltaTime;
                            if (PDTimer >= requredHoldTime)
                            {
                                if (onLongClick != null)
                                {
                                    onLongClick.Invoke();
                                    Reset();
                                }
                            }
                            fillImage.fillAmount = PDTimer / requredHoldTime;
                        }
                    }
                break;

            case "Temp":
                if (PlayerPrefs.GetString("currenttool") == "Thermometer")
                {
                    if (pointerDown)
                    {
                        PlayLoding();
                        PDTimer += Time.deltaTime;
                        if (PDTimer >= requredHoldTime)
                        {
                            if (onLongClick != null)
                            {
                                onLongClick.Invoke();
                                Reset();
                            }
                        }
                        fillImage.fillAmount = PDTimer / requredHoldTime;
                    }
                }
                break;
            case "Amox":
                if (PlayerPrefs.GetString("currenttool") == "FullSy")
                {
                    if (pointerDown)
                    {
                        PlayLoding();
                        PDTimer += Time.deltaTime;
                        if (PDTimer >= requredHoldTime)
                        {
                            if (onLongClick != null)
                            {
                                onLongClick.Invoke();
                                Reset();
                            }
                        }
                        fillImage.fillAmount = PDTimer / requredHoldTime;
                    }
                }
                break;
        }
    }
    void idleThis(GameObject obj)
    {
        Sequence Idle = DOTween.Sequence();
        Idle.Append(obj.GetComponent<RectTransform>().DOScale(startscale, 1f).SetEase(Ease.InOutCubic))
            .Append(obj.GetComponent<RectTransform>().DOScale(startscale + new Vector3(0.2f, 0.2f,0), 1f).SetEase(Ease.InOutCubic))
            .OnComplete(() => idleThis(obj));

    }

    void checkdisease()
    {
        sound = SoundManager.sound;
        patientidentify = PredictionSystem.predicsys;
        GameObject patient = patientidentify.Patient;
        if (!togglePlay)
        {
            if (this.gameObject.name != "Lung")
            {
                sound.playHerat();
            }
            else
            {
                if (patient.GetComponent<Profile>().Disease == "ไข้หวัดปอดอักเสบ")
                {
                    sound.playBLung();
                }
                else
                {
                    sound.playNLung();
                }

            }
            togglePlay = true;
        }
    }

    void PlayLoding()
    {
        sound = SoundManager.sound;
        if (!togglePlay)
        {
            sound.PlayLoading();
            togglePlay = true;
        }
    }
}
