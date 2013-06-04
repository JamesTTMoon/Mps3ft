using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HtTensIdv : HtIndvBase {

    public Fff myFff;
    HtRsrcMan mRscrcMan = new HtRsrcMan ("Folder");

    List<GameObject> arrJinsim = new List<GameObject>();
    List<GameObject> arrEyes = new List<GameObject>();
    
    // Use this for initialization
    public override void Start () {
        mRotation = new Vector3 (0, 0.3f, 0);
    }
    
    public void InitJob(Fff pFff)
    {
        myFff = pFff;
    }
    /*
    public void LoadEyes(List<GameObject> pArrEyes, bool pIsHon = false)
    {
        GameObject eye;
        List<VecRot> curArr = JJ.arrEyeAe[(int)myFff];
        
        foreach (VecRot curVr in curArr) {
            eye = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Com/Friends/" + curVr.mObjName));
            eye.transform.SetJinsimAeDora(transform, curVr);
            
            if (pIsHon) {
                eye.transform.parent = transform;
                arrEyes.Add(eye);
            } else {
                pArrEyes.Add(eye);
                eye.GetComponent<HtIndvBase>().arrParent = pArrEyes;
            }
        }
    }


    public List<GameObject> CreateJinsim()
    {
        GameObject jinsim;
        List<VecRot> curArr = JJ.arrJinsimAe[(int)myFff];
        foreach (VecRot curVr in curArr) {
            jinsim = mRscrcMan.GetComPrefab("Friends", "Jinsim");
            jinsim.transform.SetJinsimAeDora(transform, curVr);
            //(" HtFriendIdv :: CreateJinsim >> " + jinsim.transform.position.ToString() + "  myFff : " + myFff.ToString() ).HtLog ();
            arrJinsim.Add(jinsim);
        }
        return arrJinsim;
    }
    
    public List<VecRot> HonPosition(bool pIsOver10)
    {
        List<VecRot> retAe = JJ.arrJinsimAe[(int)myFff];
        if (pIsOver10) {
            retAe = JJ.arrJinsimAe [(int)Fff.TENS];
            retAe.AddRange(JJ.arrJinsimAe[(int)myFff]);
        } 
        
        Vector3 cur = transform.position;
        foreach (VecRot vrObj in retAe) {
            vrObj.ApplyVector(cur.x, cur.y, null); // not Z ... 
        }
        return retAe;
    }
    
    public List<VecRot> HonEyePosition(bool pIsOver10)
    {
        List<VecRot> retAe = JJ.arrEyeAe[(int)myFff];
        if (pIsOver10) {
            retAe = JJ.arrEyeAe [(int)Fff.TENS];
            retAe.AddRange(JJ.arrEyeAe[(int)myFff]);
        } 
        
        Vector3 cur = transform.position;
        foreach (VecRot vrObj in retAe) {
            vrObj.ApplyVector(cur.x, cur.y, null); // not Z ... 
        }
        return retAe;
    } */
    
    protected override void TimerAction ()
    {
        base.TimerAction ();
    }
    
    // Update is called once per frame
    public override void Update () {
        base.Update ();
        
        
        // Some Coordinate Noise Generation ...  Some Rotating, Moving Animations....
        switch (mState) {
            
        case "Freeze":
            //transform.position = mPosition.Freeze();
            break;
            
        case "JinsimJumbi":
            transform.MoveSide(-0.05f);
            break;
        
        case "JinsimChum":

            //transform.MoveUp(0.01f);
            break;
        
        case "Make10":
            transform.Rotate(mRotation);
            break;

        case "Result":
            //transform.IntDivide(mTarget.Ae, 15,1); // 이동
            break;
        
        }
    }
    
    public void IntroduceAction()
    {
    }
    
    
}
