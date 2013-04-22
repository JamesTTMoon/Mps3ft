using UnityEngine;
using System.Collections;

public class HtIndvBase : MonoBehaviour {

    public string mName, mState;

	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
    public virtual void Update () {
	
	}

    public void SetState(string pStt)
    {
        mState = pStt;
    }

}
