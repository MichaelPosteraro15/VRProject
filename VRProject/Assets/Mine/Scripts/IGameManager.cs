using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interfaccia che faremo ereditare a InventoryManager e playerManager
public interface IGameManager
{
    ManagerStatus status { get; }

    //inizializzazione del manager
    public void Startup();
}
