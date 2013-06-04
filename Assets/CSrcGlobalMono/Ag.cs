// [2012:11:11:MOON] Single Mode...
// VER_7_52_MOON  VER_7_61_MOON  VER_7_62_MOON 
// [2013:1:3:MOON] New Started

using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class AmPack
{}

public delegate void FunctionPointer();
public delegate bool FunctionPointerBool();
public delegate AmPack FunctionPointerAmPack();

    
    
//enum Slot { SHIRT, PANT, GLOVE, SOCK, SHOE };
enum LogStyle { SIMPLE, MARK, TEMP_INTENSE };


public class Rank {
    public int mRank, mCountry, mScore;
    public string mNick;
    
    public Rank() {}
    
    public Rank( int r, int c, int s ) {
        mRank = r; mCountry = c; mScore = s;
    }
    
    public void ShowMySelf() {
        Debug.Log (">>>>>>>>>>>>>>>>>>>>>>>> Rank : " + mRank + "     Country : " + mCountry + "     Score : " + mScore );
    }
}

public class Ag  {
    public static bool mUniformMode = true , mPlaneMode = false;
    public static bool mPlanModeKP = false;
    public static string mLoginPhase, mFBState, mFBOrder, mDebugStr, mDebugStrB;
    //  ////////////////////////////////////////////////     Debug Mode...
    public static bool mIsDebug;
    
    
    //  ////////////////////////////////////////////////     Constant...  
    public const int DIRECT_WIDTH = 120, MIN_INSERT_WIDTH = 200;
    public const int SKILL_MIN_LEFT_MARGIN = 100, SKILL_MIN_INS_WID = 200;
    
    //  ////////////////////////////////////////////////     Guest Mode...  
    public static bool mgIsGuestMode;
 
    public enum WorkState { INIT, WAIT, NOBODY102, FOUND101, AWAY103, SUCCESS106 };
    public static WorkState mgWorkState;
    
    //  ////////////////////////////////////////////////     Platform
    public enum Platform { IOS, DRD, OSX };
    public static Platform mPlatform;
    
    public static float mgScrX, mgScrY;
    public static string mgLanguage;
    
    //  ////////////////////////////////////////////////     Net, Game rel. State...
    public static bool mgIsThePacketSent2theServer, mgAmIhavingPorsion, mIsSuspendOnPurpose, mNetPackWaiting, mThreadStopped;
    public static UInt32 mgRPSTotalContactUserNum, mgRPSCurrGameRoomNum;
    
    //  ////////////////////////////////////////////////     Game Related...
    public static byte mgDirection, mgSkill;
    public static int mgPrevScore, mRound;
    public static string mAniBall, mAniKick, mAniGlkp;
    
    //  ////////////////////////////////////////////////     FB / Login / Shop Related...
    
    //public static AmFacebook mFBobj;
    public static string mgFBUserName, mgFBid ;
    public static UInt32 mUpdateSuccess ; // 1; success, 2; No user found
    public static int mEventType, mgUserNum, mgGameRoomNum;
    public static bool mgFBisValid, mUserCheckOK, mNickCheckOK, mBallEventAlready = false;
    
    //public static bool mLogin = false;
    
    //  ////////////////////////////////////////////////     ////////////////////////     >>>>> Game Network Related........ <<<<<
    //public static AmNetwork net;
    //public static byte[] recvBuffer = new byte[1024];      // ****** Global recvBuffer *****  // 
    //public static NetworkStream mNetworkStream;
    //public static string mgIPAddr = "14.63.222.197";  //"172.30.1.1"; // "14.63.222.197", 5001);  // Server.. 
    //public static string mgIPAddr = "172.30.1.3"; // "14.63.222.197", 5001);  // Server.. 
    //public static int mgPort = 5001;
    //public static UInt64 mgSocket;
    public static UInt32 mgMatchUNO, mgRoomUNO, mgSelfWinNo, mgEnemWinNo;//mgWinNo, mgLosNo;
    public static bool mgServerLoggedIn, mgIsKick, mgDidGameFinish, mgDidWin, mgEnemGiveup, mGameStartAlready, mgDidGameAway, mgGamePackReceived, mShowWaitSign, mSingleMode ; // [2012:11:11:MOON] Single Mode...
    public static byte mgStepSend, mgEnemDirec, mgEnemSkill;
    
