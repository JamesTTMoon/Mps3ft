using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

        Cns.SetConstants ();

    }
    
    public override void BaseStartSetting () // called from Start.. After Time Loose
    {
        base.BaseStartSetting ();
        
        //Ag.LogIntenseWord("Set column 3 10");
        myGUI.SetColumns(3, 10);

    }

    GameObject mForm, mLatt;
    List<GameObject> arrJinsim;

    void GenerateTheStateArray ()
    {
        // Process of One Operation .. So it has mForm, mLatt, mGod..

        // 1 + 1 = 2
        arrStt = new StateArray ();

        arrStt.AddAMemberAndEntryAction ("Init", 2f, "Normal", ()=>{
            mForm = mRscrcMan.GetComPrefab("Friends", "ONEY");
            mForm.transform.position =  new Vector3 (-7, 0, 0);
            mForm.transform.Rotate(new Vector3(0, 0, 180 ));

            mLatt = mRscrcMan.GetComPrefab("Friends", "ONEY");
            mLatt.transform.position =  new Vector3 (7, 0, 0);
            mLatt.transform.Rotate(new Vector3(0, 0, 180 ));
        });

        arrStt.AddAMemberAndEntryAction ("JinsimIntro", 2f, "Normal", () => {
            mForm.AddComponent<HtFriendIdv>();
            mLatt.AddComponent<HtFriendIdv>();
            mForm.GetComponent<HtFriendIdv>().SetFff(Fff.ONEY);
            mLatt.GetComponent<HtFriendIdv>().SetFff(Fff.ONEY);
            mForm.GetComponent<HtFriendIdv>().SetState("JinsimIntro");
            mLatt.GetComponent<HtFriendIdv>().SetState("JinsimIntro");

            mForm.GetComponent<HtFriendIdv>().CreateJinsim();
            mLatt.GetComponent<HtFriendIdv>().CreateJinsim();




        });

        arrStt.AddAMemberAndEntryAction ("JinsimRelease", 2f, "Normal", () => {
            mForm.AddComponent<HtFriendIdv> ().SetState("Destroy");
            mLatt.AddComponent<HtFriendIdv> ().SetState("Destroy");
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
