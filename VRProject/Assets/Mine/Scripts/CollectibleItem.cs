using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //nome dell'oggetto
    [SerializeField] private string itemName;
    private bool anim;
    public float speed = 1;






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
       StartCoroutine( anima());
    }

    private void Update()
    {
        if (anim)
        {
            transform.position = transform.position + new Vector3(0,speed*Time.deltaTime,0);

        }
        else
        {
            transform.position = transform.position - new Vector3(0, speed * Time.deltaTime, 0);

        }
    }

    IEnumerator anima()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.4f);
            anim = !anim;

        }
    }



}
