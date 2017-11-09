using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CenterCube : MonoBehaviour
{

    // 게임스타트 버튼 이벤트 받으면
    // 48장 카드 랜덤하게 섞어서 가운데에 쌓기
    // 오브젝트 풀 사용 준비

    public GameObject cardBase;

    float cardheight = 0.02f;

    List<GameObject> _cardDeck = new List<GameObject>();
    public List<Transform> _userPos = new List<Transform>();

    public ProcScript _procScript = null;

    int currCardIdx = 0;
    int currPosIdx = 0;

    public void MakeDeck()
    {
        for (int i = 0; i < 48; i++)
        {
            GameObject card = Instantiate(cardBase, new Vector3(transform.position.x, transform.position.y + cardheight * i, transform.position.z), Quaternion.identity) as GameObject;
            card.transform.parent = this.transform;
            card.GetComponent<CardBase>().onCardArrived = OnCardArrived;
            _cardDeck.Add(card);
        }
    }

    /*
     * 일반버전    
    public void MoveToUser()
    {
        if (currCardIdx > 2)
            return;
    
        _cardDeck[currCardIdx].GetComponent<CardBase>().StartMove(_userPos[currPosIdx]);
        currCardIdx++;
        currPosIdx++;
    }

    void OnCardArrived()
    {
        Debug.Log("왔네~");
        MoveToUser();
    }
    *
    */

    bool arrived = false;
    public void MoveToUser()
    {
        _procScript.AddProc("ProcMoveToUser");
        _procScript.AddProc("ProcMoveToUser");
    }

    IEnumerator ProcMoveToUser()
    {
        _cardDeck[currCardIdx].GetComponent<CardBase>().StartMove(_userPos[currPosIdx]);
        currCardIdx++;
        currPosIdx++;

        while(!arrived)
        {
            yield return null;
        }

        Debug.Log("작업완료");
    }

    void OnCardArrived()
    {
        arrived = true;
        _procScript.DoneProc();
    }
}