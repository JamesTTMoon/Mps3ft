using UnityEngine;
using System.Collections;

public class HtJinsimIdv : HtIndvBase
{
    
    public AudioSource mIntroSound;
    //public Fff mInitFobj, mRsltFobj;
    public int mInitPrtN, mRsltPrtN;

    Vector3 mJumbi;

    
    // Use this for initialization
    public override void Start ()
    {
        mJumbi = new Vector3 (0, 0, 0.03f);
        
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

        case "JinsimJumbi": // 준비
            // Rotation only...
            if (mGod == Godirum.PLU) {
                //transform.IntDivideRotZ (mTarget.Dora, 0.003f);
                transform.Rotate( mJumbi);

                //(" Jumbi , PLU  My Angle ... Target  " + mTarget.Dora.z + "   curZ : " + curZ + " ,  angZ : " + angZ ).HtLog();
            
            }

            if (mGod == Godirum.MUL) {
            }

            break;

        case "JinsimChum":
            // Transform, Rotation, Scale Setting...
            if (mGod == Godirum.PLU) {
                transform.IntDivideRotZ(mTarget.Dora, 0.05f);

                transform.IntDivideLimit (mTarget.Ae, 50, 1, 0.05f); // 이동 slow
                //transform.IntDivideLimit (mTarget.Ae, 15, 1, 0.15f); // 이동 fast
                transform.localScale = transform.localScale.IntDivide(mTarget.Kugi, 40, 1);
            }
            break;

        case "ObeyGod":

            break;

        case "ShowResult":
            // Will be destroyed... The following line will not executed !!! 
            Destroy (gameObject);
            break;


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