    public static string mReceiptSample = "ewoJInNpZ25hdHVyZSIgPSAiQWpiU0F4NzFBNzNoU3hjRTh0c2tuRW1wLzFpckI2SURpcmhJdDFpdG9vZkxZelltSVdtamljdG1SekpMTkc1Y2JwM1Y1WUlDek03ZTlJVEN3dXMzaDFQZU9lSmVVWUxHSzJSSTE0alV5cDZSTDVkOHhVVDIwZGVzSkpQQkN2SUVaNmxjMUljVm05SlNzdWtkSXRzUDFZMjUreHA0VXdsZS9nNnB4SzV1S3RaRkFBQURWekNDQTFNd2dnSTdvQU1DQVFJQ0NHVVVrVTNaV0FTMU1BMEdDU3FHU0liM0RRRUJCUVVBTUg4eEN6QUpCZ05WQkFZVEFsVlRNUk13RVFZRFZRUUtEQXBCY0hCc1pTQkpibU11TVNZd0pBWURWUVFMREIxQmNIQnNaU0JEWlhKMGFXWnBZMkYwYVc5dUlFRjFkR2h2Y21sMGVURXpNREVHQTFVRUF3d3FRWEJ3YkdVZ2FWUjFibVZ6SUZOMGIzSmxJRU5sY25ScFptbGpZWFJwYjI0Z1FYVjBhRzl5YVhSNU1CNFhEVEE1TURZeE5USXlNRFUxTmxvWERURTBNRFl4TkRJeU1EVTFObG93WkRFak1DRUdBMVVFQXd3YVVIVnlZMmhoYzJWU1pXTmxhWEIwUTJWeWRHbG1hV05oZEdVeEd6QVpCZ05WQkFzTUVrRndjR3hsSUdsVWRXNWxjeUJUZEc5eVpURVRNQkVHQTFVRUNnd0tRWEJ3YkdVZ1NXNWpMakVMTUFrR0ExVUVCaE1DVlZNd2daOHdEUVlKS29aSWh2Y05BUUVCQlFBRGdZMEFNSUdKQW9HQkFNclJqRjJjdDRJclNkaVRDaGFJMGc4cHd2L2NtSHM4cC9Sd1YvcnQvOTFYS1ZoTmw0WElCaW1LalFRTmZnSHNEczZ5anUrK0RyS0pFN3VLc3BoTWRkS1lmRkU1ckdYc0FkQkVqQndSSXhleFRldngzSExFRkdBdDFtb0t4NTA5ZGh4dGlJZERnSnYyWWFWczQ5QjB1SnZOZHk2U01xTk5MSHNETHpEUzlvWkhBZ01CQUFHamNqQndNQXdHQTFVZEV3RUIvd1FDTUFBd0h3WURWUjBqQkJnd0ZvQVVOaDNvNHAyQzBnRVl0VEpyRHRkREM1RllRem93RGdZRFZSMFBBUUgvQkFRREFnZUFNQjBHQTFVZERnUVdCQlNwZzRQeUdVakZQaEpYQ0JUTXphTittVjhrOVRBUUJnb3Foa2lHOTJOa0JnVUJCQUlGQURBTkJna3Foa2lHOXcwQkFRVUZBQU9DQVFFQUVhU2JQanRtTjRDL0lCM1FFcEszMlJ4YWNDRFhkVlhBZVZSZVM1RmFaeGMrdDg4cFFQOTNCaUF4dmRXLzNlVFNNR1k1RmJlQVlMM2V0cVA1Z204d3JGb2pYMGlreVZSU3RRKy9BUTBLRWp0cUIwN2tMczlRVWU4Y3pSOFVHZmRNMUV1bVYvVWd2RGQ0TndOWXhMUU1nNFdUUWZna1FRVnk4R1had1ZIZ2JFL1VDNlk3MDUzcEdYQms1MU5QTTN3b3hoZDNnU1JMdlhqK2xvSHNTdGNURXFlOXBCRHBtRzUrc2s0dHcrR0szR01lRU41LytlMVFUOW5wL0tsMW5qK2FCdzdDMHhzeTBiRm5hQWQxY1NTNnhkb3J5L0NVdk02Z3RLc21uT09kcVRlc2JwMGJzOHNuNldxczBDOWRnY3hSSHVPTVoydG04bnBMVW03YXJnT1N6UT09IjsKCSJwdXJjaGFzZS1pbmZvIiA9ICJld29KSW05eWFXZHBibUZzTFhCMWNtTm9ZWE5sTFdSaGRHVXRjSE4wSWlBOUlDSXlNREV5TFRBNUxURXdJREl4T2pVME9qUXpJRUZ0WlhKcFkyRXZURzl6WDBGdVoyVnNaWE1pT3dvSkluVnVhWEYxWlMxcFpHVnVkR2xtYVdWeUlpQTlJQ0l3WkRSbU9UbGtOVFl6WVRZd09HTmtPVEZoTldGbVlUQTNZMlZtWm1ObE1EYzVOVGt3TURWbElqc0tDU0p2Y21sbmFXNWhiQzEwY21GdWMyRmpkR2x2YmkxcFpDSWdQU0FpTVRBd01EQXdNREExTlRjek9UVTBOQ0k3Q2draVluWnljeUlnUFNBaU1TNHdJanNLQ1NKMGNtRnVjMkZqZEdsdmJpMXBaQ0lnUFNBaU1UQXdNREF3TURBMU5UY3pPVFUwTkNJN0Nna2ljWFZoYm5ScGRIa2lJRDBnSWpFaU93b0pJbTl5YVdkcGJtRnNMWEIxY21Ob1lYTmxMV1JoZEdVdGJYTWlJRDBnSWpFek5EY3pNemt5T0RNeU5EY2lPd29KSW5CeWIyUjFZM1F0YVdRaUlEMGdJbU52YlM1aGNIQnpaM0poY0doNUxuSndjMjl1YkdsdVpTNDJOVEF3SWpzS0NTSnBkR1Z0TFdsa0lpQTlJQ0kxTmpBNU56RXpPRGtpT3dvSkltSnBaQ0lnUFNBaVkyOXRMbUZ3Y0hObmNtRndhSGt1Y25CemIyNXNhVzVsSWpzS0NTSndkWEpqYUdGelpTMWtZWFJsTFcxeklpQTlJQ0l4TXpRM016TTVNamd6TWpRM0lqc0tDU0p3ZFhKamFHRnpaUzFrWVhSbElpQTlJQ0l5TURFeUxUQTVMVEV4SURBME9qVTBPalF6SUVWMFl5OUhUVlFpT3dvSkluQjFjbU5vWVhObExXUmhkR1V0Y0hOMElpQTlJQ0l5TURFeUxUQTVMVEV3SURJeE9qVTBPalF6SUVGdFpYSnBZMkV2VEc5elgwRnVaMlZzWlhNaU93b0pJbTl5YVdkcGJtRnNMWEIxY21Ob1lYTmxMV1JoZEdVaUlEMGdJakl3TVRJdE1Ea3RNVEVnTURRNk5UUTZORE1nUlhSakwwZE5WQ0k3Q24wPSI7CgkiZW52aXJvbm1lbnQiID0gIlNhbmRib3giOwoJInBvZCIgPSAiMTAwIjsKCSJzaWduaW5nLXN0YXR1cyIgPSAiMCI7Cn0=";
    
