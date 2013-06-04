using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;


public class HtEyeIdv : HtIndvBase
{
    public AudioSource mIntroSound;
    //public Fff mInitFobj, mRsltFobj;
    public int mInitPrtN, mRsltPrtN;

    // Use this for initialization
    public override void Start ()
    {
        mName = transform.name.Substring (0, 9); // EyeSingle, EyeDouble, EyeTriple
        //(" HtEyeIdv :: Start  >>>   " + mName).HtLog ();
    }

    public void ReplaceWithEyeSingle()
    {
        //(" ___ HtEyeIdv :: ReplaceWithEyeSingle  >>>   " + mName + "  ,  arrParent > " + arrParent.Count).HtLog ();
        if (mName == "EyeSingle" || mName == "")  // Newly Generated object ... skip ...
            return;
        //(" HtEyeIdv :: ReplaceWithEyeSingle  >>>   " + mName + "  ,  arrParent > " + arrParent.Count).HtLog ();
        if (mName == "EyeDouble") {
            GameObject eye;
            eye = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Com/Friends/EyeSingle"));
            eye.transform.SetJinsimAeDora(transform, JJ.dicVar["Single_A_fromDouble"], pKugi:true );
            arrParent.Add(eye);
            eye = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Com/Friends/EyeSingle"));
            eye.transform.SetJinsimAeDora(transform, JJ.dicVar["Single_B_fromDouble"], pKugi:true );
            arrParent.Add(eye);
        }

        if (mName == "EyeTriple") {
            GameObject eye;
            eye = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Com/Friends/EyeSingle"));
            eye.transform.SetJinsimAeDora(transform, JJ.dicVar["Single_A_fromTriple"], pKugi:true );
            arrParent.Add(eye);
            eye = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Com/Friends/EyeSingle"));
            eye.transform.SetJinsimAeDora(transform, JJ.dicVar["Single_B_fromTriple"], pKugi:true );
            arrParent.Add(eye);
            eye = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Com/Friends/EyeSingle"));
            eye.transform.SetJinsimAeDora(transform, JJ.dicVar["Single_C_fromTriple"], pKugi:true );
            arrParent.Add(eye);
        }
        //arrParent.Remove(gameObject);
        //(" HtEyeIdv :: ReplaceWithEyeSingle  ~~  Removed  ~~  >>>    ,  arrParent > " + arrParent.Count).HtLog ();
        //Destroy(gameObject);
    }

    protected override void TimerAction ()
    {
        base.TimerAction ();
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update ();
        
        Vector3 ae = transform.position;
        
        // Some Coordinate Noise Generation ...  Some Rotating, Moving Animations....
        switch (mState) {
            
        case "Freeze":
            // Animation Play.. 
            transform.position = ae.Freeze ();
            break;
        case "JinsimIntro": // 준비
            if (mGod == Godirum.PLU) {
                // transform.MoveXYZ( AgUtil.RandomInclude(1, 6) * 0.002f, 0.01f);

            }
            break;
        case "JinsimJumbi": // 준비
            // Rotation only...

            transform.MoveXYZ(0, 0.01f, 0);

            if (mGod == Godirum.MUL) {
            }
            
            break;
            
        case "JinsimChum":
            // Transform, Rotation, Scale Setting...
            if (mGod == Godirum.PLU) {
                transform.IntDivideRotZ(mTarget.Dora, 0.05f);
                //transform.IntDivide (mTarget.Ae, 60, 1); // 이동
                transform.IntDivideLimit (mTarget.Ae, 50, 1, 0.05f); // 이동 slow
                //transform.IntDivideLimit (mTarget.Ae, 13, 1, 0.08f); // 이동 fast
                transform.localScale = transform.localScale.IntDivide(mTarget.Kugi, 40, 1);
            }
            break;
            
        case "ObeyGod":
            
            break;
            
        case "ShowResult":
            // Will be destroyed... The following line will not executed !!! 
            Destroy (gameObject);
            break;
            
        case "Destroy":
            // Will be destroyed... The following line will not executed !!! 
            //" Result ;::: Destroy Myself   ".HtLog();
            
            break;
        }
        
        
    }
    
    public void IntroduceAction ()
    {
        if (mIntroSound != null)
            mIntroSound.Play ();
        // myFff = ONEY ...
        
        //mIntroSound = (AudioSource)Resources.Load ("Com/Friends/Sound" + mInitFobj.ToString () + "_Intro"); 
        
    }
    
    
}
