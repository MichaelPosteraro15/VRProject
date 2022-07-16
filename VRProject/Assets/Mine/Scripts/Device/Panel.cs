using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : DeviceWithScreen
{
    [SerializeField] private GameObject doors;

    // Update is called once per frame
    protected override void Operation()
    {
        if(screen.getPassword() == password){
            screen.setStatus("OK");

            Doors doorsScript = doors.GetComponent<Doors>();
            doorsScript.enabled = true;
        }
    }
}
