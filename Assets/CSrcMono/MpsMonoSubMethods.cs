using UnityEngine;
using System.Collections;

public class MpsMonoSubMethods : AmSceneBase {

	// Use this for initialization
	public override void Start () {
        mTimeLooseAtStartPoint = 0.01f; // Second
        mSeldomActionNum = 5000;
        base.Start ();
        JJ.Init ();
	}
	
    public  GameObject SetGod(Godirum  pGod)
    {
        GameObject theGod = null;
        switch (pGod) {
        case Godirum.PLU:
            theGod = mRscrcMan.GetComPrefab("", "PLUS"); // Friends Show
            theGod.transform.position =  new Vector3 (1, 9, 0);
            //theGod.transform.Rotate(new Vector3(0, 0, 180 ));

            break;
        }
        return theGod;
    }

	// Update is called once per frame
	public override void Update () {
	
	}
}
