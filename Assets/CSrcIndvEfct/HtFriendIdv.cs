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

    public List<GameObject> CreateJinsim()
    {
        GameObject jinsim = mRscrcMan.GetComPrefab("Friends", "Jinsim");
        //jinsim.AddComponent<HtJinsimIdv>(); it's there ...
        jinsim.transform.position = transform.position + JJ.arrJinsimAe [1] [0].Ae;

        (" Vector :: " + (transform.position + JJ.arrJinsimAe [1] [0].Ae).GetType ().ToString ()).HtLog ();
        arrJinsim.Add (jinsim);
        return arrJinsim;
    }

    public List<VecRot> HonPosition()
    {
        List<VecRot> retAe = JJ.arrJinsimAe[(int)myFff];

        Vector3 cur = transform.position;
        foreach (VecRot vrObj in retAe) {
            vrObj.ApplyVector(cur.x, cur.y, null);
        }

        return retAe;
    }

	
	// Update is called once per frame
    public override void Update () {

        mPosition = transform.position;

        // Some Coordinate Noise Generation ...  Some Rotating, Moving Animations....
        switch (mState) {

        case "Freeze":
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
