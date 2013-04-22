// [2013:1:8:MOON] Start
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.Linq;

//  ////////////////////////////////////////////////     ////////////////////////     >>>>> String & Debug.... <<<<<
public static class HtExtendMethodStr
{
	
	
	public static void ShowEachChar(this byte[] pByte, string pComment)  // [2013:3:26:MOON] Added..
	{
		Ag.LogIntense (3, true);
		(" >>>>>      HtExtendMethodStr ::  ShowEachChar                 >>>>>>>>>>>>>>>>>>>>>  >>>>>   " + pComment + "   <<<<<") .HtLog ();
		Ag.LogString (pComment);
		
		int ii, num = BitConverter.ToUInt16 (pByte, 12) + 14;
		
		for (ii=0; ii<num; ii++) {
			byte cur;
			cur = pByte [ii];
			string hexOutput = String.Format ("{0:X}", cur);
			//System.Text.Encoding.ASCIIEncoding.GetBytes(x.ToString());
			
			if (ii == 14)
				Ag.LogString("______________________________ Above are Header ______________________________");
			
			Ag.LogString ("Cur byte is:>> \t\t 0x " + hexOutput +  ", \t   at \t ____ " + ii + " \t ____  \t DEC : " + cur + " \t _____      \t" +  ((char)cur).ToString() );
		}
		Ag.LogString ("______________________________ Total Length = " + num + "\n");
		(" >>>>>      HtExtendMethodStr ::  ShowEachChar                 >>>>>>>>>>>>>>>>>>>>>  >>>>>   " + pComment + "   <<<<<") .HtLog ();
		Ag.LogIntense (3, false);
	}
	
	public static void HtLog(this string pStr ) {
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.Android)
			Debug.Log ("LOG >> " + pStr + " \n");
		else
			//GeneralFunction.NativeLog("Ag.LogString  >>>>>>>>>>>>>>>>>>>> [ " + pStr + " ]");
			GeneralFunction.NativeLog("UNITY C# Log :: " + pStr );
	}
	
	//  ////////////////////////////////////////////////     4 Debugging ....
	/*public static void Show(this UiState pObj)
	{
		(" State ...... " + pObj.ToString() ).HtLog();
	} */
	
	public static void Show(this Vector3 pVec)
	{
        pVec.ToString().HtLog();
	}
	
	public static void ShowPosi(this GameObject pObj)
	{
        pObj.transform.position.Show();
	}
	
	public static void ShowPosi(this Transform pObj)
	{
        pObj.position.Show();
	}
	
}
