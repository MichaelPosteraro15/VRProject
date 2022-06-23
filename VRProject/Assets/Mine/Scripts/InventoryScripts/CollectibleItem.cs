using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //nome dell'oggetto
    [SerializeField] private string itemName;
    [SerializeField] private bool okAnimation;

    //piccola animazione per gli oggetti che si trovano nell mappa
    private bool anim;



    //quando siamo sull'oggetto
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
           
            Debug.Log("Item collected");
            //aggiungiamo l'elemento nell'inventario
            Managers.Inventory.AddItem(itemName);

            //e poi lo distruggiamo per simulare che è stato preso
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        //avvia la coroutine che anima gli oggetti
        if (okAnimation)
        {
            StartCoroutine(anima());
        }
    }

    private void Update()
    {
        //se true va verso l'alto
        if (anim && okAnimation)
        {
            transform.position = transform.position + new Vector3(0,1*Time.deltaTime,0);

        }
        //se false va verso il basso
        else if(!anim && okAnimation)
        {
            transform.position = transform.position - new Vector3(0, 1 * Time.deltaTime, 0);

        }
    }

    //courotine che semplicemente cambia il valore da true a false e viceversa
    IEnumerator anima()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.4f);
            anim = !anim;

        }
    }



}