    //public static Texture2D mgFBphoto;
    
    public static ArrayList arrRankList;
 
    
    
   
    
#if UNITY_IPHONE
    public static bool mgIsRetina, mgIsIPhone;

    //  ////////////////////////////////////////////////     IAP
    //public static AmIAP mIAP;
    
    public static int mIapPrice;

#endif
#if UNITY_ANDROID    
    public static AmIAP mIAP;
    public static AmIABdroid AmIAB;
    public static int mIapPrice;
#endif    
    
    
    
    
    //  ////////////////////////////////////////////////     ////////////////////////     >>>>> Initialize.... <<<<<
    public static void Init() {
        // [2013:1:3:MOOON] New Started
        Ag.LogLineIntense("Unity :: Ag.cs >>>>>   Init ");
        
        
        
        
        // Debug, Platform related Settings.
        mIsDebug = true;
        
        // [2012:11:11:MOON] Single Mode...
        mSingleMode = Ag.mgFBisValid = false;
        
        // Variables Initiation
        mShowWaitSign = mgServerLoggedIn = mgFBisValid = mgIsGuestMode = 
         mgIsThePacketSent2theServer = mgAmIhavingPorsion = mGameStartAlready = mNetPackWaiting = false;
        Ag.mLoginPhase = "LP";
        
        // Screen Size
        mgScrX = Screen.width; mgScrY = Screen.height;
        if ( mgScrX < mgScrY ) { float longer = mgScrY; mgScrY = mgScrX;  mgScrX = longer; } 
        Ag.LogString("Ag::Init   Screen Size >>>>>   mgScrX: " + mgScrX + ", mgScrY: " + mgScrY);
        Ag.LogNewLine(2);
        
        // Language
        Ag.mgLanguage = Application.systemLanguage.ToString() ;
        Ag.mgLanguage = Ag.mgLanguage.Substring(0, 3);
        if ( Ag.mgLanguage != "Chi" && Ag.mgLanguage != "Kor" && Ag.mgLanguage != "Jap" && 
             Ag.mgLanguage != "Spa" && Ag.mgLanguage != "Ger" )
            Ag.mgLanguage = "Eng";
        Ag.LogString("Ag::Init   Current Language is >>> " + Ag.mgLanguage);
        
#if UNITY_IPHONE
        Ag.mPlatform = Platform.IOS;
        //Ag.mIAP = new AmIAP();
        
        if ( iPhone.generation == iPhoneGeneration.iPhone4 || iPhone.generation == iPhoneGeneration.iPhone4S) {
            Ag.mgIsRetina = true; Ag.mgIsIPhone = true;
        }
        if ( iPhone.generation == iPhoneGeneration.iPhone3GS) {
            Ag.mgIsRetina = false; Ag.mgIsIPhone = true;
        }
#endif
#if UNITY_ANDROID
        //Ag.mPlatform = Platform.OSX;
        //else
        Ag.mIAP = new AmIAP();
        Ag.mPlatform = Platform.DRD;
        //Screen.SetResolution((Screen.height/2)*3 ,Screen.height,false);
        AgUtil.mAppleReviewURL = "https://play.google.com/store/apps/details?id=com.appsgraphy.psykickbattle&feature=search_result#?t=W251bGwsMSwyLDEsImNvbS5hcHBzZ3JhcGh5LnBzeWtpY2tiYXR0bGUiXQ";
        AgUtil.mAppStoreURL = AgUtil.mAppleReviewURL;
        mgScrX = Screen.height/2 * 3; mgScrY = Screen.height;
#endif
      
        
        Ag.LogIntenseWord("  End of Ag.Init ");

    }
    
    
    public static bool IsSmartDevice() {
        return Ag.mPlatform == Platform.IOS || Ag.mPlatform == Platform.DRD ;
    }
    
