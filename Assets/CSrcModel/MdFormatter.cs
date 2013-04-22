using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class MdIntObj : MdObject {  // 123 ...
    public int mTotalValue; // 123 / 100 / 20 / 3 ...
    public List<MdIntObj> arrIntObj;

    public HmFriend mFriend;

    //  ////////////////////////////////////////////////    Creation ...
    public MdIntObj(int pValue, bool pIsTotal) // 10 , 5 , ...
    {
        // MdIntObj intObj = new MdIntObj (1045, true);  1000, 0, 40, 5 ...
        //("MdIntObj :: MdIntObj   " + pValue + " ,  Total ? " + pIsTotal).HtLog ();
        mTotalValue = pValue;
        if (!pIsTotal) 
            return;
        arrIntObj = new List<MdIntObj> ();
        int jarisoo = pValue.Jarisoo (), cur10e = jarisoo;
        for (int k=0; k<jarisoo; k++) {
            int curN = pValue.NthNum(k);
            arrIntObj.Add(new MdIntObj( (int)(curN * Math.Pow(10, --cur10e)) , false ));
        }
    }

    //  ////////////////////////////////////////////////    Get Methods ...
    public int HeadNumber()
    {
        return mTotalValue.NthNum (0);
    }

    public int Jarisoo() { 
        return mTotalValue.Jarisoo();
    }

    //  ////////////////////////////////////////////////    Private ...

    //  ////////////////////////////////////////////////    Public ...

}

//  ////////////////////////////////////////////////     ////////////////////////     >>>>> MdFormatter  ........ <<<<<
public class MdFormatter : MdObject { 
    // All Stage will be defined here ..  ... like blue print ...
    public MdIntObj mFm, mLt;
    public HmGod mGod;
        
    public Rect mPerfArea; // = new Rect(1, 1, 2, 2); // Performance Area .. 

    public List<MdFormatter> arrFormat;

    //  ////////////////////////////////////////////////    Creation ...
    public MdFormatter(int pForm, int pLatt, Godirum pGod)
    {
        mFm = new MdIntObj (pForm, true);
        mLt = new MdIntObj (pLatt, true);
        mGod = new HmGod (pGod);
    }

    //  ////////////////////////////////////////////////    Private ...
    void GenerateSubFormats()
    {

    }
    
    //  ////////////////////////////////////////////////    Public ...

}
