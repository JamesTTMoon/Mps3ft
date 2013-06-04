using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

public class HtIndvBase : MonoBehaviour {

    public string mName, mState;
    public Godirum mGod;
    public List<GameObject> arrParent;

    protected  VecRot mTarget;
    protected Vector3 mPosition, mRotation;
    protected string mAction;

    int? mCounter;
	
	public virtual void Start () {
	
	}
	
    public virtual void Update () {
        CheckTimer ();
	}

    public void SetState(string pStt)
    {
        mState = pStt;
    }

    public void SetTarget(Vector3 pAe)
    {
        mTarget = new VecRot (pAe.x, pAe.y, pAe.z);
    }

    
    public void SetTarget (VecRot pTarVr)
    {
        mTarget = pTarVr;
    }

    public void SetGod(Godirum pGod)
    {
        mGod = pGod;
    }

    public void SetTimerAction(int pLimitNum, string pAction)
    {
        mCounter = pLimitNum;
        mAction = pAction;
    }

    protected virtual void CheckTimer()
    {
        if (mCounter.HasValue) {
            if (mCounter < 0) {
                mCounter = null;
                TimerAction();
                mAction = "";
            } else 
                mCounter--;
        }
    }

    protected virtual void TimerAction()
    {
        if (mAction == "Destroy")
            Destroy (gameObject);
    }



}
