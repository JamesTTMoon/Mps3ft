using UnityEngine;
using System.Collections;

public class HtJinsimIdv : HtIndvBase {
    
    public AudioSource mIntroSound;
    public Fff mInitFobj, mRsltFobj;
    public int mInitPrtN, mRsltPrtN;

    Godirum mGod;
    
    Vector3 mPosition;
    
    // Use this for initialization
    public override void Start () {
        
    }

    public void SetGod(Godirum pGod)
    {
        mGod = pGod;
    }

    // Update is called once per frame
    public override void Update () {
        
        mPosition = transform.position;
        
        // Some Coordinate Noise Generation ...  Some Rotating, Moving Animations....
        switch (mState) {
            
        case "Freeze":
            // Animation Play.. 
            
            // or some 
            
            transform.position = mPosition.Freeze();
            
            break;

        case "Split":



            break;

        case "Transform":


            break;

        case "ObeyGod":

            break;

        case "Result":
            // Will be destroyed... The following line will not executed !!! 
            "Destroy Myself   ".HtLog();

            break;
        }


    }
    
    public void IntroduceAction()
    {
        if (mIntroSound != null)
            mIntroSound.Play ();
        // myFff = ONEY ...
        
        mIntroSound = (AudioSource)Resources.Load ("Com/Friends/Sound" + mInitFobj.ToString () + "_Intro"); 
        
    }
    
    
}