    /*/  ////////////////////////////////////////////////     ////////////////////////     Finite State Machine ...
    public static void SetWorldState ( string pState ) {
        Ag.net.ReSetCounter();
        Ag.mgWorldStateArray.SetStateWithNameOf(pState);
    }
    
    public static string GetWorldState () {
        return Ag.mgWorldStateArray.mCurState.mName;
    }
    
    public static void UpdateAction() {
        Ag.mgWorldStateArray.DoAction();
    } // */
    
    
    //  ////////////////////////////////////////////////     ////////////////////////     Public Functions...
    public static void SwitchStep() {
        if (mgStepSend == 1) mgStepSend = 2;
        else mgStepSend = 1;
    }

    
    public static DateTime UnixTimestampToDateTime(UInt64 _UnixTimeStamp)
    {
        Ag.LogString("UnixTime:: " + _UnixTimeStamp);
        return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(_UnixTimeStamp);
    }
    
    
    
    //  ////////////////////////////////////////////////     ////////////////////////     >>>>> Debugging.... <<<<<
    public static string SIGN_MARK = 
        "SIGN_MARK    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
    public static string SIGN_INTENSE = 
        "SIGN_INTENSE >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
 
    public static void SignIntenseLog() {
        if (Application.platform == RuntimePlatform.OSXEditor)
            Debug.Log (SIGN_INTENSE + "\n");
    }
    
    public static void LogString( string pStr ) {
        if (Application.platform == RuntimePlatform.OSXEditor)
            Debug.Log ("LOG >> " + pStr + " \n");
    }
    
    public static void LogWithBool( string pStr, bool pBool ) {
        Debug.Log ("Ag.LogWithBool>>>>>>>>>>>>>>>>>>>> [ " + pStr + " ] :: BOOL:[ " +pBool + "<<<<\n");
    }
    
    public static void LogNewLine( int pNum ) {
        string theStr = "\n";
        for (int i=0; i<pNum; i++) {
            if (Application.platform == RuntimePlatform.OSXEditor)
                Debug.Log( theStr);
        }
    }
    
    public static void LogUiBeginsEnds (  ) {
        LogNewLine(10);
    }
    
    public static void LogIntenseWord ( string pWord ) {
        LogNewLine(3);
        Ag.SignIntenseLog();Ag.SignIntenseLog();
        Debug.Log ("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM>>>>>   " + pWord + "   <<<<<MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM \n");
        Ag.SignIntenseLog();Ag.SignIntenseLog();
        LogNewLine(3);
    }
 
    public static void LogNewScene ( string pSceneName, string pFuncName ) {
        if ( pFuncName == "Start") {
            Ag.LogIntense(5, true);
            Debug.Log( " Scene is Loaded >>>>>>>>>>>>>>>>>>>>>  {Scene :: " + pSceneName +  " STARTed }  ~~~~~~~~~~~~~~~~~~~~~~~~~  \n");
            Ag.LogIntense(3, false);
        }
    }
    
    
    
    public static void LogIntense ( int pNum, bool pIsStart) {
        if (pIsStart)     LogNewLine( pNum );
        Ag.SignIntenseLog();
        if (!pIsStart)     LogNewLine( pNum );
    }
    
    public static void LogLineIntense ( string pTheLine) {
        Ag.LogIntense(3, true);
        Ag.LogString(pTheLine);
        Ag.LogIntense(3, false);
    }

    
}
