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
        JJ.Init ();

        Vector3 aV = new Vector3 (1, 1, 1);
        Vector3 bV = aV;
        bV.y = 5;
        aV.z = 7;

        (" aV : " + aV.ToString () + "  bV : " + bV.ToString ()).HtLog ();


    }
    
    public override void BaseStartSetting () // called from Start.. After Time Loose
    {
        base.BaseStartSetting ();
        
        //Ag.LogIntenseWord("Set column 3 10");
        myGUI.SetColumns(3, 10);

    }

    GameObject mForm, mLatt, mHon;
    List<GameObject> arrJsObj;
    //List<VecRot> arrHonJsVecrot;

    void GenerateTheStateArray ()
    {
        // Process of One Operation .. So it has mForm, mLatt, mGod..

        // 1 + 1 = 2
        arrStt = new StateArray ();

        arrStt.AddAMemberAndEntryAction ("Init", 2f, "Normal", ()=>{
            JJ.mgGod = Godirum.PLU;
            mForm = mRscrcMan.GetComPrefab("Friends", "ONEY");
            mForm.transform.position =  new Vector3 (-7, 0, 0);
            mForm.transform.Rotate(new Vector3(0, 0, 180 ));

            mLatt = mRscrcMan.GetComPrefab("Friends", "ONEY");
            mLatt.transform.position =  new Vector3 (7, 0, 0);
            mLatt.transform.Rotate(new Vector3(0, 0, 180 ));
        });

        arrStt.AddAMemberAndEntryAction ("JinsimIntro", 2f, "Normal", () => {
            mForm.AddComponent<HtFriendIdv>(); // there are 10 objects.. so.. no drag and drop.. 
            mLatt.AddComponent<HtFriendIdv>();
            mForm.GetComponent<HtFriendIdv>().SetFff(Fff.ONEY);
            mLatt.GetComponent<HtFriendIdv>().SetFff(Fff.ONEY);
            mForm.GetComponent<HtFriendIdv>().SetState("JinsimIntro");
            mLatt.GetComponent<HtFriendIdv>().SetState("JinsimIntro");
            // Jinsim Assign ...
            arrJsObj = mForm.GetComponent<HtFriendIdv>().CreateJinsim();
            arrJsObj.AddRange(mLatt.GetComponent<HtFriendIdv>().CreateJinsim() );
            Ag.LogIntenseWord( "  arrJsObj Count   " + arrJsObj.Count);
        });

        arrStt.AddAMemberAndEntryAction ("JinsimJumbi", 2f, "Normal", () => {
            mForm.GetComponent<HtFriendIdv> ().SetState("Destroy");
            mLatt.GetComponent<HtFriendIdv> ().SetState("Destroy");

            mHon = mRscrcMan.GetComPrefab("Friends", "TWOER");
            mHon.AddComponent<HtFriendIdv>();
            mHon.GetComponent<HtFriendIdv>().SetFff(Fff.TWOER);
            mHon.transform.position =  new Vector3 (0, 0, 1);
            mHon.transform.Rotate(new Vector3(0, 0, 180 ));

            List<VecRot> honVecrot = mHon.GetComponent<HtFriendIdv>().HonPosition(); // Hon Positions...

            if (arrJsObj.Count != honVecrot.Count)
                Ag.LogIntenseWord( " It's Big Problem .....   JS Count no match  ");
            int k=0;
            foreach(GameObject jsgo in arrJsObj) {
                jsgo.GetComponent<HtJinsimIdv>().SetTarget(honVecrot[k++]);
                jsgo.GetComponent<HtJinsimIdv>().SetState("Jumbi");
            }





        });

        arrStt.AddAMemberAndEntryAction ("JinsimTransform", 2f, "Normal", () => {

            foreach(GameObject jsgo in arrJsObj) {
                jsgo.GetComponent<HtJinsimIdv>().SetState("Chum");
            }

            /* GameObject go;
             foreach(VecRot vr in arrHonJsVecrot) {
                go = mRscrcMan.GetComPrefab("Friends", "Jinsim");
                go.transform.position = vr.Ae;
                go.transform.SetScaleFactor(vr.Kugi);
                go.transform.Rotate(vr.Dora);
            } */

        });


        arrStt.AddAMemberAndEntryAction ("ShowResult", 2f, "Normal", () => {
            foreach(GameObject jsgo in arrJsObj) {
                jsgo.GetComponent<HtJinsimIdv>().SetState("Result");
            }
        });
     
        arrStt.AddAMemberAndEntryAction ("RestInPeace", 0f, "Normal", () => {
            foreach(GameObject jsgo in arrJsObj) {
                jsgo.GetComponent<HtJinsimIdv>().SetState("Destroy");
            }

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
