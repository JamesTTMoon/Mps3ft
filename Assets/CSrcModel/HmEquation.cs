using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

//  ////////////////////////////////////////////////     ////////////////////////     >>>>> Equation  ........ <<<<<
public class HmEquation : MpsModel  //    !!!   Will Be Deprecated
{

    // Item can be an Equation also...
    List<MpsModel> arrItem = new List<MpsModel> (); // 23 + 43 * 2 ... 
    public int mJarisoo = -1;

    List<UnitTrans> arrTransUnit = new List<UnitTrans> ();

    public override void SetState (string pStt)
    {
        base.SetState (pStt);
        foreach (MpsModel obj in arrItem) {
            obj.SetState (pStt);
        }
    }

    public bool CheckValidItemList ()
    {
        int num = arrItem.Count;
        if (num == 0)
            return false;
        
        return true;
    }
    
    public HmFriend GetFormer ()
    {
        return (HmFriend)arrItem [0];
    }

    public HmFriend GetLatter ()
    {
        return (HmFriend)arrItem [2];
    }
    
    public HmGod GetGod ()
    {
        return (HmGod)arrItem [1]; 
    }

    //  ////////////////////////////////////////////////    Property ...
    public bool IsUnitEquation ()
    {
        try {
            Ag.LogString ("  HmEquation :: IsUnitEquation   !! arrItem Num  :: " + arrItem.Count + "   Jarisoo :: " + mJarisoo);

            if (((HmEquation)arrItem [0]).arrItem [0].GetType ().ToString () == "HmFriend") {
                Ag.LogString ("  HmEquation :: IsUnitEquation   !! Type if Friend ");
                return true;
            }
            if (((HmEquation)arrItem [0]).arrItem [0].GetType ().ToString () == "HmEquation")
                return false;
        } catch (Exception ex) { 
            Ag.LogString ("  HmEquation :: IsUnitEquation   !! Error  Exception >>  " + ex.ToString ()); 
        }
        Ag.LogIntenseWord (" .... IsUnitEquation   .... Error ....   return False ...");
        return false;
    }

    public Godirum CurrentGod ()
    {
        try {
            if (arrItem [1].GetType ().ToString () == "HmGod")
                return ((HmGod)arrItem [1]).mIrum;
        } catch (Exception ex) { 
            Ag.LogString ("  HmEquation :: CurrentGod   !! Error  Exception >>  " + ex.ToString ()); 
        }
        return Godirum.NO;
    }

    public int MaxJarisu ()
    {
        int max = 0;
        try {
            foreach (MpsModel obj in arrItem) {
                if (obj.GetType ().ToString () == "HmGod")
                    continue;
                if (((HmEquation)obj).mJarisoo > max)
                    max = ((HmEquation)obj).mJarisoo;
            }
            Ag.LogString ("  HmEquation :: MaxJarisu  >> Max is   " + max);
            return max;
        } catch (Exception ex) { 
            Ag.LogString ("  HmEquation :: MaxJarisu   !! Error  Exception >>  " + ex.ToString ()); 
        }
        return 0;
    }

    public HmFriend GetFriend(int pNth)
    {
        return (HmFriend)arrItem [arrItem.Count - 1 - pNth];
    }

    //  ////////////////////////////////////////////////    Simple Sub Methods ...

    public void AddSimpleOperation (int pF, int pL, Godirum pGod)  // 35 78 Plus ...
    {
        Ag.LogIntense (3, true);
        (" HmEquation :: AddSimpleOperation  " + pF + "  " + pGod.ToString () + "  " + pL).HtLog ();
        SetItemInt (pF, new Vector3 (-7, 0, 0));  // Equa, God, Equa...
        SetGod (pGod, new Vector3 (0, 0, 0));
        SetItemInt (pL, new Vector3 (7, 0, 0));
        (" HmEquation :: AddSimpleOperation  ___________ End ").HtLog ();
        Ag.LogIntense (3, false);
    }

    public void SetItemInt (int pVal, Vector3 pAe)  // 35
    {
        HmEquation nObj = new HmEquation ();
        arrItem.Add (nObj);
        
        nObj.mJarisoo = pVal.Jarisoo ();
        (" HmEquation :: SetItemInt   >> jari = " + nObj.mJarisoo).HtLog ();
        
        for (int k=0; k<nObj.mJarisoo; k++) {
            HmFriend obj = new HmFriend (pVal.NthNum (k), new Vector3 (pAe.x + k * JJ.mgWidthOfFriend, pAe.y, pAe.z));
            (" HmEquation :: SetItemInt  >>>>  Add Unit Number   " + obj.mName).HtLog ();
            nObj.arrItem.Add (obj);
        }
    }
    
    public void SetItemEqua ()
    {
    }
    
    public void SetGod (Godirum pIrum, Vector3 pAe)
    {
        HmGod nObj = new HmGod (pIrum);
        arrItem.Add (nObj);
    }

    public override void CreateJinsim ()
    {
        foreach (MpsModel item in arrItem) {
            item.CreateJinsim ();
        }
    }

    public override void SplitProcess (bool pIsStart)
    {
        foreach (MpsModel item in arrItem) {
            item.SplitProcess (pIsStart);
        }
    }

    public override void Transform ()
    {
        Ag.LogString ("  HmEquation :: Transform   !! arrItem Num :: " + arrItem.Count);
        if (!IsUnitEquation ()) {
            Ag.LogString ("  HmEquation :: Transform   I'm NOT UnitEquation   iteration arrItem..  >>>>>  "); 
            foreach (MpsModel item in arrItem) {
                item.Transform ();
            }
            return;
        }

        Ag.LogString ("  HmEquation :: Transform   I'm UnitEquation   iteration arrItem.. ");  // Unit Equation Case ..

        Godirum curGod = CurrentGod ();
        int max = MaxJarisu ();
        switch (curGod) {
        case Godirum.PLU:
            for(int j=0; j<max; j++) {
                HmFriend latt = (HmFriend)((HmEquation) arrItem[2]).GetFriend(j);
                UnitTrans unit = new UnitTrans(((HmEquation) arrItem[0]).GetFriend(j), latt, ((HmGod) arrItem[1]).mIrum );

                // Set Position
                unit.SetResultPosi(latt.arrJinsim[0].transform.position);

                // Over 10 case ... Ceremony ... >>> 


                arrTransUnit.Add(unit);
            }
            break;
        case Godirum.MUL:
                        
            break;
        }
                    

    }

    UnitTrans mCurrentUnit;

    public void UnitTransStart()
    {
        mCurrentUnit = arrTransUnit [0];
        mCurrentUnit.StartTrans ();
    }

    public bool DidUnitTransProcessEnd()
    {
        return mCurrentUnit.DidTransFinish ();
    }

    public bool DidTransFinish()
    {
        if (arrTransUnit.Count == 0)
            return true;
        return false;
    }

    public override void  DestroyJinsim ()
    {
        foreach (MpsModel mpsObj in arrItem) {
            mpsObj.DestroyJinsim ();
        }

    }
    
}
