using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

public enum Fff
{
    YOUNG,
    ONEY,
    TWOER,
    THREEN,
    FOURAM,
    FIVING, 
    SIXOO,
    SEVENBA,
    EIGHTUM,
    NINENONE,
    TEN,

}

public enum Godirum
{
    PLU,
    MIN,
    MUL,
    DIV,
    NO
}


//  ////////////////////////////////////////////////     ////////////////////////     >>>>>  # JJ :  전역 자료형.  <<<<<
public class JJ
{
    public static float mgWidthOfFriend = 3.1f;
    //public static Godirum mgGod;

    public static List<List<VecRot>> arrJinsimAe = null;
    public static List<List<VecRot>> arrEyeAe = null;

    public static Dictionary<string, VecRot> dicVar = new Dictionary<string, VecRot>();

    static void SetEyeAe()
    {
        arrEyeAe = new List<List<VecRot>> ();
        List<VecRot> eyeList = new List<VecRot> ();

        // Young
        arrEyeAe.Add (eyeList); // No Object

        // Oney
        float kugi = 1.0f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot(0.00f, 6.00f, 0,     0, 0, 0,    kugi, kugi, kugi, "EyeSingle"));
        arrEyeAe.Add (eyeList);

        // Twoer
        kugi = 0.5f;
        float xP = 1.2f, yP = 5f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0, 0,0,0, kugi, kugi, kugi, "EyeSingle"));
        eyeList.Add (new VecRot ( xP, yP, 0, 0,0,0, kugi, kugi, kugi, "EyeSingle"));
        arrEyeAe.Add (eyeList);

        // Threen
        eyeList = new List<VecRot> ();
        yP = 5f;
        eyeList.Add (new VecRot (-xP, yP, 0,      0,0,0, kugi, kugi, kugi, "EyeSingle"));
        eyeList.Add (new VecRot ( xP, yP, 0,      0,0,0, kugi, kugi, kugi, "EyeSingle"));
        eyeList.Add (new VecRot (  0,yP + 0.8f,0, 0,0,0, kugi, kugi, kugi, "EyeSingle"));
        arrEyeAe.Add (eyeList);

        // Fouram
        kugi = 0.5f;
        yP = 6f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0, 0,0,0, kugi, kugi, kugi, "EyeDouble"));
        eyeList.Add (new VecRot ( xP, yP, 0, 0,0,0, kugi, kugi, kugi, "EyeDouble"));
        arrEyeAe.Add (eyeList);

        // Fiving
        kugi = 0.4f;
        xP = 1.35f;
        yP = 5.5f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeDouble"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeDouble"));
        eyeList.Add (new VecRot ( 0,yP+0.7f, 0, 0,0,0, kugi, kugi, kugi, "EyeSingle"));
        arrEyeAe.Add (eyeList);

        // Sixoo
        kugi = 0.5f;
        xP = 1.35f;
        yP = 6.5f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        arrEyeAe.Add (eyeList);

        // Sevenba  
        kugi = 0.5f;
        yP = 6.3f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( 0,yP+0.7f, 0, 0,0,0, kugi, kugi, kugi, "EyeSingle"));
        arrEyeAe.Add (eyeList);

        // Eightum
        kugi = 0.53f;
        yP = 6.1f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( 0,yP+0.7f, 0, 0,0,0, kugi, kugi, kugi, "EyeDouble"));
        arrEyeAe.Add (eyeList);

        // Ninenone
        kugi = 0.5f;
        xP = 1.8f;
        yP = 5f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( 0,yP+1.5f, 0, 0,0,0, kugi, kugi, kugi, "EyeTriple"));
        arrEyeAe.Add (eyeList);

        // Tens
        kugi = 0.5f;
        xP = 1.8f;
        yP = 5f;
        eyeList = new List<VecRot> ();
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeTriple"));
        xP -= 0.5f;
        yP += 1.3f;
        eyeList.Add (new VecRot (-xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeDouble"));
        eyeList.Add (new VecRot ( xP, yP, 0,    0,0,0, kugi, kugi, kugi, "EyeDouble"));
        arrEyeAe.Add (eyeList);
    }


    public static void Init()
    { 
        //if (arrJinsimAe != null) // 두번 실행시키지 않음.
          //  return;

        SetEyeAe ();
        SetDicVar ();

        arrJinsimAe = new List<List<VecRot>>();
        List<VecRot> friendList = new List<VecRot> ();

        // Young
        arrJinsimAe.Add (friendList); // No Object

        // Oney
        float kugi = 0.8f; //1.0f;
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot(0.00f, 0.20f, 0,     0, 0, 0,  kugi, kugi, kugi));  //kugi*0.7f, kugi*3, kugi*0.7f));
        arrJinsimAe.Add (friendList);

        // Twoer
        kugi = 0.6f;
        float xP = 0.1f;
        friendList = new List<VecRot> ();
        //friendList.Add (new VecRot (-xP, 2.22f, 0,  0, 0, -45, kugi, kugi, kugi));
        friendList.Add (new VecRot (-2+xP,      2f, 0,  0, 0, -45, kugi, kugi, kugi));
        friendList.Add (new VecRot ( 0.1f+xP, 0.7f, 0,  0, 0,  45, kugi, kugi, kugi));
        arrJinsimAe.Add (friendList);

        // Threen
        kugi = 0.5f;
        xP = 0f;
        float yP = 0.5f;
        float zKuki = 1.8f;
        float xDiff = 2.2f;
        friendList = new List<VecRot> ();  // -2.1  +2.1
        friendList.Add (new VecRot (xP - xDiff,  yP, 0,      0, 0, -30,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff,  yP, 0,      0, 0, 30,   kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (2.3f, 0.6f, 0, 0, 0, 90,   kugi, kugi*zKuki, kugi));
        arrJinsimAe.Add (friendList);

        // Fouram
        kugi = 0.4f;
        zKuki = 1.8f;
        xP = -1.1f;
        friendList = new List<VecRot>();
        float nopiA = 1.55f, nopiB = 1.1f;
        xDiff = 1.3f;
        friendList.Add (new VecRot (xP - xDiff,   nopiA+nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff,   nopiA-nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        xP += 2.2f;
        friendList.Add (new VecRot (xP + xDiff,   nopiA+nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP - xDiff,   nopiA-nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        arrJinsimAe.Add (friendList);

        // Fiving
        kugi = 0.3f;
        zKuki = 2.2f;
        xDiff = 1.2f;
        nopiA = 1.3f;
        nopiB = 0.95f;
        xP = -0.5f;
        friendList = new List<VecRot>();
        friendList.Add (new VecRot (xP - xDiff,   nopiA+nopiB,  0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff,   nopiA-nopiB,  0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        xP += 1.0f;
        friendList.Add (new VecRot (xP + xDiff,   nopiA+nopiB,  0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP - xDiff,   nopiA-nopiB,  0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (2.3f, 2.5f,                 0, 0, 0,  90, kugi, kugi*zKuki*1.4f, kugi));
        arrJinsimAe.Add (friendList);

        // Sixoo
        kugi = 0.25f;
        zKuki = 3.0f;
        xP = -1.1f;
        xDiff = 1.32f;
        nopiA = 1.85f;
        nopiB = 1.34f;
        friendList = new List<VecRot>();
        friendList.Add (new VecRot (xP - xDiff,   nopiA+nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff,   nopiA-nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        xP += 2.3f;
        friendList.Add (new VecRot (xP + xDiff,   nopiA+nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP - xDiff,   nopiA-nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (2.0f, 3.9f,                 0, 0, 0,  94, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (2.0f, 3.0f,                 0, 0, 0,  89, kugi, kugi*zKuki, kugi));
        arrJinsimAe.Add (friendList);

        // Sevenba
        zKuki = 2.5f;
        xP = -1.0f;
        xDiff = 1.13f;
        nopiA = 2.1f;
        nopiB = 1.55f;
        friendList = new List<VecRot>();
        friendList.Add (new VecRot (xP - xDiff, nopiA+nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff, nopiA-nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        xP += 1.95f;
        friendList.Add (new VecRot (xP + xDiff, nopiA+nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP - xDiff, nopiA-nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (1.9f,       nopiA+ 1.8f, 0, 0, 0,  90, kugi, kugi*zKuki*1.2f, kugi));
        friendList.Add (new VecRot (1.9f,       nopiA+ 0.6f, 0, 0, 0,  90, kugi, kugi*zKuki*1.2f, kugi));
        friendList.Add (new VecRot (0.0f,      nopiA+ 0.7f, 0, 0, 0,   0, kugi, kugi*0.8f, kugi));
        arrJinsimAe.Add (friendList);

        // Eightum
        kugi = 0.2f;
        zKuki = 1.6f;
        xP = -0.47f;
        xDiff = 0.59f;
        nopiA = 3.57f;
        nopiB = 0.58f;
        friendList = new List<VecRot>();
        friendList.Add (new VecRot (xP - xDiff,   nopiA+nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff,   nopiA-nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        xP += 0.92f;
        friendList.Add (new VecRot (xP + xDiff,   nopiA+nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP - xDiff,   nopiA-nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        xP = -0.47f;
        nopiA = 1.0f;
        friendList.Add (new VecRot (xP - xDiff,   nopiA+nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP + xDiff,   nopiA-nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        xP += 0.92f;
        friendList.Add (new VecRot (xP + xDiff,   nopiA+nopiB, 0, 0, 0,  45, kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot (xP - xDiff,   nopiA-nopiB, 0, 0, 0, -45, kugi, kugi*zKuki, kugi));
        arrJinsimAe.Add (friendList);

        // Ninenone
        kugi = 0.2f;
        zKuki = 2.2f;
        xP = 1.1f; 
        float xCe = 0, xA = 1.1f, yCe = 3.25f, yA = 0.05f;
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot ( xCe - xP,  yCe, 0,     0, 0, -30,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe + xP,  yCe, 0,     0, 0, 30,   kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe + xA, yCe- yA, 0,  0, 0, 90,   kugi, kugi*zKuki, kugi));
        xCe = 1.57f; yCe = 0.6f;
        friendList.Add (new VecRot ( xCe - xP,  yCe, 0,     0, 0, -30,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe + xP,  yCe, 0,     0, 0, 30,   kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe + xA, yCe- yA, 0,  0, 0, 90,   kugi, kugi*zKuki, kugi));
        xCe *= -1;
        friendList.Add (new VecRot ( xCe - xP,  yCe, 0,     0, 0, -30,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe + xP,  yCe, 0,     0, 0, 30,   kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe + xA, yCe- yA, 0,  0, 0, 90,   kugi, kugi*zKuki, kugi));
        arrJinsimAe.Add (friendList);

        // Ten .. 
        kugi = 0.3f;
        zKuki = 1.8f;
        yA = 1f;
        xCe = -2;
        yCe = 3f;
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot ( xCe,  yCe + 2.3f*yA, 0,  0, 0, 70,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe + 1*yA, 0,  0, 0, 90,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe,        0,  0, 0, 90,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe - 1*yA, 0,  0, 0, 90,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe - 2.3f*yA, 0,  0, 0,110,  kugi, kugi*zKuki, kugi));
        xCe *= -1;
        friendList.Add (new VecRot ( xCe,  yCe + 3.1f*yA, 0,  0, 0,110,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe + 1*yA, 0,  0, 0, 90,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe,        0,  0, 0, 90,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe - 1*yA, 0,  0, 0, 90,  kugi, kugi*zKuki, kugi));
        friendList.Add (new VecRot ( xCe,  yCe - 3.1f*yA, 0,  0, 0, 70,  kugi, kugi*zKuki, kugi));
        arrJinsimAe.Add (friendList);

    }

    static void SetDicVar () 
    {
        dicVar = new Dictionary<string, VecRot>();

        dicVar.Add("Single_A_fromDouble", new VecRot ( -0.4f,0, 0,   0, 0, 0, 1, 1, 1, "EyeSingle"));
        dicVar.Add("Single_B_fromDouble", new VecRot (  0.4f,0, 0,   0, 0, 0, 1, 1, 1, "EyeSingle"));

        dicVar.Add("Single_A_fromTriple", new VecRot ( -0.4f,0, 0,   0, 0, 0, 1, 1, 1, "EyeSingle"));
        dicVar.Add("Single_B_fromTriple", new VecRot (  0.4f,0, 0,   0, 0, 0, 1, 1, 1, "EyeSingle"));
        dicVar.Add("Single_C_fromTriple", new VecRot (  0,0.5f, 0,   0, 0, 0, 1, 1, 1, "EyeSingle"));

    }

}
