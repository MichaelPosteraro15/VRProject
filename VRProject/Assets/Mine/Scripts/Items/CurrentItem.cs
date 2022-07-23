using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItem 
{
    private string currentItem = "Empty";

    private bool crowOk = false;
    private bool gunOk = false; 
    private int bullets=0;
   



    private CurrentItem() { }
    private static CurrentItem instance = null;
    public static CurrentItem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CurrentItem();
            }
            return instance;
        }
    }
    
    public void setCurrentItem(string item)
    {
        this.currentItem = item;

    }

    public string getCurrentItem() {
        return this.currentItem;
    }

    public bool  isCrow()
    {
        return this.crowOk;
    }

    public bool isgunOk()
    {
        return this.gunOk;
    }

    public int  getNumbullets()
    {
        return this.bullets;
    }

    public void setIsCrow(bool value)
    {
         this.crowOk=value;
    }

    public void setIsGun(bool value)
    {
        this.gunOk = value;
    }
    public void setNumbullets(int value)
    {
         this.bullets=value;
    }
}
