using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //nome dell'oggetto
    [SerializeField] private string itemName;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            //prendiamo l'oggetto
            Debug.Log("Item collected");
            //aggiungiamo l'elemento nell'inventario
            Managers.Inventory.AddItem(itemName);

            //e poi lo distruggiamo per simulare che è stato preso
            Destroy(this.gameObject);
        }

    }

   

}
