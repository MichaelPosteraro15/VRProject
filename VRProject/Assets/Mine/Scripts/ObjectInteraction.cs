using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private Text timerLabel;
    [SerializeField] private Text deviceLabel;
    public string password;
    public string device;

    private float time = 0;
    private float startTime = -1;
    private float seconds = 0;
    
    private bool isClicked = false; //Variabile che mi dice se ho cliccato il device.
    private bool isDragged = false; //Variabile che mi dice se sto tenendo premuto sul device.
    private bool isHacking = false; //Variabile che mi dice se sto hackerando il device.

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0;
        seconds = time % 60;
        
        //Se il device che sto hackerando é stato appena cliccato allora devo far ripartire il cronometro
        if(isClicked == true){ timerLabel.text = string.Format ("{0:00}", seconds); }
        
        //Se ho premuto il bottone destro del mouse e ancora non sono nella fase si hacking ma sto comunque cliccando sul device per iniziare l'hacking...
        if (Input.GetMouseButtonDown(0) && isHacking != true && isClicked == true){
            //...allora inizializza la variabile che mi dice se sto tenendo premuto e fai partire il tempo. Così facendo prima di iniziare l'hacking ci sono
            //quei 5 secondi in cui il player può decidere se tirarsi indietro o continuare per poi entrare nella vera e propria fare si hacking.
            if(isDragged == false){ startTime = UnityEngine.Time.time; isDragged = true; }
        }
        //Se ho lasciato il bottone destro del mouse e la fase di hacking non é ancora iniziata allora vuol dire che il player si é tirato indietro.
        else if (Input.GetMouseButtonUp(0) && isHacking != true){
            //L'oggetto non é più cliccato e il player non lo sta premendo. Sostanzialmente si ritorna al punto di partenza.
            //Per tale motivo si "pulisce" la label e si setta startTime per far ripartire il tempo da 0.
            isClicked = false;
            isDragged = false;
            startTime = -1;
            timerLabel.text = string.Format ("{0:00}", 0);
        }

        //Se sono arrivato fino a questo punto tenendo premuto il bottone destro del mouse per più di 5 secondi, allora inizia automaticamente la fase di hacking.
        if(seconds > 5){
            //La prima volta che entro faccio ripartire il tempo. Questa volta la durata dell'operazione é 20 secondi.
            //Setto la variabile che mi dice se sto tenendo premuto a false.
            //Setto la variabile che mi dice se sono in fase di hacking a true.
            if(isDragged == true){ 
                Debug.Log("Hacking of " + device + " started.");
                time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0; 
                startTime = -1;
                startTime = UnityEngine.Time.time;
                isDragged = false;
                isHacking = true;
            }
            //Richiamo la funzione che mi simula l'hacking del device.
            hacking();
        }
    }

    //Se faccio click sul device cambio la label del device che voglio hackerare e poi setto a true la variabile che mi dice che ho selezionato un device.
    void OnMouseDown(){
        Debug.Log("Tryng to connect with: " + device + ".");
        deviceLabel.text = device;
        isClicked = true;
    }

    //Funzione che mi simula la fase di hacking
    void hacking(){
        //Setto la label a 0
        timerLabel.text = string.Format ("{0:00}", seconds);

        //Superati i 20 secondi vuol dire che l'hacking é andato a buon fine e quindi viene restituita la password del device.
        if(seconds > 20){
            Debug.Log("Hacking of " + device + " completed." + " Password: " + password + ".");
            isHacking = false;
            startTime = -1;
        }
    }


}
