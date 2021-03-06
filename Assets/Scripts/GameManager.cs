﻿using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    [SerializeField]
    ProcScript _procScript = null;

    //public Transform cube;

    int count = 0;

    public void StartMoveBtn()
    {
        //cube.GetComponent<CubeMove>().StartMove();
    }

    public void StartProcBtn()
    {
        Debug.Log("click!!");

        for (int i = 0; i < 10; i++)
        {
            _procScript.AddProc("Proc_Work");
        }
    }

    // 각 작업 단위
    IEnumerator Proc_Work()
    {
        count++;

        int time = UnityEngine.Random.Range(0, 3);
        Debug.Log("count : " + count + ", time : " + time);

        // 각 프로시져 마다 다르게 완성됐다는걸 시뮬
        yield return new WaitForSeconds((float)time);
        _procScript.DoneProc();
    }

    void Update()
    {
        return;

        if(Input.GetMouseButton(0))
        {
            Debug.Log("Left mouse button up");
            StartCoroutine(waitForMouseDown());
        }  
    }

    public IEnumerator waitForMouseDown()
    {
        yield return new WaitForMouseDown();
        Debug.Log("Right mouse button pressed");
    }
}

public class WaitForMouseDown : CustomYieldInstruction
{
    public override bool keepWaiting
    {
        get
        {
            return !Input.GetMouseButtonDown(1);
        }
    }

    public WaitForMouseDown()
    {
        Debug.Log("Wait for Mouse right button down");
    }
}

