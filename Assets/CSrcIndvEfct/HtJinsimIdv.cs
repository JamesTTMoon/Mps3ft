using UnityEngine;
using System.Collections;

public class HtJinsimIdv : HtIndvBase {
    
    public AudioSource mIntroSound;
    //public Fff mInitFobj, mRsltFobj;
    public int mInitPrtN, mRsltPrtN;

    //Vector3 mPosition;

    VecRot mTarget;
    
    // Use this for initialization
    public override void Start () {
        
    }

    public void SetTarget(VecRot pTarVr)
    {
        mTarget = pTarVr;
    }

    // Update is called once per frame
    public override void Update () {
        
        Vector3 ae  = transform.position;
        
        // Some Coordinate Noise Generation ...  Some Rotating, Moving Animations....
        switch (mState) {
            
        case "Freeze":
            // Animation Play.. 

            transform.position = ae.Freeze();
            break;

        case "Jumbi": // 준비
            // Rotation only...
            if (JJ.mgGod == Godirum.PLU) {

                (" Jumbi , PLU ").HtLog();

            }

            if (JJ.mgGod == Godirum.MUL) {
            }

            break;

        case "Chum":
            // Transform, Rotation, Scale Setting...
            if (JJ.mgGod == Godirum.PLU) {
                
                (" Chum , PLU ").HtLog();
                
            }


            break;

        case "ObeyGod":

            break;

        case "Result":
            // Will be destroyed... The following line will not executed !!! 
            " Result ;::: Destroy Myself   ".HtLog();

            break;

        case "Destroy":
            // Will be destroyed... The following line will not executed !!! 
            //" Result ;::: Destroy Myself   ".HtLog();
            
            break;
        }


    }
    
    public void IntroduceAction()
    {
        if (mIntroSound != null)
            mIntroSound.Play ();
        // myFff = ONEY ...
        
        //mIntroSound = (AudioSource)Resources.Load ("Com/Friends/Sound" + mInitFobj.ToString () + "_Intro"); 
        
    }
    
    
}
