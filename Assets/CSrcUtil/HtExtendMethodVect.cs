using UnityEngine;
using System.Collections;

public static class HtExtendMethodVect
{
	//  ////////////////////////////////////////////////     ////////////////////////     this is >>>   GameObject   <<<  related ...
	//  ////////////////////////////////////////////////     this is >>>   Transform   <<<  related ...
	public static void MoveBack(this Transform pTarget, float pVal)
	{
		pTarget.position = new Vector3(pTarget.position.x, pTarget.position.y, pTarget.position.z + pVal);
	}
	

    public static void SetScaleFactor(this Transform pTarget, Vector3 pVect)
    {
        Vector3 kugi = pTarget.localScale;
        pTarget.localScale = new Vector3 (kugi.x * pVect.x, kugi.y * pVect.y, kugi.z * pVect.z);
    }


	public static Vector3 GetApplyVect3(this Transform pTarget, Vector3 pVect)
	{
        return new Vector3(pTarget.position.x + pVect.x, pTarget.position.y + pVect.y, pTarget.position.z + pVect.z) ;
	}
	
	public static Vector3 Freeze(this Vector3 pTarget)
	{
		return pTarget;
	}    
	
	public static void MoveXY(this Transform pTarget, float pDisp, bool pIsVertical)
	{
		Vector3 camCo = pTarget.position;
		if (pIsVertical)
			camCo.y += pDisp;
		else
			camCo.x += pDisp;
		pTarget.position = camCo;
	}    
	
	public static void OffsetFront(this Transform pTrans, float pValue)
	{
		Vector3 cur = pTrans.position;
		("Current z  " + cur.z).HtLog();
		pTrans.position = new Vector3(cur.x, cur.y, cur.z - pValue);
	}
	
	//  ////////////////////////////////////////////////     ////////////////////////     this is >>>   GameObject   <<<  related ...
	public static float DiffenceXY(this GameObject pFrom, GameObject pTopo, bool pIsVertical)
	{
		return pFrom.transform.position.DiffenceXY(pTopo.transform.position, pIsVertical);
	}
	
	public static float DistanceXY(this GameObject pFrom, GameObject pTopo, bool pIsVertical)
	{
		return pFrom.transform.position.DistanceXY(pTopo.transform.position, pIsVertical);
	}
	
	public static float CurrentPosition(this GameObject pObj, bool pIsVertical)
	{
		return pObj.transform.position.CurrentPosition(pIsVertical);
	}
	
	
	//  ////////////////////////////////////////////////     ////////////////////////     this is >>>   Vector3   <<<  related ...
	
	
	public static float DiffenceXY(this Vector3 pFrom, Vector3 pTopo, bool pIsVertical)
	{
		if (pIsVertical)
			return pTopo.y - pFrom.y;
		else
			return pTopo.x - pFrom.x;
	}
	
	public static float DistanceXY(this Vector3 pFrom, Vector3 pTopo, bool pIsVertical)
	{
		if (pIsVertical)
			return Mathf.Abs(pTopo.y - pFrom.y);
		else
			return Mathf.Abs(pTopo.x - pFrom.x);
	}
	
	public static float Distance3D(this Vector3 pFrom, Vector3 pTopo)
	{
		return Mathf.Sqrt(Mathf.Abs(pTopo.x - pFrom.x) + Mathf.Abs(pTopo.y - pFrom.y) + Mathf.Abs(pTopo.z - pFrom.z));
	}
	
	public static float CurrentPosition(this Vector3 pVec, bool pIsVertical)
	{
		if (pIsVertical)
			return pVec.y;
		return pVec.x;
	}
	
	public static Vector3 Move(this Vector3 pVec, bool pIsVertical, float pDist)
	{
		if (pIsVertical)
			return new Vector3(pVec.x, pVec.y + pDist, pVec.z);
		return new Vector3(pVec.x + pDist, pVec.y, pVec.z);
	}
	
	public static float AddXYZ(this Vector3 pObj) // Calculate Scale Size...
	{
		return pObj.x + pObj.y + pObj.z;
	}
	
	public static Vector2 Vect2(this Vector3 pObj)
	{
		return new Vector2(pObj.x, pObj.y);
	}
	
	public static Vector3 DirectVect(this Vector3 pFrom, Vector3 pTo) 
	{
		return pTo - pFrom;
	}
	
	public static float LengthOfVector(this Vector3 pVect)
	{
		return Mathf.Sqrt ( Mathf.Pow( pVect.x, 2) + Mathf.Pow( pVect.y, 2) + Mathf.Pow( pVect.z, 2) );
	}
	
	public static Vector3 UnitVect(this Vector3 pVect)
	{
		float ll = pVect.LengthOfVector ();
		if (ll < 0.0001)
			return new Vector3 (0, 0, 0);
		return new Vector3 (pVect.x / ll, pVect.y / ll, pVect.z / ll);
	}
	
	public static Vector3 ApplyLength(this Vector3 pVect, float pDist)
	{
		return new Vector3 (pVect.x * pDist, pVect.y * pDist, pVect.z * pDist);
	}
	
	//  ////////////////////////////////////////////////     ////////////////////////     this is >>>   Vector2   <<<  related ...
	public static Vector3 Vect3(this Vector2 pObj, float pZ = 0)
	{
		return new Vector3(pObj.x, pObj.y, pZ);
	}
	
	
	
	
}