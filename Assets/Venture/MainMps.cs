using UnityEngine;
using System.Collections;

public class MainMps : AmSceneBase {

    //HtVentureMan mMan = new HtVentureMan();
    StateArray arrStt;



    //  ////////////////////////////////////////////////     Starting Init Job
    public override void Start ()
    {
        mTimeLooseAtStartPoint = 0.1f; // Second
        mSeldomActionNum = 5000;
        GenerateTheStateArray ();
        base.Start ();
        muiActive = true;

        int ttt = 1305;
        ("Jarisoo " + ttt.Jarisoo ()).HtLog (); // 3
        (" nth num " + ttt.NthNum (0) + " , " + ttt.NthNum (1)+ " , "  + ttt.NthNum (2)+ " , "  + ttt.NthNum (3)).HtLog (); // 1, 3, 5, -1

        Ag.Init();

    }
    
    public override void BaseStartSetting () // called from Start.. After Time Loose
    {
        base.BaseStartSetting ();
        
        //Ag.LogIntenseWord("Set column 3 10");
        myGUI.SetColumns(3, 10);

    }

    GameObject mForm, mLatt;

    void GenerateTheStateArray ()
    {
        // Process of One Operation .. So it has mForm, mLatt, mGod..

        // 1 + 1 = 2
        arrStt = new StateArray ();

        Ag.LogIntenseWord ("  >>>  GenerateTheStateArray  <<<  ");

        arrStt.AddAMember ("Init", 2f);
        arrStt.AddEntryAction(()=>{

        //arrStt.AddAMemberAndEntryAction ("Init", 2f, "Normal", ()=>{

            Ag.LogIntenseWord("   yahoo  Init >>>>> ");

            mForm = mRscrcMan.GetComPrefab("Friends", "ONEY");

            mForm.transform.position =  new Vector3 (-7, 0, 0);



        });

     
        arrStt.AddAMemberAndEntryAction ("RestInPeace", 0f, "Normal", () => {
        });


        arrStt.SetSerialExitMember ();
        arrStt.SetStateWithNameOf ("Init");
    }

    public override void SetAsset ()
    {
        base.SetAsset ();
    }
    
 
    //  ////////////////////////////////////////////////     Update related
    public override void Update ()
    {
        base.Update ();

        if (arrStt != null)
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
