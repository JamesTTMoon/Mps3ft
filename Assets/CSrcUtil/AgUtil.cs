using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class AgUtil {
    
    public static List<Texture2D> arrSomeTexture = new List<Texture2D>();
    
    
    // Event Related Variables...
    public static bool mAppleReviewShown;
    
    
    
    public static string 
        mAppleReviewURL = "itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?id=557593268&onlyLatestVersion=true&pageNumber=0&sortOrdering=1&type=Purple+Software",
        mAppStoreURL = "http://itunes.apple.com/us/app/real-penalty-shoot-out-online/id557593268?l=ko&ls=1&mt=8", // it is RPS online
        //mAppleReviewURL = "itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?id=568000625&onlyLatestVersion=true&pageNumber=0&sortOrdering=1&type=Purple+Software",
        //mAppStoreURL = "http://itunes.apple.com/app/psykick-battle5/id568000625?l=ko&ls=1&mt=8",
        mRpsFBURL = "http://www.facebook.com/RPSonline";
    
    public static int mMajorVer, mMinorVer;
    
    public static int mRandomCounter = 81000;
    
    public static int RandomInclude(int pMin, int pMax)
    {
        int wid = pMax - pMin + 1;
        AgUtil.mRandomCounter += 5;
        double ran = (DateTime.Now.Millisecond + 1) * 1.2443423342 * pMax * AgUtil.mRandomCounter / (AgUtil.mRandomCounter + 7.33459f);
        ran = pMax * (ran - (int)ran) * 10;
        
        //DateTime.Now.Millisecond.ToString ().HtLog ();
        //ran.ToString ().HtLog (); 
        
        AgUtil.mRandomCounter += ((int)ran) % 4;
        
        switch (((int)ran) % 4) {
        case 0:
            ran += (DateTime.Now.Second);
            break;
        case 1:
            ran += (DateTime.Now.Hour );
            break;
        case 2:
            ran += (DateTime.Now.Minute );
            break;
        case 3:
            ran += (DateTime.Now.Day);
            break;
        }
        
        ran = pMax * (ran - (int)ran) * 100;
        
        if (AgUtil.mRandomCounter > 99999) 
            AgUtil.mRandomCounter -= 12345;
        
        //(" Mili " + DateTime.Now.Millisecond + " ,  " + AgUtil.mRandomCounter + " ,   " + ran).HtLog ();
        return ( ((int)ran) % wid) + pMin;
    }
    
    public static bool VersionChk () {
        if ( mMajorVer == 1 && mMinorVer ==  0 ) //0 )
            return true;
        else 
            return false;
    }
    
    public static string GetLanguage () {
        return Application.systemLanguage.ToString() ;
    }
    
    public static Texture2D GetTexture2D ( string pName ) {
        string fullName = pName + AgUtil.GetLanguage();
        
        AgUtil.GetTextureInArr(fullName, arrSomeTexture);
        return null;
    }
    
    public static Texture2D GetMessage ( string pFolder, string pName ) {
        Texture2D rVal = (Texture2D)Resources.Load(pFolder + "/Msg/Eng_" + pName);
        string fullName = pFolder + "/Msg/" + Ag.mgLanguage + "_" + pName;  // "310Manage/Msg/WarningLog_Kor"  
        //Debug.Log ("MSG>>>>>>>>>>>>>>"+fullName);
        try {  rVal = (Texture2D)Resources.Load(fullName);  }
        catch (Exception ex) { 
            Ag.LogString("  Msg error  " + ex.ToString()); 
        }
        return rVal;
    }
    
    public static Texture2D GetDirSklTexture( bool pIsDirect, int pValue) {
        string txtStr="";
        if (pIsDirect) {
            switch (pValue) {
            case 0: txtStr = "Arrow_Miss"; break;
            case 1: txtStr = "ArrowBlue"; break;
            case 2: txtStr = "ArrowRed"; break;
            case 3: txtStr = "ArrowSky"; break;
            case 4: txtStr = "ArrowYellow"; break;
            }
        } else {
            switch (pValue) {
            case 0: txtStr = "Word_Miss"; break;
            case 1: txtStr = "Word_Good"; break;
            case 2: txtStr = "Word_Perfect"; break;
            }
        }
        return (Texture2D)Resources.Load("UIsource/" + txtStr);
    }
    
    
    public static Texture2D GetTextureInArr ( string pName, List<Texture2D> pList ) {
        
        int k, num = pList.Count;
        
        for (k=0; k<num; k++) {
            if (pName == pList[k].name) return pList[k];
        }
        
        return null;
    }
    
    public static bool CheckNickValid ( string pNick ) {
        //string sPattern = "^[a-zA-Z]{3}[a-zA-Z0-9.]{3,10}$";
        if ( pNick.Length < 6) return false;
        if ( "GUEST" == pNick.Substring(0, 5).ToUpper() )
            return false;
        string sPattern = "^[a-zA-Z0-9]{3}[a-zA-Z0-9]{3,9}$";
        return System.Text.RegularExpressions.Regex.IsMatch(pNick, sPattern);
    }
    
    public static bool CheckNickValidWithPattern ( string pNick, string pPatern ) {
        return System.Text.RegularExpressions.Regex.IsMatch(pNick, pPatern);
    }
    
    public static string RemoveDot( string pTarget ) {
        
        string rStr = "";
        string pattern = "^[a-zA-Z0-9]{1}$";
        
        int j, num = pTarget.Length;
        for (j=0; j<num; j++) {
            string cur = pTarget.Substring(j, 1);
            if ( AgUtil.CheckNickValidWithPattern(cur, pattern) )
                rStr += cur;
        }
        return rStr;
    }
    
    public static string WhatKindOfItem ( int pItemUNO ) {
        switch (pItemUNO) {
        case 1:
        case 2:
        case 3:
            return "Glove";
        case 4:
        case 5:
        case 6:
            return "Shoes";
        }
        return "";
    }
    
}


