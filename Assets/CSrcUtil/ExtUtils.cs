using UnityEngine;
using System.Collections;

public static class ExtUtils
{
    public static int GetBigger(this int pThis, int pThat)
    {
        if (pThis > pThat)
            return pThis;
        return pThat;
    }
 
	public static int GetRandomChant(this System.Random rand, int pGrade, int pMax)
	{
		if (pMax == 0)
			return 0;
		
		if (pGrade == 1)
			return 1;
		
		float numm = AgUtil.RandomInclude (1, 1000);  //rand.Next (1, 1000);
		
		// more (Lower Chant value) .. less (high value)
		int mult = 100, divN = 50 + (10 - pGrade) * 4, divX = mult + (10 - pGrade) * 4;
		
		for (int k=0; k<3; k++) {
			numm *= rand.Next (50, mult);
			numm /= rand.Next (divN, divX);
		}
		
		int rlt = (int)( numm * pMax / 1000 ) + 1;
		if (rlt > pMax)
			return pMax;
		
		//numm.ToString ().HtLog ();
		return rlt;
	}
	
	public static bool GetRandomTrue(this System.Random rand, int pTruePercent)  // 0 ~ 100
	{
		int numm = AgUtil.RandomInclude (0, 99); //  rand.Next (0, 100);
		
		//("Get Random True ::  " + numm).HtLog ();
		
		if (numm < pTruePercent)
			return true;
		return false;
	}


    
}
