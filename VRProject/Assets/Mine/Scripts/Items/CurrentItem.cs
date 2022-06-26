using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItem 
{
    private string currentItem = "Empty";

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
}
