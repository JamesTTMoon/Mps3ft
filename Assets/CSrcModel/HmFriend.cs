using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

//  ////////////////////////////////////////////////     Hm Friend..  2 Unit Number
public class HmFriend : MpsModel  //
{
    public int mValue; // ex) 24, 5, 8, can be result..
    public Fff meuFff;
    public List<GameObject> arrJinsim = new List<GameObject> ();

    public HmFriend (int pNum, Vector3 pInit)
    {
        meuFff = (Fff)pNum;
        
        (" HmFriend :: HmFriend  >>>>  pNum : " + pNum + " ,  casting to meuFff : " + meuFff).HtLog ();
        
        // Create Position Setting...

        manInitAe = pInit;

        manDora = new Vector3 (0, 0, 180);
        mName = meuFff.ToString ();
        mRsrcMan.SetInstantComPrefab ("Friends", this);
    }

    public override void SetState (string pStt)
    {
        base.SetState (pStt);
        foreach (GameObject gObj in arrJinsim) {
            gObj.GetComponent<HtJinsimIdv> ().SetState (pStt);
        }
    }
    
    public int GetValueOfExp (int pExp)  // 234 .. 0 returns 4 ... 1 returns 3
    {
        int num = (int)(mValue / Mathf.Exp (pExp));
        return num % 10;
    }
    
    public void IntroduceAction ()
    {
        mGobj.GetComponent<HtFriendIdv> ().IntroduceAction ();
    }

    public override void CreateJinsim ()
    {
        (" HmFriend :: CreateJinsim  >>>>  " + meuFff).HtLog ();

        List<VecRot> myList = Cns.arrJinsimAe [(int)meuFff];

        //(" Length " + ((int) meuFff) + ",  " +  myList.Count).HtLog ();

        foreach (VecRot curAe in myList) {
            GameObject curJs = mRsrcMan.GetJinsim ();
            //"New Jinsim ".HtLog();
            //            curJs.ShowPosi();

            curJs.GetComponent<HtJinsimIdv> ().mInitFobj = meuFff;
            curJs.transform.position = mGobj.transform.GetApplyVect3 (curAe.OrigAe);
            curJs.transform.Rotate (curAe.OriRot);

            arrJinsim.Add (curJs);
        }
    }

    public override void SplitProcess (bool pIsStart)
    {
        (" HmFriend :: SplitProcess  >>>>  " + meuFff).HtLog ();
        
        //List<VecRot> myList = Cns.arrJinsimAe [ (int) meuFff];
        
        //(" Length " + ((int) meuFff) + ",  " +  myList.Count).HtLog ();
        
        foreach (GameObject jsObj in arrJinsim) {

            if (pIsStart)
                jsObj.AddComponent<EfctSplit> ();
            else
                Component.Destroy (jsObj.GetComponent<EfctSplit> ());
        }
    }

    public override void DestroyJinsim ()
    {
        foreach (GameObject obj in arrJinsim) {
            MonoBehaviour.Destroy (obj);
        }
        arrJinsim.Clear ();
    }

}