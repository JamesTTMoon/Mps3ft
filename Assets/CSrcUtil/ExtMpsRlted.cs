using UnityEngine;
using System.Collections;

public static class ExtMpsRlted
{
    public static int DoCalculate(this int pThis, int pThat, Godirum pGod)
    {
        //(" Do Calcuate :: " + pThat + "  ,  " + pThat).HtLog ();
        switch (pGod) {
        case Godirum.PLU:
            return pThis + pThat;
        case Godirum.MUL:
            return pThis * pThat;
        case Godirum.MIN:
            return pThis - pThat;
        }
        return 0;
    }

    public static void SetTarget(this GameObject pTar, VecRot pVrObj)
    {
        pTar.GetComponent<HtIndvBase> ().SetTarget (pVrObj);
    }

    public static void SetState(this GameObject pTar, string pSttName)
    {
        pTar.GetComponent<HtIndvBase>().SetState(pSttName);  // State .... 
    }

    public static int Jarisoo(this int pVal)
    {
        return (int)( Mathf.Log10 (pVal) + 1 );
    }
    
    public static int NthNum(this int pVal, int pNth)
    {
        string str = pVal.ToString ();  // ex) pVal = 234, pNth = 2
        if (str.Length - 1 < pNth)  // 3-1 < 3 case..
            return -1; // Error..
        return int.Parse (str.Substring (pNth, 1));
    }

    //int ttt = 135;
    //("Jarisoo " + ttt.Jarisoo ()).HtLog (); // 3
    //(" nth num " + ttt.NthNum (0) + " , " + ttt.NthNum (1)+ " , "  + ttt.NthNum (2)+ " , "  + ttt.NthNum (3)).HtLog (); // 1, 3, 5, -1


}