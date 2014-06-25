﻿using UnityEngine;
using System.Collections;

public class PlayerControl05 : MonoBehaviour
{

    // Use this for initialization
    public int pX = 0;
    public int pY = 0;
    int xmax = GlobalLogic02.wX;
    int ymax = GlobalLogic02.wY;
    void Start()
    {
        GlobalLogic02.loadWindow();
    }
    void Update()
    {
        transform.position = GlobalLogic02.window [pX, pY].transform.position+new Vector3(0,0,-4);
        GlobalLogic02.curX = pX;
        GlobalLogic02.curY = pY;        
    }

    void OnGUI()
    {
        if ((pY < ymax - 1))
        { 
            if (Event.current.Equals(Event.KeyboardEvent("w"))&&GlobalLogic02.passT[pX,pY+1])
            {                
                pY++;
            }             
        }
        if (pY > 0)
        {
            if (Event.current.Equals(Event.KeyboardEvent("s"))&&GlobalLogic02.passT[pX,pY-1])
            {                
                pY--;
            }            
        }
        if ((pX > 0))
        {      
            if (Event.current.Equals(Event.KeyboardEvent("a"))&&GlobalLogic02.passT[pX-1,pY])
            {                
                pX--;
            }            
        }
        if ((pX < xmax - 1))
        {
            if (Event.current.Equals(Event.KeyboardEvent("d"))&&GlobalLogic02.passT[pX+1,pY])
            {                
                pX++;
            }
        }        
    }
}
