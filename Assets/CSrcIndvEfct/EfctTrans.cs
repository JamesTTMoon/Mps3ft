using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;




//  ////////////////////////////////////////////////     ////////////////////////     >>>>>>>>>>     Effect Freeze     <<<<<<<<<<<<<<  
public class EfctTrans : EfctBaseClass
{
    Godirum mGod;
    bool mIsFormer;
    Vector3 mRotValue, mFinPosi, mFinRot;

	//  ////////////////////////////////////////////////     Starting Init Job
	public override void Start ()
	{
		base.Start ();
		mSeldomActionNum = 5;

		
	}
	
	public override void BaseStartSetting ()
	{
		base.BaseStartSetting ();
	}
	
    public void SetProperty(Godirum pGod, bool pIsForm, Vector3 pFinPosi, Vector3 pFinRot, float pLimitMilSec = 2000 )
    {
        mGod = pGod;
        mIsFormer = pIsForm;
        mFinPosi = pFinPosi;
        mFinRot = pFinRot;

        switch (mGod) {
        case Godirum.PLU:
            mRotValue = new Vector3 (0, 0, 0.01f);
            break;
        case Godirum.MUL:
            int ranN = AgUtil.RandomInclude (30, 50);
            if (mIsFormer)
                mRotValue = new Vector3 (0, 0, ranN * 0.01f);
            else
                mRotValue = new Vector3 (0, 0, -ranN * 0.002f);
            break;
        }

        mLimit = pLimitMilSec;
    }
	
	//  ////////////////////////////////////////////////     Update related
	public override void Update ()
	{
		base.Update ();

        if (base.IsOverLimit ()) {
            transform.position = transform.position.IntDivide(mFinPosi, 5, 1);
            //  http://blog.daum.net/hopefullife/183  Quarernion
            ; // Mamoori  ㅁㅏㅁㅜㄹㅣ... 
        } else {  // Effect ..
            transform.Rotate (mRotValue);
        }

	}

	public override void SeldomAction()
	{
		//transform.position = mefSwitchPosi.CurPosition ();
	}
	
	//  ////////////////////////////////////////////////     OnGUI related
	public override void OnGUI ()
	{
		base.OnGUI ();

	}
}
