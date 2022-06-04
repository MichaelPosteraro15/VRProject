using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Switch : MonoBehaviour
{
    public int selectOb = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectObject();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.childCount);

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

        //se si verifica l'evento del mouse allora vuol didre che bisognerà cambiare oggetto
        if (switch_)
        {
            SelectObject();
        }
        



    }

    private void SelectObject()
    {
        foreach (Transform ob in transform)
        {
            ob.gameObject.SetActive(false);
        }
        transform.GetChild(selectOb).gameObject.SetActive(true);

    }
}
