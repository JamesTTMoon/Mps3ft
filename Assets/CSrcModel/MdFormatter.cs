using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public struct MdUnitOperation
{
    public int mForm, mLatt;
    public Godirum mGod;

    public MdUnitOperation(int pF, int pL, Godirum pGod)
    {
        mForm = pF;
        mLatt = pL;
        mGod = pGod;
    }

}

public class MdIntObj : MdObject
{  // 123 ...
    public int mTotalValue; // 123 / 100 / 20 / 3 ...
    public List<MdIntObj> arrIntObj;
    public HmFriend mFriend;

    //  ////////////////////////////////////////////////    Creation ...
    public MdIntObj (int pValue, bool pIsTotal, Godirum pGod) // 10 , 5 , ...
    {
        // MdIntObj intObj = new MdIntObj (1045, true);  1000, 0, 40, 5 ...
        //("MdIntObj :: MdIntObj   " + pValue + " ,  Total ? " + pIsTotal).HtLog ();
        mTotalValue = pValue;
        mGod = pGod;
        if (!pIsTotal) 
            return;
        arrIntObj = new List<MdIntObj> ();
        int jarisoo = pValue.Jarisoo (), cur10e = jarisoo;
        for (int k=0; k<jarisoo; k++) {
            int curN = pValue.NthNum (k);
            arrIntObj.Add (new MdIntObj ((int)(curN * Math.Pow (10, --cur10e)), false, pGod));
        }
        //(" arrIntObj  count " + arrIntObj.Count).HtLog ();
    }

    public MdIntObj GetAndRemoveLastObj()  // for Total
    {
        MdIntObj rObj = arrIntObj[arrIntObj.Count - 1];
        arrIntObj.Remove (rObj);
        return rObj;
    }

    public Fff GetFff() // for Individual Object
    {
        return (Fff)HeadNumber();
    }

    //  ////////////////////////////////////////////////    Get Methods ...
    public int HeadNumber ()
    {
        return mTotalValue.NthNum (0);
    }

    public int Jarisoo ()
    { 
        return mTotalValue.Jarisoo ();
    }

    //  ////////////////////////////////////////////////    Private ...

    //  ////////////////////////////////////////////////    Public ...

}

public enum Cb
{
    PLUS_SIMPLE,
    PLUS_OVER10,
    PLUS_VERT,
    MULT_EXPLODE
}

//  ////////////////////////////////////////////////     ////////////////////////     >>>>> Md Chubang ... 처방전 ........ <<<<<
public class MdChubang : MdObject
{
    public Cb mKind;
    public VecRot mFvr, mLvr, mHonVr, mHTarVr;
    public Fff mFff, mLff, mHff;


    
    public MdChubang(MdIntObj pFobj, MdIntObj pLobj)
    {
        mFvr = new VecRot ();
        mLvr = new VecRot ();
        mHonVr = new VecRot ();
        mHTarVr = new VecRot ();
        mFff = pFobj.GetFff ();
        mLff = pLobj.GetFff ();
        //(" New Chu bang ::: " + mFff + ",  " + mLff).HtLog ();
    }

    public void SetAe (Vector3 mF, Vector3 mL, Vector3 mRes)
    {
        mFvr.Ae = mF;
        mLvr.Ae = mL;
        mHonVr.Ae = mRes;
    }

    public void SetDoraSame (Vector3 pDora)
    { // 모든 회전을 같게 세팅
        mFvr.Dora = mLvr.Dora = mHonVr.Dora = pDora; // 
    }
    public void SetDora (Vector3 mF, Vector3 mL, Vector3 mRes)
    {
        mFvr.Dora = mF;
        mLvr.Dora = mL;
        mHonVr.Dora = mRes;
    }

    public void SetResTarget(Vector3 pAe)
    {
        mHTarVr.Ae = pAe;
        mHTarVr.Dora = mHonVr.Dora;
    }

    public void SetResultFFF()  // It's also called 'Hon'  It has Target...
    {
        (" MdChubang :: SetResultFFF >>> " + mFff + ",  " + mLff).HtLog ();
        int rval = ((int)mFff).DoCalculate((int)mLff, mGod);
        (" MdChubang :: rval >>> " + rval + ",  " ).HtLog ();
        mHff = (Fff)rval;

        if (mGod == Godirum.PLU) {
            mKind = Cb.PLUS_SIMPLE;
            if (rval >= 10) { // over 10 case ... 
                mKind = Cb.PLUS_OVER10;
                mHff = (Fff)(rval - 10);
                return;
            }
        }

    }
}

//  ////////////////////////////////////////////////     ////////////////////////     >>>>> MdFormatter  ........ <<<<<
public class MdFormatter : MdObject
{ 
    // All Stage will be defined here ..  ... like blue print ...
    public MdIntObj mFm, mLt;
    public Rect mPerfArea; // = new Rect(1, 1, 2, 2); // Performance Area .. 

    public List<MdChubang> arrChubang;

    //  ////////////////////////////////////////////////    Creation ...
    public MdFormatter (int pForm, int pLatt, Godirum pGod)
    {
        mGod = pGod;
        mFm = new MdIntObj (pForm, true, pGod);
        mLt = new MdIntObj (pLatt, true, pGod);

        InitGenerateChubang ();
    }

    //  ////////////////////////////////////////////////    Public ...
    public MdChubang GetChubang ()
    {
        if (arrChubang.Count == 0)
            return null;

        MdChubang rObj = arrChubang [0];
        arrChubang.RemoveAt (0);
        return rObj;
    }

    //  ////////////////////////////////////////////////    Private ...
    void InitGenerateChubang ()
    {
        arrChubang = new List<MdChubang> ();

        if (mGod == Godirum.PLU)
            ChubangPlu ();
    }

    void ChubangPlu() {
        MdChubang rObj;
        rObj = new MdChubang (mFm.GetAndRemoveLastObj(), mLt.GetAndRemoveLastObj() );
        rObj.SetAe (new Vector3 (-7, 0, 0), new Vector3 (7, 0, 0), new Vector3 (0, 0, 5));
        rObj.SetDoraSame(new Vector3(0, 0, 0 ));  // 모든 회전을 같게 세팅
        rObj.SetResTarget(new Vector3(0, 0, 0));    // 결과값 위치

        if (MaxJarisoo () == 1) {
            rObj.SetResultFFF( );  // Cb.PLUS_OVER10;
            arrChubang.Add(rObj);
        }
    }

    int MaxJarisoo () // L, F 중 최대 자리수. 결과 아님.
    {
        return mFm.Jarisoo ().GetBigger (mLt.Jarisoo ());
    }

    //  ////////////////////////////////////////////////    Public ...

}
