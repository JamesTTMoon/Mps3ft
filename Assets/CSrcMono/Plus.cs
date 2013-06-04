using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Plus : MpsOperator { 
    
    //HtVentureMan mMan = new HtVentureMan();

    //  ////////////////////////////////////////////////     Starting Init Job
    public override void Start ()
    {
        mTimeLooseAtStartPoint = 0.1f; // Second
        mSeldomActionNum = 5000;
        base.Start ();
        muiActive = true;
        // mGod = Godirum.PLU;
    }
    
    public override void BaseStartSetting () // called from Start.. After Time Loose
    {
        base.BaseStartSetting ();
        
        //Ag.LogIntenseWord("Set column 3 10");
        myGUI.SetColumns(3, 10);
        
    }

    void SetStateOfObjects()
    {
        if (mLatt != null)
            mLatt.SetState(arrStt.GetCurStateName());
        if (mForm != null)
            mForm.SetState(arrStt.GetCurStateName());

        if (mHon != null)
            mHon.SetState(arrStt.GetCurStateName());
        if (m10obj != null)
            m10obj.SetState(arrStt.GetCurStateName());
        foreach(GameObject jsgo in arrJsObj) {
            jsgo.SetState(arrStt.GetCurStateName());
        }
        foreach(GameObject jsgo in arrEyeObj) {
            jsgo.SetState(arrStt.GetCurStateName());
        }
    }

    void ReplaceWithEyeSingle()
    {
        //(" Plus :: ReplaceWithEyeSingle  " + arrEyeObj.Count).HtLog ();
        foreach(GameObject jsgo in arrEyeObj) {
            ("     >>>>   name  :::   " + jsgo.GetComponent<HtEyeIdv>().mName).HtLog();
            if (jsgo.GetComponent<HtEyeIdv>().mName == "EyeDouble" || jsgo.GetComponent<HtEyeIdv>().mName == "EyeTriple" ) {
                //jsgo.GetComponent<HtEyeIdv>().ReplaceWithEyeSingle();
                Destroy(jsgo);
                return;
            }
        }
        (" Plus :: ReplaceWithEyeSingle  " + arrEyeObj.Count).HtLog ();
    }

    void ReplaceAllEyes()
    {
        List<GameObject> tempArr = new List<GameObject> ();
        tempArr.AddRange( arrEyeObj );
        arrEyeObj.Clear ();

        foreach(GameObject jsgo in tempArr) {
            //("  Eye Name  " + jsgo.GetComponent<HtEyeIdv>().mName ).HtLog();
            if (jsgo.GetComponent<HtEyeIdv>().mName == "EyeSingle") {
                arrEyeObj.Add(jsgo);
            } else {
            //if (jsgo.GetComponent<HtEyeIdv>().mName != "EyeSingle") {
                jsgo.GetComponent<HtEyeIdv>().ReplaceWithEyeSingle();
                jsgo.GetComponent<HtEyeIdv>().SetTimerAction(20, "Destroy");
            }
        }

    }



    //  ////////////////////////////////////////////////     Set Member Variables...


    MdFormatter mMpsFormat;
    MdChubang mCurChubang;

    public override void Venture(int pF, int pL)
    {
        // 1 + 1 = 2
        arrStt = new StateArray ();

        arrStt.AddAMemberAndEntryAction ("Init", 0.5f, "Normal", () => {
            Ag.LogIntenseWord("      >> Start <<       mMpsFormat = new MdFormatter (pF, pL);  ");
            mMpsFormat = new MdFormatter (pF, pL, Godirum.PLU);
            JJ.Init ();
            Ag.LogIntenseWord("      >> End <<       mMpsFormat = new MdFormatter (pF, pL);  ");
        });

        arrStt.AddAMemberAndEntryAction ("GetChubang", 0.1f, "Normal", () => {
            mCurChubang = mMpsFormat.GetChubang ();
        });

        arrStt.AddAMemberAndEntryAction ("ChubangInit", 1f, "Normal", () => {
            Ag.LogIntenseWord("      >> Start <<     ChubangInit  ");
            mForm = mRscrcMan.GetFriend(mCurChubang.mFff); // Add Script, Variable..
            mForm.transform.SetAeDora(mCurChubang.mFvr);
            mForm.GetComponent<HtFriendIdv>().LoadEyes(arrEyeObj);
            mLatt = mRscrcMan.GetFriend(mCurChubang.mLff);
            mLatt.transform.SetAeDora(mCurChubang.mLvr);
            mLatt.GetComponent<HtFriendIdv>().LoadEyes(arrEyeObj);

            SetGod(Godirum.PLU);
        });
        
        arrStt.AddAMemberAndEntryAction ("JinsimIntro", 0.5f, "Normal", () => {
            Ag.LogIntenseWord("      >> Start <<     JinsimIntro  ");
            mForm.SetState(arrStt.GetCurStateName()); // MoveBack Start
            mLatt.SetState(arrStt.GetCurStateName());

            ReplaceAllEyes();

            // Jinsim Array Creation..  Assign Range .. ...
            arrJsObj = mForm.GetComponent<HtFriendIdv>().CreateJinsim();
            arrJsObj.AddRange(mLatt.GetComponent<HtFriendIdv>().CreateJinsim() );
            SetGod(Godirum.PLU);
            //Ag.LogIntenseWord("  Jinsim Count   " + arrJsObj.Count);
        });
        
        //arrStt.AddAMemberAndEntryAction ("JinsimJumbi", 0.5f, "Normal", () => {  // <<<<<  F L 없어지고 Hon 출현  >>>>>
        arrStt.AddAMemberAndEntryAction ("JinsimJumbi", 2f, "Normal", () => {  // <<<<<  F L 없어지고 Hon 출현  >>>>>
            Ag.LogIntenseWord("      >> Start <<     JinsimJumbi  ");
            mForm.SetState(arrStt.GetCurStateName()); // Destroyed ...
            mLatt.SetState(arrStt.GetCurStateName());
            (" JinsimJumbi    >>>>   mCurChubang.mRff ::  " + mCurChubang.mHff.ToString()).HtLog();

            //  -----     Instantiate   ___   Hon   ___   -----  //
            mHon = mRscrcMan.GetFriend(mCurChubang.mHff); // Add Script, Variable..
            mHon.transform.SetAeDora(mCurChubang.mHonVr);
            mHon.GetComponent<HtFriendIdv>().LoadEyes(null, pIsHon:true);  //  This is Result Eyes ... 
            SetGod(Godirum.PLU);

            mHon.SetTarget(mCurChubang.mHTarVr);
            List<VecRot> honVecrot = mHon.GetComponent<HtFriendIdv>().HonPosition(pIsOver10:(mCurChubang.mKind == Cb.PLUS_OVER10) );
            List<VecRot> honEyeVect = mHon.GetComponent<HtFriendIdv>().HonEyePosition(pIsOver10:(mCurChubang.mKind == Cb.PLUS_OVER10) ); //  Hon Eye Positions.

            int k=0;

            // Is Over 10 ... 
            if (mCurChubang.mKind == Cb.PLUS_OVER10) {
                m10obj = mRscrcMan.GetComPrefab ("Friends", Fff.TEN.ToString() );
                m10obj.transform.SetAeDora(mCurChubang.mHonVr);

                for(int jk=0; jk<10; jk++) {
                    arrJsObj[jk].transform.parent = m10obj.transform;
                }
            }

            foreach(GameObject jsgo in arrJsObj) { // Set Targets of Jinsims...
                jsgo.SetTarget(honVecrot[k++]);
            }
            k=0;
            foreach(GameObject jsgo in arrEyeObj) { //  9 EyeSingle in arrEyeObj ... 3 EyeTriple in honEyeVect ...
                //("  JinsimJumbi >>  honEyeVect  " + honEyeVect.Count + " , k = " + k).HtLog();

                VecRot tar = honEyeVect[k].GetEyeTargetFromHon();
                if (tar == null) {
                    tar = honEyeVect[++k].GetEyeTargetFromHon();
                    //("  JinsimJumbi >>  k++  " + k).HtLog();
                }
                jsgo.SetTarget(tar);
                //jsgo.SetTarget(honEyeVect[k++]);
            }

            SetStateOfObjects();
        });
        
        arrStt.AddAMemberAndEntryAction ("JinsimChum", 5f, "Normal", () => {
            Ag.LogIntenseWord("      >> Start <<     JinsimChum  ");
            SetStateOfObjects();

            if (mCurChubang.mKind == Cb.PLUS_OVER10) {
                arrStt.SetNextStateOf("JinsimChum", "Make10");

            }
        });

        arrStt.AddAMemberAndEntryAction ("Result", 2f, "Normal", () => {
            SetStateOfObjects();

        });

        arrStt.AddAMemberAndEntryAction ("ShowResult", 2f, "Normal", () => {
            //arrStt.SetStateWithNameOf("Init");
            SetStateOfObjects();
        });
        
        arrStt.AddAMemberAndEntryAction ("DestroyAll", 1f, "Normal", () => {
            DestroyAll();
        });
        arrStt.AddAMemberAndEntryAction ("RestInPeace", 0f, "Normal", () => {
        });


        arrStt.AddAMemberAndEntryAction ("Make10", 2f, "Normal", () => {  // Additional State ...
            SetStateOfObjects();
            
        });

        arrStt.SetSerialExitMember ();
        arrStt.SetStateWithNameOf ("Init");
    }

    void DestroyAll ()
    {
        if (mHon != null)
            mHon.GetComponent<HtIndvBase>().SetTimerAction(10, "Destroy");
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

    }
}
