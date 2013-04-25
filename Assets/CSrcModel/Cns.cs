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
    public Vector3 TargAe, OrigAe;
    public Vector3 TarRot, OriRot;

    public VecRot(float x, float y, float z, float rx, float ry, float rz)
    {
        OrigAe = new Vector3 (x, y, z);
        OriRot = new Vector3 (rx, ry, rz);
    }

    public void SetOriginAe(float x, float y, float z)
    {
        OrigAe = new Vector3 (x, y, z);
    }

    public void SetTargetAe(float x, float y, float z)
    {
        TargAe = new Vector3 (x, y, z);
    }

}



//  ////////////////////////////////////////////////     ////////////////////////     >>>>>  Resource Load Manager  <<<<<
public class Cns
{
    public static float mgWidthOfFriend = 3.1f;




    public static List<List<VecRot>> arrJinsimAe = new List<List<VecRot>>();

    public static void SetConstants()
    {
        List<VecRot> friendList = new List<VecRot> ();

        // Young
        arrJinsimAe.Add (friendList); // No Object

        // Oney
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot(0.00f, 2.00f, 0, 0, 0, 0));
        arrJinsimAe.Add (friendList);

        // Twoer
        friendList = new List<VecRot> ();
        friendList.Add (new VecRot (0.10f, 2.00f, 0, 0, 0, 0));// 45));
        friendList.Add (new VecRot (0.50f, 0.00f, 0, 0, 0, 0));//-45));
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
