using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class AmSceneBase : MonoBehaviour {
    
    public uint mCounter = 0, mSeldomActionNum = 90;
    public string mFldTexture; //, mName = "<< SceneBase >>";
    public float mTimeLooseAtStartPoint = 0.1f;
    public HtRsrcMan mRscrcMan;
    
    // UI Control...
    public bool muiActive;
    
    // Network Related...
    //public AmNetBase mNetwork;
    
    // Debugging related...
    public AmUI myGUI = new AmUI(); 
    public int muiCol, muiRow;
    
    ~AmSceneBase() {
        //Ag.LogIntenseWord("  >> Delete of AmSceneBase Object <<  ");
    }

	//  ////////////////////////////////////////////////     Starting Init Job
	public virtual void Start () {
        Ag.LogNewScene(GetType().ToString(), "Start");
        mRscrcMan = new HtRsrcMan( GetType().ToString() );
        
        SetAsset();
        StartCoroutine("Wait");
        
        //Ag.LogString("   AmSceneBase :: Start() is finished ~~~ ");
	}
    
    public IEnumerator Wait() {
        ; //Ag.LogString("   AmSceneBase :: Wait for " + mTimeLooseAtStartPoint + " sec ");
        yield return new WaitForSeconds(mTimeLooseAtStartPoint);
        ; //Ag.LogString("   AmSceneBase :: Wait for " + mTimeLooseAtStartPoint + " sec   !!!  D O N E  !!!");
        BaseStartSetting();
    }
    
    public virtual void OnDisable() {
        //AgStt.muiHQ.DetachScene(this);
    }
    
    public virtual void BaseStartSetting() {
        Ag.LogString( "   AmSceneBase::BaseStartSetting  Part of >>>>>  " + GetType().ToString() + "   <<<<<");
        
        
    }
    
    public virtual void OnApplicationQuit() {
        Ag.LogString ("   AmSceneBase :: OnApplicationQuit");
        //AgStt.StopAllNetwork();
    }
    
    public virtual void SetAsset() {
    }
	
	//  ////////////////////////////////////////////////     Update related
	public virtual void Update () {
        mCounter++;
        if ((mCounter % mSeldomActionNum) == 0) SeldomAction();
	}

    public virtual void SeldomAction() {
        Ag.LogNewLine(2);
        Ag.LogString("AgDontDestroy :: SeldomAction  ]]] " + GetType() + " [[[  >>>>> " + mCounter + " <<<<<");
    }
    
    //  ////////////////////////////////////////////////     OnGUI related
    public virtual void OnGUI() {
    }
    
    public bool IsUIReady() {
        if (myGUI == null)
            return false;
        else
            return true;
    }
    
    
    
    
    
}
