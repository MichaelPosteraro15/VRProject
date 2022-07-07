using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Server : DeviceWithScreen
{
    protected override void Operation()
    {
        if(screen.getPassword() == password){
            screen.setStatus("OK");
        }
    }
}
