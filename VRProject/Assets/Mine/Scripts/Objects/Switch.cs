using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Switch : MonoBehaviour
{
    public int selectOb = 0;
    public int numOb;
    // Start is called before the first frame update
    void Start()
    {
        SelectObject();
    }

    // Update is called once per frame
    void Update()
    {
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
        foreach (Transform ob in transform)
        {   //rende tutti gli oggetti non attivi
            ob.gameObject.SetActive(false);
        }

        //si prende il figlio selezionato dal contatore e lo rende attivo
        transform.GetChild(selectOb).gameObject.SetActive(true);

    }
}
