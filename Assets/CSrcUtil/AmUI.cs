// VER_7_62_MOON 
// [2013:1:9:MOON] Set Column Add
using UnityEngine;
using System.Collections;

public class AmUI {
    
    Rect mErrorRect;
    public ArrayList arrPosiRect, arrMsgStr;
    
    float mSizeStep, mSpace; // 0 ~ 1.0 .. Ratio..
    
    public AmUI ( int pCol, int pRow ) {
        
        SetColumns(pCol, pRow);
    }
    
    public void SetColumns(int pCol, int pRow) {  // [2013:1:9:MOON] Set Column Add
        float posX, posY, wid, hei, distX, distY, spaX, spaY;
        distX = Ag.mgScrX / pCol; distY = Ag.mgScrY / pRow;
        spaX = distX * 0.2f; spaY = distY * 0.2f;
        wid = distX - spaX;
        hei = distY - spaY;
        
        arrPosiRect = new ArrayList();
        for ( int jj = 0; jj < pCol; jj++) {
            ArrayList aMem = new ArrayList();
            arrPosiRect.Add(aMem);
            posX = spaX/2 + distX * jj;
            posY = spaY/2;
            for ( int k=0; k<pRow; k++) {
                Rect aRec = new Rect( posX, posY, wid, hei );
                aMem.Add(aRec);
                posY += distY;
                //Ag.LogString( "posY " + posY );
            }
        }
        
    }
    
    public AmUI (  ) { // Separate Buttons...
        arrPosiRect = new ArrayList();
        arrMsgStr = new ArrayList();
    }
    
    public void AddAlertMsg( string pMsg ) {
        arrPosiRect.Add ( new Rect( Ag.mgScrX * 0.1f, Ag.mgScrY * 0.1f, Ag.mgScrX * 0.8f, Ag.mgScrY * 0.8f  ));
        arrMsgStr.Add (pMsg);
    }
    
    public string GetMsg ( int pIdx ) {
        if (pIdx < arrMsgStr.Count) return (string)arrMsgStr[pIdx];
        else return "";
    }
    
    public Rect GetRect ( int pIdx ) {
        return (Rect)(arrPosiRect[pIdx]) ;
    }
    
    public Rect GetRectFullWidth ( int pRowIdx ) {
        Rect Left = (Rect)(((ArrayList)arrPosiRect[0] ) [pRowIdx] ) ;
        return new Rect ( Left.x, Left.y, Ag.mgScrX- 2*Left.x, Left.height );
    }
    
    public Rect GetRect( int pColIdx, int pRowIdx) {
        //Ag.LogString("GetRect :: " + pColIdx +", " + pRowIdx + ", " + arrPosiRect.Count);
        if (pColIdx-1 > arrPosiRect.Count || arrPosiRect.Count == 0) 
            return ErrorRect();
        //Ag.LogString(":: if  " + (pRowIdx-1) + " > " + "Rect[pColIdx].count");
        if (pRowIdx-1 > ((ArrayList)arrPosiRect[pColIdx]).Count )
            return ErrorRect();
        return (Rect)(((ArrayList)arrPosiRect[pColIdx] ) [pRowIdx] ) ;
    }
    
    public Rect ErrorRect() {

        if (Ag.mgScrX > 400 && Ag.mgScrY > 200)
            mErrorRect = new Rect(10f, 10f, Ag.mgScrX*0.3f, Ag.mgScrY*0.2f);
        else
            mErrorRect = new Rect(10f, 10f, 200f, 50f);
        return mErrorRect;
    }
    
    
    public Rect DivideRect( Rect pOri, int pDivideNum, int pNum ) {
        if (pDivideNum == 0) return new Rect(50, 50, 50, 50);
        
        //float xSta = pOri.x, xEnd = pOri.x + pOri.width;
        float wid = pOri.width / pDivideNum;
        
        return new Rect( pOri.x + pNum*wid, pOri.y, wid, pOri.height );
    }
    
    
    //public void AddMember ( int pIdx, int pNum, float pXsize, float //pYsize ) {
        
        
        
    //}
    
    

}
