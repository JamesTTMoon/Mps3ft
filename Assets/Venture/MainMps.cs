using UnityEngine;
using System.Collections;

public class MainMps : AmSceneBase {

    //HtVentureMan mMan = new HtVentureMan();
    StateArray arrStt = new StateArray ();

    HmFriend mForm, mLatt;
    HmGod mGod;

    public delegate void StateChanged(string pStt);
    public StateChanged delStateChg;

    //HtManager mMan = new HtManager();


    //  ////////////////////////////////////////////////     Starting Init Job
    public override void Start ()
    {
        mTimeLooseAtStartPoint = 0.1f; // Second
        mSeldomActionNum = 500;
        SetState ();
        base.Start ();
        muiActive = true;

        int ttt = 1305;
        ("Jarisoo " + ttt.Jarisoo ()).HtLog (); // 3
        (" nth num " + ttt.NthNum (0) + " , " + ttt.NthNum (1)+ " , "  + ttt.NthNum (2)+ " , "  + ttt.NthNum (3)).HtLog (); // 1, 3, 5, -1

        MdIntObj intObj = new MdIntObj (1045, true);

        Ag.Init();
    }
    
    public override void BaseStartSetting () // called from Start.. After Time Loose
    {
        base.BaseStartSetting ();
        
        //Ag.LogIntenseWord("Set column 3 10");
        myGUI.SetColumns(3, 10);

    }
    
    void SetState ()
    {
        // Process of One Operation .. So it has mForm, mLatt, mGod..

        arrStt.AddAMember ("Init", 2f);
        arrStt.AddEntryAction (() => {
            Ag.LogString (" Init state ");
            //mMan.SetOperation(12, 21, Godirum.PLU);
            //mMan.SetOperation(3, 2, Godirum.PLU);
        });

     

        arrStt.SetStateWithNameOf ("Init");
        arrStt.SetSerialExitMember ();

        arrStt.delStateChange += (string pStt ) => {

            //mMan.SetState(pStt);

        };

    }
    public override void SetAsset ()
    {
        base.SetAsset ();
        

    }
    
 
    //  ////////////////////////////////////////////////     Update related
    public override void Update ()
    {
        base.Update ();

        arrStt.DoAction ();
    }
    
    //  ////////////////////////////////////////////////     OnGUI related
    public override void OnGUI ()
    {
        base.OnGUI ();
        
        muiCol = 0; muiRow = 0;
        
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
