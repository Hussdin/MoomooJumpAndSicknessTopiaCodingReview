using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CameraIdleControll : MonoBehaviour
{
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject stoppos, startpos,StartTxt;
    bool plus;
    Vector3 startscale;
    private void Awake()
    {
        startscale = StartTxt.transform.localScale;
        idleThis(StartTxt);
    }
    void idle()
    {
        if (plus)
        {
            cam.transform.position += Vector3.MoveTowards(cam.transform.position, stoppos.transform.position, 0.3f)*Time.deltaTime;
        }
        else
        {
            cam.transform.position += Vector3.MoveTowards(cam.transform.position, startpos.transform.position, 0.3f) * Time.deltaTime;
        }
    }
    void checkcondition()
    {
        if(cam.transform.position == startpos.transform.position)
        {
            plus = true;
        }
        else if(cam.transform.position == stoppos.transform.position)
        {
            plus = false;
        }
    }

    void idleThis(GameObject obj)
    {
        Sequence Idle = DOTween.Sequence();
        Idle.Append(obj.GetComponent<RectTransform>().DOScale(startscale, 0.7f).SetEase(Ease.InOutCubic))
            .Append(obj.GetComponent<RectTransform>().DOScale(startscale + new Vector3(0.2f, 0.2f, 0), 0.7f).SetEase(Ease.InOutCubic))
            .OnComplete(() => idleThis(obj));

    }
}
