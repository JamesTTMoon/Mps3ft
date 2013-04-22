using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class GeneralFunction {

    [DllImport ("__Internal")] private static extern void _NativeLog (string pString);

    public static string SIGN_INTENSE = 
        "SIGN_INTENSE >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> \n";
 
    public static void SignIntenseLog( int pNum ) {
        for (int i=0; i<pNum; i++)
            GeneralFunction.NativeLog(SIGN_INTENSE);
    }
    
    public static void LogIntense ( int pNum, bool pIsStart, string pName) {
        if (pIsStart)     SignIntenseLog( pNum );
        GeneralFunction.NativeLog(">>>>>>>>>>>>>>>>>>>>>>>>>>>  >>>>>>>>>>>>>>>>>>>>>>>>>>>   " + pName);
        if (!pIsStart)     SignIntenseLog( pNum );
    }
    
    public static void NativeLog(string pString)
    {
     // Call plugin only when running on real device
     if (Application.platform != RuntimePlatform.OSXEditor)
         _NativeLog(pString);
    }
 
}