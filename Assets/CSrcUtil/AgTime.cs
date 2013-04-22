// [2012:10:10:MOON] Heart Beat
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class AgTime { //: MonoBehaviour {
    
    DateTime mpMarkTime;
    float mpTargetTime;
    
    private Hashtable dicOneLog = new Hashtable();
    
    //private IDictionary<int, string> dicOneLog =
     //new IDictionary<int, string>();
    
    public AgTime() {
		//Ag.LogIntenseWord("  AgTime is Generated  ");
    }
    
    public void ResetLogOnce() {
        dicOneLog = new Hashtable();
    }
    
    public void WaitTimeFor( float pSeconds ) {
        //mpMarkTime = Time.timeSinceLevelLoad;    
        mpMarkTime = DateTime.Now;
        mpTargetTime = pSeconds;
    }
    
    // Check if the time is OUT... returns Ture if Finished...
    public bool DidTimerFinished() {
        //float timeDue =  Time.timeSinceLevelLoad - mpMarkTime;
        TimeSpan spanT = DateTime.Now - mpMarkTime;
        
        if ( spanT.TotalMilliseconds > mpTargetTime * 1000f ) {
            //mpMarkTime = -1;
            mpMarkTime = DateTime.MinValue;
            return true;
        } else {
            return false;
        }
    }
    
    public int SecondsLeft() { // Count Down...
        //float timeDue = Time.timeSinceLevelLoad - mpMarkTime;
        TimeSpan spanT = DateTime.Now - mpMarkTime;
        //return  Mathf.CeilToInt (mpTargetTime - timeDue);
		
		//Debug.Log(" time " + DateTime.Now + " , " + mpMarkTime.ToString() + " , " + spanT.Seconds.ToString() + "  " + (mpTargetTime - (float)spanT.Seconds).ToString() );
        return Mathf.CeilToInt (  mpTargetTime - (float)spanT.Seconds ); 
    }
    
    
    public void LogOnce( int pIndex, string pMsg ) {
        if (dicOneLog.Contains(pIndex)) return;
        
        //Debug.Log(">>>>>Log Once<<<<<  ..............Index : " + pIndex + " <<<>>> " + pMsg + "<<< \n");
        
        string timeSince = string.Format(" timeSinceLevelLoad: [{0:#0.0}],", Time.timeSinceLevelLoad);
        string timeeMark = string.Format(" mpMarkTime:[{0:#0.0}],", mpMarkTime);
        string timeTargt = string.Format(" mpTargetTime:[{0:#0.0}],", mpTargetTime);
        
        Debug.Log ("AgTime.LogOnce :: " + timeSince + timeeMark + timeTargt +
            " >>>" + pIndex + " <<<  ''''' " + pMsg + "'''''  \n");
        dicOneLog.Add(pIndex, pMsg);
    }
    
    
    
}
