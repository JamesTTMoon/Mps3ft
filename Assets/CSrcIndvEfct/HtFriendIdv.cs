using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HtFriendIdv : HtIndvBase {

    public AudioSource mIntroSound;
    public Fff myFff;
    HtRsrcMan mRscrcMan = new HtRsrcMan ("Folder");

    Vector3 mPosition;

    List<GameObject> arrJinsim = new List<GameObject>();

	// Use this for initialization
	public override void Start () {
	
	}

    public void SetFff( Fff pFff) {
        myFff = pFff;
    }

    public void CreateJinsim()
    {
        GameObject jinsim = mRscrcMan.GetComPrefab("Friends", "Jinsim");
        jinsim.AddComponent<HtJinsimIdv>();
        jinsim.transform.position = transform.position + Cns.arrJinsimAe [1] [0].OrigAe;

        (" Vector :: " + (transform.position + Cns.arrJinsimAe [1] [0].OrigAe).GetType ().ToString ()).HtLog ();
        arrJinsim.Add (jinsim);
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

        case "Destroy":
            Destroy(gameObject);
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
