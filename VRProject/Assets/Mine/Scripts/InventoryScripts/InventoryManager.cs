using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    //mappa in cui mettiamo gli oggetti che abbiamo associando loro la quantita 
    private Dictionary<string, int> _items;
    
    //inizializzazione inventario
    public void Startup()
    {
        Debug.Log("Inventory manager starting...");
        _items = new Dictionary<string, int>();
        status = ManagerStatus.Started;
    }


    private void DisplayItems()
    {
        string itemDisplay = "List of Items: ";
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value + ") ";
        }
        Debug.Log(itemDisplay);
    }

    //aggiungiamo oggetto al nostro inventario
    public void AddItem(string name)
    {
        //se l'elemente è gia presente nell'inventario semplicemente aggiungiamo una quantità
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {   //se non è presente lo inseriamo e poniamo la sua quantita =1
            _items[name] = 1;
        }

        if (name == "crowbar")
        {
            CurrentItem.Instance.setIsCrow(true);

        }
        else if (name == "gun")
        {
            CurrentItem.Instance.setIsGun(true);

        }
        else if (name == "bullets")
        {
            CurrentItem.Instance.setNumbullets(20);

        }



        DisplayItems();
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }


    public int GetItemCount(string name)
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }


    //ovviamente quando consumiamo un elemento la quantità diminusce 
    public void ConsumeItem(string name)
    {
        if (_items.ContainsKey(name))
        {
            _items[name]--;
            if (_items[name] == 0)
            {   //se la quantità è 0 allora rimuoviamo l'oggetto dall'inventario
                _items.Remove(name);
            }
        }
        else
        {
            Debug.Log("cannot consume " + name);
        }
        DisplayItems();
    }

}