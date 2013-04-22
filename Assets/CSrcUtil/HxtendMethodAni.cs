using UnityEngine;
using System.Collections;

public static class HmExtendMethodAnimation
{
	
	
	//  ////////////////////////////////////////////////     ////////////////////////     this is >>>   Go To .. start ani..   <<<  related ...
	public static Vector3 MoveXYZ(this Vector3 pFrom, float pX, float pY, float pZ)
	{
		return new Vector3 (pFrom.x + pX, pFrom.y + pY, pFrom.z + pZ);
	}
	
	public static Vector3 Go2Target(this Vector3 pCur, Vector3 pTo, float pDist)
	{
		Vector3 directV = pCur.DirectVect (pTo);    // Direction ..
		directV = directV.UnitVect ();              // make it Unit Vector..
		return directV.ApplyLength(pDist);          // Apply Distance ...
	}
	
	
	//  ////////////////////////////////////////////////     ////////////////////////     this is >>>   Internal Divide   <<<  related ...
	public static Vector2 IntDivide(this Vector2 pFrObj, Vector2 pToObj, float pFr, float pTo) 
	{
		//("x " + (pFr * pFrObj.x + pTo * pToObj.x) / (pFr + pTo) + " , Y scale  " + (pFr * pFrObj.y + pTo * pToObj.y) / (pFr + pTo)).HtLog();
		return new Vector2( (pFr * pFrObj.x + pTo * pToObj.x) / (pFr + pTo), (pFr * pFrObj.y + pTo * pToObj.y) / (pFr + pTo) );
	}
	
	public static float IntDivide(this float pFromVal, float pToVal, float pFr, float pTo)
	{
		if (pFr + pTo == 0)
			return 0;
		return (pFr * pFromVal + pTo * pToVal) / (pFr + pTo);
	}
	
	public static Vector3 IntDivide(this Vector3 pFrObj, Vector3 pToObj, float pFr, float pTo) 
	{
		//("x " + (pFr * pFrObj.x + pTo * pToObj.x) / (pFr + pTo) + " , Y scale  " + (pFr * pFrObj.y + pTo * pToObj.y) / (pFr + pTo)).HtLog();
		return new Vector3( (pFr * pFrObj.x + pTo * pToObj.x) / (pFr + pTo), 
		                   (pFr * pFrObj.y + pTo * pToObj.y) / (pFr + pTo), 
		                   (pFr * pFrObj.z + pTo * pToObj.z) / (pFr + pTo) );
	}
	
	public static Vector3 IntDivideXY(this Vector3 pFrObj, Vector3 pToObj, float pFr, float pTo) 
	{
		//("x " + (pFr * pFrObj.x + pTo * pToObj.x) / (pFr + pTo) + " , Y scale  " + (pFr * pFrObj.y + pTo * pToObj.y) / (pFr + pTo)).HtLog();
		return new Vector3( (pFr * pFrObj.x + pTo * pToObj.x) / (pFr + pTo), 
		                   (pFr * pFrObj.y + pTo * pToObj.y) / (pFr + pTo),      pFrObj.z );
	}
	
}