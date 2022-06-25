using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Laptop : MonoBehaviour
{
    //Mi serve l'oggetto camera per sapere che tipo di device sto guardando. Se ho davanti una cam un pc o altro...
    //Sulla base dell'oggetto guardato riesco a capire che device ho davanti e di conseguenza che sw devo usare per l'hacking.
    [SerializeField] private GameObject camera;
    
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        try{
            GameObject currentObject = camera.GetComponent<RayShooter>().getCurrentObject();
        
            if(currentObject.tag == "Cam"){
                transform.Find("CamHackingSW").gameObject.SetActive(true);
                transform.Find("ComputerHackingSW").gameObject.SetActive(false);
            }
            else if(currentObject.tag == "Computer"){
                transform.Find("CamHackingSW").gameObject.SetActive(false);
                transform.Find("ComputerHackingSW").gameObject.SetActive(true);
            }
        }
        catch{}
    }

}