public class AgBoolObj {
    public bool mIsStarted, mIsActionDone;
    
    public AgBoolObj() {
        mIsStarted = mIsActionDone = false;
    }
    
    public void StartAction() { mIsStarted = true; }
    
    public void ActionDone() { mIsActionDone = true; }
    
    public void FinishAction() { mIsStarted = false; mIsActionDone = false; 
        Ag.LogIntenseWord("Is Started >> " + mIsStarted );
    }
    
    public bool AllTrue() {
        return (mIsStarted && mIsActionDone);
    }
    
    public bool IsAtoAf() {  // All True Or All False  atoal
        return mIsStarted ^ !mIsActionDone;
    }
    
    public bool IsWorking() {
        return !IsAtoAf();
    }
    
}

public class AgVariable {
    public bool? mBool;
    public string mStrVar, mTrueStateName, mFalseStateName, mClearStateName, mVarName;
    
    public virtual void SetValueBy ( string pState ) {    }
    public virtual bool IsItClearStage ( string pState ) { return true; }
}


public class AgBool : AgVariable {
    bool mVal;
    
    
    public AgBool ( string pName, bool pInit = false ) {
        mVal = pInit;
        mVarName = pName;
    }
    
    public void SetTrueFalseState ( string pTrue, string pFalse, string pClear) {
        mTrueStateName = pTrue;
        mFalseStateName = pFalse;
        mClearStateName = pClear;
    }
    
    public override void SetValueBy ( string pState ) {
        if (pState == mTrueStateName) mVal = true;
        if (pState == mFalseStateName) mVal = false;
    }
    
    public override bool IsItClearStage ( string pState ) {
        if (pState == mClearStateName) return true;
        return false;
    }
    
    public bool GetValue() {  return mVal; }
    
    public void SetValueWith ( bool pVal ) {  mVal = pVal; }
    
}