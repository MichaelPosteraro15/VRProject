using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i managers sono richiesti obligatoriamente
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(AudioManager))]

public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static AudioManager Audio { get; private set; }

    private List<IGameManager> _startSequence;

    //awake è un metodo fornito da MonoBehaviour, eseguito ancor prima di start
    //awake avvia tutti i manager e li aggiunge alla lista(IGameManager) e le courotine
    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        Audio = GetComponent<AudioManager>();
        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);
        _startSequence.Add(Audio);  

        StartCoroutine(StartupManagers());
    }

    //courotine che starta tutti i manager passatogli
    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }
        yield return null;
        int numModules = _startSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModules);
            }
            yield return null;
        }
        Debug.Log("All managers started up");
    }

}
