using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;


//  ////////////////////////////////////////////////     ////////////////////////     >>>>>>>>>>     Effect Split     <<<<<<<<<<<<<<  
public class EfctSplit : EfctBaseClass
{

    Vector3 mRotValue; // 4/8


	int mLimit;

	//  ////////////////////////////////////////////////     Starting Init Job
	public override void Start ()
	{
		base.Start ();
		mSeldomActionNum = 5;

        int ranN = AgUtil.RandomInclude (10, 100);
        if (ranN % 2 == 0)
            ranN *= -1;

        //mRotValue = new Vector3 (0, 0, ranN * 0.001f);

        mRotValue = new Vector3 (0f, 0f, 0.5f);
	}
	
	public override void BaseStartSetting ()
	{
		base.BaseStartSetting ();

	}
	
	
	
	//  ////////////////////////////////////////////////     Update related
	public override void Update ()
	{
		base.Update ();

        "".HtLog ();
        ("Rotation in Quatenion ::  " + transform.rotation.ToString () + " , Rotate : " + mRotValue).HtLog ();

        transform.Rotate (mRotValue); 




		//foreach (Touch touch in Input.touches) {        }
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
