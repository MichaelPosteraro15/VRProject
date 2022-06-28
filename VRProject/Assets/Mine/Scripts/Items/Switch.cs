using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Switch : MonoBehaviour
{
    //indice che ci permette di scorrere i figli dell'oggetto a cui è associato tale script
    public int selectOb = 0;
    public Animator animator;
    public Transform leftElbow;
    public Transform rightElbow;
    public GameObject arms;
    public GameObject pc;
    public bool less;


    private bool lowL = false;
    private bool _showPc = false;


    public int numOb;
    // Start is called before the first frame update
    void Start()
    {
        SelectObject();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.childCount mi permette di sapere quanti figli ci sono all'interno dell'oggetto (size)
        numOb = gameObject.transform.childCount;

        bool switch_ = false;

        //scorriamo con la rotellina del mouse tutti gli oggetti che abbiamo a disposizione
        if (Input.GetAxis("Mouse ScrollWheel")>0) // forward
        {
            if(_showPc)
                arms.gameObject.SetActive(true);


            //aumentiamo il contatore dell'oggetto selezionato
            selectOb++;
            switch_ = true;
            less = false;
            //se il contatore è arrivato all'ultimo oggetto disponibile ritorna al primo
            if (selectOb == gameObject.transform.childCount)
            {
                selectOb = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_showPc)
                arms.gameObject.SetActive(true);

            selectOb--;
            switch_ = true;
            less = true;

            //se il contatore è arrivato all'ultimo oggetto disponibile ritorna al l'ultimo
            if (selectOb == -1)
            {
                selectOb = gameObject.transform.childCount -1;
            }

        }
        /*
        //scorro tutti i figli 
        for (int i=1;i<=numOb;i++)
        {
            //se si preme un tasto che corrisponde ad un figlio valido
            if (Input.GetKeyDown(i.ToString()))
            {
                //seleziono l'indice corrispondente al tasto selezionato
                selectOb = i-1;
                
                //prendo l'oggetto
                SelectObject();
            }
        }
        */
        

        //se si verifica l'evento del mouse allora vuol dire che bisognerà cambiare oggetto
        if (switch_)
        {
            SelectObject();
        }
        

        

    }

    //metodo che "prende" l'oggetto(ovvero rende non attivi tutti tranne quello selezionato)
    private void SelectObject()
    {
        //prendo il nome dell'oggetto che possiede in mano attualmente
        string obName = transform.GetChild(selectOb).gameObject.name;

        /* SE GLI OGGETTI NON SONO NELL'INVENTARIO ALLORA NON SARANNO DISPONIBILI
        if (obName == "Gun" && Managers.Inventory.GetItemCount("gun") == 0)
        {
            if (less)
            {
                selectOb--;
                if (selectOb == -1)
                {
                    selectOb = gameObject.transform.childCount - 1;
                }
            }
            else
            {
                selectOb++;
                if (selectOb == gameObject.transform.childCount)
                {
                    selectOb = 0;
                }
            }
               
        }
        

        if (obName == "crowbar" && Managers.Inventory.GetItemCount("crowbar") == 0)
        {
            if (less)
            {
                selectOb--;
                if (selectOb == -1)
                {
                    selectOb = gameObject.transform.childCount - 1;
                }
            }
            else
            {
                selectOb++;
                if (selectOb == gameObject.transform.childCount)
                {
                    selectOb = 0;
                }
            }

        }

        */



         obName = transform.GetChild(selectOb).gameObject.name;

        //parte animazine di cambio oggetto
        animator.Play("SwitchObject");

        foreach (Transform ob in transform)
        {   //rende tutti gli oggetti non attivi
            ob.gameObject.SetActive(false);
        }

        //si prende il figlio selezionato dal contatore e lo rende attivo
        transform.GetChild(selectOb).gameObject.SetActive(true);

        //in base all'oggetto cambia la posizione delle mani

        //cambia l'oggetto corrente
        CurrentItem.Instance.setCurrentItem(obName);

        if (obName == "Empty")
        {
            //se è vuoto non vediamo il pc
            pc.SetActive(false);
            hidePc();

            if (lowL)
            {
                //se la mano era bassa l'alziamo
                raiseHand();
                lowL = false;


            }
            // se il pc era visibile spostiamo la mano
            else if (_showPc)
            {

                hidePc();
                _showPc = false;

            }


        }
        //se il pc è selezionato spostiamo la mano destra, abbassiamo la sinistra e mostriamo il pc
        else if (obName =="Pc")
        {
            pc.SetActive(true);   
            _showPc = true;
            showPcHand();

            



        }
        else
        {//di base il pc non si deve vedere
            pc.SetActive(false);
            hidePc();

            if (!lowL)
            {
                //la mano rimane abbassata
                lowerHand();
                lowL = true;


            }
            if (_showPc)
            {
                _showPc = false;
                hidePc();

            }
        }
    }

    private void showPcHand()
    {
        arms.transform.localScale = new Vector3(0, 0, 0);

    }

    private void hidePc()
    {
        arms.transform.localScale = new Vector3(1, 1, 1);


    }

    private void raiseHand()
    {
        leftElbow.eulerAngles = new Vector3(
               leftElbow.eulerAngles.x + 47,
               leftElbow.eulerAngles.y,
               leftElbow.eulerAngles.z
               );
    
    
    }

    private void lowerHand()
    {
        leftElbow.eulerAngles = new Vector3(
                 leftElbow.eulerAngles.x - 47,
                 leftElbow.eulerAngles.y,
                 leftElbow.eulerAngles.z);
    }

    
}
