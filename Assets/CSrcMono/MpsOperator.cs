using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MpsOperator : AmSceneBase { 
    
    //HtVentureMan mMan = new HtVentureMan();
    protected StateArray arrStt;
    public Godirum mGod;
    protected GameObject mForm, mLatt, mHon, m10obj;
    protected List<GameObject> arrJsObj = new List<GameObject>(), arrEyeObj = new List<GameObject>();

    public virtual void Venture(int pF, int pL) 
    {

    }

    public string GetState()
    {
        return arrStt.GetCurStateName ();
    }

    public void SetGod(Godirum pGod)
    {
        if (mForm != null)
            mForm.GetComponent<HtIndvBase> ().SetGod (pGod);
        if (mLatt != null)
            mLatt.GetComponent<HtIndvBase> ().SetGod (pGod);
        if (mHon != null)
            mHon.GetComponent<HtIndvBase> ().SetGod (pGod);
        foreach (GameObject obj in arrJsObj) {
            obj.GetComponent<HtIndvBase> ().SetGod (pGod);
        }
        foreach (GameObject obj in arrEyeObj) {
            obj.GetComponent<HtIndvBase> ().SetGod (pGod);
        }
    }

}