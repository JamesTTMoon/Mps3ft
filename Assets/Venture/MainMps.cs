using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MainMps : AmSceneBase {

    //HtVentureMan mMan = new HtVentureMan();
    StateArray arrStt;

    MpsMonoSubMethods mMpsMono = new MpsMonoSubMethods();
    GameObject mGod;


    //  ////////////////////////////////////////////////     Starting Init Job
    public override void Start ()
    {
        mTimeLooseAtStartPoint = 0.5f; // Second
        mSeldomActionNum = 5000;

        base.Start ();
        muiActive = true;

        int ttt = 1305;
        ("Jarisoo " + ttt.Jarisoo ()).HtLog (); // 3
        (" nth num " + ttt.NthNum (0) + " , " + ttt.NthNum (1)+ " , "  + ttt.NthNum (2)+ " , "  + ttt.NthNum (3)).HtLog (); // 1, 3, 5, -1

        Ag.Init();
        JJ.Init ();

        Vector3 aV = new Vector3 (1, 1, 1);
        Vector3 bV = aV;
        bV.y = 5;
        aV.z = 7;

        //(" aV : " + aV.ToString () + "  bV : " + bV.ToString ()).HtLog ();
    }
    
    public override void BaseStartSetting () // called from Start.. After Time Loose
    {
        base.BaseStartSetting ();

        myGUI.SetColumns(3, 10);
    
        InitialSetting ();
        Switch2NextOperation ();
        //mGod = GetComponent<MpsMonoSubMethods>().SetGod (Godirum.PLU);
        //mGod.GetComponent<MpsOperator> ().Venture (2, 3);
    }

    List<MdUnitOperation> arrUnit = new List<MdUnitOperation>();

    void InitialSetting()
    {
        arrUnit.Add (new MdUnitOperation (9, 1, Godirum.PLU));

        arrUnit.Add (new MdUnitOperation (1, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (2, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (3, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (4, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (5, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (6, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (7, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (8, 1, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (2, 2, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (3, 2, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (4, 2, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (6, 2, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (7, 2, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (1, 3, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (3, 3, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (5, 3, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (2, 4, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (3, 4, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (8, 4, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (2, 6, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (3, 6, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (1, 7, Godirum.PLU));
        arrUnit.Add (new MdUnitOperation (2, 7, Godirum.PLU));
    }

    void Switch2NextOperation()
    {
        if (mGod != null)
            Destroy (mGod);
        if (arrUnit.Count == 0)
            return;
        MdUnitOperation curOper = arrUnit [0];
        mGod = GetComponent<MpsMonoSubMethods>().SetGod (curOper.mGod);
        mGod.GetComponent<MpsOperator> ().Venture (curOper.mForm, curOper.mLatt);
        arrUnit.Remove (curOper);
    }

    public override void SetAsset ()
    {
        base.SetAsset ();
    }
    
 
    //  ////////////////////////////////////////////////     Update related
    public override void Update ()
    {
        base.Update ();
        if (mGod != null && mCounter % 20 == 15) {
            if (mGod.GetComponent<MpsOperator> ().GetState() == "RestInPeace")
                Switch2NextOperation();
        }
    }
    
    //  ////////////////////////////////////////////////     OnGUI related
    public override void OnGUI ()
    {
        base.OnGUI ();
        
        muiCol = 0; muiRow = 0;

        return;

        if (myGUI == null) return;
        
        if (!muiActive) 
            return;
        
        if (GUI.Button (myGUI.GetRect (muiCol, muiRow++), " < Login Scene > ")) {
            //AgStt.muiHQ.DetachScene(this);
            Application.LoadLevel("Login");
        }
        
        if (GUI.Button (myGUI.GetRect (muiCol, muiRow++), " Login ")) {
        
        }
        
    }
}
