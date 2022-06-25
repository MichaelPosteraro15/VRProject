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
            //aumentiamo il contatore dell'oggetto selezionato
            selectOb++;
            switch_ = true;

            //se il contatore è arrivato all'ultimo oggetto disponibile ritorna al primo
            if (selectOb == gameObject.transform.childCount)
            {
                selectOb = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
             selectOb--;
            switch_ = true;

            //se il contatore è arrivato all'ultimo oggetto disponibile ritorna al l'ultimo
            if (selectOb == -1)
            {
                selectOb = gameObject.transform.childCount -1;
            }

        }

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
        

        //se si verifica l'evento del mouse allora vuol dire che bisognerà cambiare oggetto
        if (switch_)
        {
            SelectObject();
        }
        

        

    }

    //metodo che prende l'oggetto(ovvero rende non attivi tutti tranne quello selezionato)
    private void SelectObject()
    {
        animator.Play("SwitchObject");

        foreach (Transform ob in transform)
        {   //rende tutti gli oggetti non attivi
            ob.gameObject.SetActive(false);
        }

        //si prende il figlio selezionato dal contatore e lo rende attivo
        transform.GetChild(selectOb).gameObject.SetActive(true);

        //in base all'oggetto cambia la posizione delle mani
        string obName = transform.GetChild(selectOb).gameObject.name;
        
        if (obName == "Empty")
        {
            //se è vuoto non vediamo il pc
            pc.SetActive(false);
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
            //se la mano sinistra non era bassa allora la abbassiamo
            if (!lowL)
            {
                lowerHand();
                lowL = true;


            }
            // se il pc non era visibile, lo rendiamo tale e spostiamo la mano
            else if (!_showPc)
            {

                _showPc = true;
                showPcHand();

            }



        }
        else
        {//di base il pc non si deve vedere
            pc.SetActive(false);

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
        rightElbow.eulerAngles = new Vector3(
              leftElbow.eulerAngles.x - 5,
              leftElbow.eulerAngles.y,
              leftElbow.eulerAngles.z -80
              );

    }

    private void hidePc()
    {
        rightElbow.eulerAngles = new Vector3(
                leftElbow.eulerAngles.x + 5,
                leftElbow.eulerAngles.y,
                leftElbow.eulerAngles.z +80
                );

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
