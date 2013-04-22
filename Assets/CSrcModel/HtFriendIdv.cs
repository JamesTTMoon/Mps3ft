using UnityEngine;
using System.Collections;

public class HtFriendIdv : HtIndvBase {

    public AudioSource mIntroSound;
    public Fff myFff;

    Vector3 mPosition;

	// Use this for initialization
	public override void Start () {
	
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

        case "JinsimIntro":
            transform.MoveBack(0.1f);
            break;
        }
	
	}

    public void IntroduceAction()
    {
        if (mIntroSound != null)
            mIntroSound.Play ();
        // myFff = ONEY ...

        mIntroSound = (AudioSource)Resources.Load ("Com/Friends/Sound" + myFff.ToString () + "_Intro"); 

    }


}
