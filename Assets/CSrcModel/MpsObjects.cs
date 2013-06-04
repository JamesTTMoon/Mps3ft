using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;



public class MdObject
{
    public Godirum mGod;
}

public class UnitTrans : MdObject
{
    public HmFriend mForm, mLatt;  // 3, 9
    public Godirum mGod; // Plus

    public int mResult;  // 12

    public HmEquation mRsltEq = new HmEquation();

    public Vector3 mGijunAe;

    public UnitTrans(HmFriend pForm, HmFriend pLatt, Godirum pGod)
    {
        mForm = pForm;
        mLatt = pLatt;
        mGod = pGod;
        Show ();
    }

    public bool IsItOver10()
    {
        if (mResult >= 10)
            return true;
        return false;
    }

    public void Show()
    {
        (" UnitTrans :: Show   " + mForm.meuFff + "    " + mGod.ToString() + "  " + mLatt.meuFff  ).HtLog();
    }

    public void SetResultPosi(Vector3 pGijun)
    {
        mGijunAe = pGijun;
    }

    public void StartTrans()
    {
        mForm.mGobj.AddComponent<EfctTrans> ();
        mForm.mGobj.GetComponent<EfctTrans> ().SetProperty (mGod, true, new Vector3 (0, 0, 0), new Vector3 (0, 0, 0), 2000);

        mLatt.mGobj.AddComponent<EfctTrans> ();
        mLatt.mGobj.GetComponent<EfctTrans> ().SetProperty (mGod, false, new Vector3 (0, 0, 0), new Vector3 (0, 0, 0), 2000);
    }

    public bool DidTransFinish()
    {
        return true;
    }


}



//  ////////////////////////////////////////////////     ////////////////////////     >>>>> Model Class ........ <<<<<
public class MpsModel : MdObject
{
    public string mName, mState;
    public GameObject mGobj;

    public Vector3 manInitAe;
    public Vector3 manDora;
    public HtRsrcMan mRsrcMan = new HtRsrcMan("Com");
    
    public virtual void SetState(string pStt)
    {
        mState = pStt;

        if (GetType().ToString() == "HmFriend") {
            (" HmVentureMan  :: SetState    " + "  Its Hm Friend  " + this.mName ).HtLog ();
            ((HmFriend)this).mGobj.GetComponent<HtFriendIdv>().SetState(pStt);
        }
    }
    
    public virtual void CreateJinsim()
    {
    }

    public virtual void SplitProcess(bool pIsStart)
    {
    }

    public virtual void Transform()
    {

    }

    public virtual void DestroyJinsim()
    {
    }
}



//  ////////////////////////////////////////////////     Hm God..  + - 
public class HmGod : MpsModel
{
    public Godirum mIrum;
    
    public HmGod (Godirum pIrum)
    {
        mIrum = pIrum;
        
        // Create Position Setting...
        manInitAe = new Vector3 (0, 0, 0);
        manDora = new Vector3 (0, 0, 180);
        
        mRsrcMan.SetInstantComPrefab("God", this);
    }
    
    public void IntroduceAction()
    {
        mGobj.GetComponent<HtGod> ().IntroduceAction ();
    }
    
    public override void CreateJinsim()
    {
        base.CreateJinsim ();
    }
    
    
    
}

