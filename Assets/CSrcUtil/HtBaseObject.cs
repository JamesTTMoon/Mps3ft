using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

//  ////////////////////////////////////////////////     ////////////////////////     >>>>>  Resource Load Manager  <<<<<
public class HtRsrcMan
{
    string mScnName { get; set; }
    
    public HtRsrcMan (string pFolder)
    {
        mScnName = pFolder;
        //("HtRscrMan Creation :: of " + mScnName).HtLog ();
    }
    
    public Texture2D GetTexture (string pTxtName)
    {
        try {
            return (Texture2D)Resources.Load (mScnName + "/" + pTxtName);
        } catch {
            // Exception .... 
            Ag.LogIntenseWord ("Error.LOAD_TEXTURE");
            //AgStt.muiHQ.FatalError(null, Error.LOAD_TEXTURE);
            //AgStt.mError = AgStt.Error.LOAD_TEXTURE;
            return null;
        }
    }

    public void SetInstantComPrefab (string pSubFolder, MpsModel pParent)
    {
        string fullStr = "Com/" + pSubFolder + "/" + pParent.mName;

        try {
            ("HtRsrcMan  :: SetInstantComPrefab   >>  pSubFolder is " + fullStr).HtLog();

            pParent.mGobj = (GameObject)MonoBehaviour.Instantiate (Resources.Load (fullStr));
            pParent.mGobj.name = pParent.mName;
            pParent.mGobj.transform.position = pParent.manInitAe;
            pParent.mGobj.transform.Rotate (pParent.manDora);
        } catch {
            // Exception .... 

            Ag.LogIntenseWord ("Error.GetComPrefab at >> " + fullStr);
            //AgStt.muiHQ.FatalError(null, Error.LOAD_TEXTURE);
        }
    }

    public GameObject GetJinsim()
    {
        string fullStr = "Com/" + "Friends" + "/Jinsim";
        try {
            return (GameObject)MonoBehaviour.Instantiate (Resources.Load (fullStr));

        } catch {
            // Exception .... 
            Ag.LogIntenseWord ("Error  at >> " + " GetJinsim " );
            //AgStt.muiHQ.FatalError(null, Error.LOAD_TEXTURE);
        }
        return null;
    }



    public GameObject GetComPrefab (string pSubFolder, string pName)
    {
        string fullStr = "Com/" + pSubFolder + "/" + pName;
        try {
            //Ag.LogString(mScnName + "/Prefab/" + pName);
            return (GameObject)MonoBehaviour.Instantiate (Resources.Load (fullStr));
        } catch {
            // Exception .... 
            Ag.LogIntenseWord ("Error.GetComPrefab" + fullStr);
            //AgStt.muiHQ.FatalError(null, Error.LOAD_TEXTURE);
            return null;
        }
    }
    
    public GameObject GetPrefab (string pName)
    {
        string fullStr = mScnName + "/Prefab/" + pName;
        try {
            Ag.LogString (mScnName + "/Prefab/" + pName);
            return (GameObject)MonoBehaviour.Instantiate (Resources.Load (fullStr));
        } catch {
            // Exception .... 
            Ag.LogIntenseWord ("Error.GetPrefab" + fullStr);
            //AgStt.muiHQ.FatalError(null, Error.LOAD_TEXTURE);
            return null;
        }
    }
}



//  ////////////////////////////////////////////////     ////////////////////////     >>>>>  Base Game Object  <<<<<
public class BaseObject : MonoBehaviour
{
    public GameObject mObj;
    public string myName, mFolder; // mFolder + "/" + theFolder + myName.... 
    public Dictionary<string, string> dicResourcesFold = new Dictionary<string, string> (); // folders of Main, Texture, GameObject, Animation
        
    public BaseObject ()
    {

    }
    
    public BaseObject (string pFolder, string pName, string pGameObjFolder)
    {
        mFolder = pFolder;
        myName = pName;
        dicResourcesFold.Add ("GameObj", pGameObjFolder);
        
        SetGameObj ();
    }
    
    //  ////////////////////////////////////////////////     Set Folders
    public void SetFolder (string pKey, string pTextureName)
    {
        if (dicResourcesFold.ContainsKey (pKey))
            return;
        dicResourcesFold.Add (pKey, pTextureName);
    }
    
    public void SetGameObj ()
    {
        string fullName;
        try {
            fullName = mFolder + "/" + dicResourcesFold ["GameObj"] + "/" + myName;
            mObj = (GameObject)Resources.Load (fullName);
        } catch {
        }
    }
    
    //  ////////////////////////////////////////////////     Get Methods
    public string GetFolder (string pKey)
    {
        return mFolder + "/" + dicResourcesFold [pKey];
    }
    
    public void AssignTexture ()
    { 
        try {
            string fullName = mFolder + "/" + dicResourcesFold ["Texture"] + "/" + myName;
            Debug.Log ("AssignTexture    .....   fullName :: " + fullName);
            mObj.renderer.material.mainTexture = (Texture2D)Resources.Load (fullName);
        } catch {
        }
    }
    
    public void AssignTexture (string pKey, string pLastName, int pMtrsIdx)
    { 
        try {
            string fullName = mFolder + "/" + dicResourcesFold [pKey] + pLastName;
            Debug.Log ("AssignTexture with Key / LastName / MaterialIndex fullName :: " + fullName);
            mObj.renderer.materials [pMtrsIdx].mainTexture = (Texture2D)Resources.Load (fullName);
        } catch {
        }
    }
    
}


//  ////////////////////////////////////////////////     ////////////////////////     >>>>>  General Game Object  <<<<<
public class HtGameObj : BaseObject
{ 
    
    public List<GameObject> arrGameObj;
    
    public HtGameObj () : base()
    {
        arrGameObj = new List<GameObject> ();
    }
    
    public HtGameObj (string pFolder, string pName, string pGameObjFolder) : base ( pFolder, pName, pGameObjFolder )
    {
        arrGameObj = new List<GameObject> ();
    }
    
    
    //  ////////////////////////////////////////////////     Instantiate
    public void InstantiateAt (float pX, float pY, float pZ)
    {
        arrGameObj.Add ((GameObject)Instantiate (mObj, new Vector3 (pX, pY, pZ), new Quaternion (0, 0, 0, 0)));
    }
    
    
    //  ////////////////////////////////////////////////     Animation Manipulate..
    public void AnimaUpDown ()
    {
        
        
    }
    
    public void IdelAnima ()
    {
        
        Vector3 posi = arrGameObj [0].transform.position;
        posi.y += 0.1f;
        arrGameObj [0].transform.position = posi;
        //mObj.transform.position = posi;
    }
    


}



