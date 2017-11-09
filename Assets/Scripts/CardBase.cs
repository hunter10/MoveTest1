using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CardBase : MonoBehaviour {

    public Vector3 originalPos;

    public delegate void CardArrived(); //
    public CardArrived onCardArrived;

    void Start()
    {
        originalPos = transform.position;
    }

    public void StartMove(Transform dest)
    {
        Tween myTween = transform.DOMove(dest.position, 0.5f);
        myTween.SetEase(Ease.InOutQuint);
        myTween.OnComplete(myFunction);
    }
        
    void myFunction()
    {
        if (onCardArrived != null)
        {
            onCardArrived();
            onCardArrived = null;
        }
    }

    IEnumerator moveOriginalPos()
    {
        yield return new WaitForSeconds(1f);
        transform.position = originalPos;
    }
}



