using UnityEngine;
using System.Collections;

public class HtGod : HtIndvBase {
    
    public AudioSource mIntroSound;
    public Fff myFff;
    
    // Use this for initialization
    public override void Start () {
        
    }
    
    // Update is called once per frame
    public override void Update () {
        
    }
    
    public void IntroduceAction()
    {
        if (mIntroSound != null)
            mIntroSound.Play ();
        // myFff = ONEY ...

        ("Com/God/Sound" + myFff.ToString () + "_Intro").HtLog ();

        mIntroSound = (AudioSource)Resources.Load ("Com/God/Sound" + myFff.ToString () + "_Intro"); 
        
    }
    
    
}
