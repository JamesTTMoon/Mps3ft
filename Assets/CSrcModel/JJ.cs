using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;


public enum Venture
{
    NONE,
    ONE,
    TWO
}

public enum Godirum
{
    PLU,
    MIN,
    MUL,
    DIV,
    NO
}

public class VecRot
{
    public Vector3 Ae, Kugi, Dora;

    public VecRot(float x, float y, float z, float rx, float ry, float rz)
    {
        SetPosiRot (x, y, z, rx, ry, rz);
    }

    void SetPosiRot(float x, float y, float z, float rx, float ry, float rz)
    {
        Ae = new Vector3 (x, y, z);
        Dora = new Vector3 (rx, ry, rz);
    }

    public VecRot(float x, float y, float z, float rx, float ry, float rz, float kx, float ky, float kz)
    {
        SetPosiRot (x, y, z, rx, ry, rz);
        Kugi = new Vector3 (kz, ky, kz);
    }

    public void SetOriginAe(float x, float y, float z)
    {
        Ae = new Vector3 (x, y, z);
    }

    public void ApplyVector(float? pX, float? pY, float? pZ)
    {
        Vector3 rVec = Ae;
        if (pX != null)
            rVec.x += pX.Value;
        if (pY != null)
            rVec.y += pY.Value;
        if (pZ != null)
            rVec.z += pZ.Value;
        (" NewVec : " + rVec.ToString () + "  Ae : " + Ae.ToString ()).HtLog ();
        Ae = rVec;
    }


}



//  ////////////////////////////////////////////////     ////////////////////////     >>>>>  # JJ :  전역 자료형.  <<<<<
public class JJ
{
    public static float mgWidthOfFriend = 3.1f;

    public static Godirum mgGod;


    public static List<List<VecRot>> arrJinsimAe = new List<List<VecRot>>();

    public static void Init()
    { 
        List<VecRot> friendList = new List<VecRot> ();

        float kugi = 0.9f;

        // Young
        arrJinsimAe.Add (friendList); // No Object

        // Oney
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot(0.00f, 2.00f, 0, 0, 0, 0));
        arrJinsimAe.Add (friendList);

        // Twoer
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot (-0.80f, 3.15f, 0, 0, 0, -45, kugi, kugi, kugi));// 45));
        friendList.Add (new VecRot (-0.80f, 1.65f, 0, 0, 0, 45, kugi, kugi, kugi));//-45));
        arrJinsimAe.Add (friendList);

        // Threen
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot (1, 3, 0, 0, 0, 30));
        friendList.Add (new VecRot (1, 3, 0, 0, 0, -30));
        friendList.Add (new VecRot (1, 3, 0, 0, 0, 90));
        arrJinsimAe.Add (friendList);
        
        
        
        // Fouram
        friendList = new List<VecRot>();
        friendList.Add (new VecRot (1, 3, 0, 0, 0, 30));
        friendList.Add (new VecRot (1, 3, 0, 0, 0, -30));
        friendList.Add (new VecRot (1, 3, 0, 0, 0, 90));
        friendList.Add (new VecRot (1, 3, 0, 0, 0, 90));
        arrJinsimAe.Add (friendList);
        

    }


}
