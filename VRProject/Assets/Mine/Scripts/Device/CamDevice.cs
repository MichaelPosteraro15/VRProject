using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class CamDevice : MonoBehaviour
{
    //Sono le variabili che mi servono per gestire la label della UI.
    [SerializeField] private Text timerLabel;
    [SerializeField] private Text deviceLabel;
    [SerializeField] private Text messageLabel;
    [SerializeField] private Slider counterBar;
    [SerializeField] private GameObject cam;
    
    //Il campo che viene settato nell'editor e che é diverso per ogni dispositivo.
    //Il primo campo serve per settare la password, il secondo il nome del dispositivo e il terzo serve per dire se il dispositivo é hackerabile o meno.  
    public string device;
    private int counter = 0;       
    
    //Variabili utili per il timer.
    private float time = 0;
    private float startTime = -1;
    private float seconds = 0;
    
    private bool isClicked = false; //Variabile che mi dice se ho cliccato il device.
    private bool isDragged = false; //Variabile che mi dice se sto tenendo premuto sul device.
    private static bool isHacking = false; //Variabile che mi dice se sto hackerando il device.

    private bool complete = false;
    
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0;
        seconds = time % 60;
        
        //Se il device che sto hackerando é stato appena cliccato allora devo far ripartire il cronometro
        if(isClicked == true){ 
            timerLabel.text = string.Format ("{0:00}", seconds); 
        }
        
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
            //Setto anche la label che mi dice in che stato sono.
            if(isDragged == true){ 
                time = startTime >= 0 ? UnityEngine.Time.time - startTime : 0; 
                startTime = -1;
                startTime = UnityEngine.Time.time;
                isDragged = false;
                isHacking = true;
            }
            messageLabel.gameObject.SetActive(true);
            messageLabel.text = "Press SPACE as fast as you can.";

            //Richiamo la funzione che mi simula l'hacking del device.
            hacking();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isHacking == true)
        {
            counter++;
            counterBar.value += 1;
            
        }
    }

    //Se faccio click sul device cambio la label del device che voglio hackerare e poi setto a true la variabile che mi dice che ho selezionato un device.
    //Setto anche le label della UI del pc.
    void OnMouseDown(){
        if(complete != true){
            if(isHacking == false){
                isClicked = true;
                deviceLabel.text = device;
                messageLabel.gameObject.SetActive(false);
            }
            else{
                Debug.Log("You can't.");
            }
        }
        else{
            deviceLabel.text = device;
            messageLabel.gameObject.SetActive(true);
            messageLabel.text = "COMPLETE";
        }
    }

    //Funzione che mi simula la fase di hacking
    void hacking(){
        //Setto la label a 0
        timerLabel.text = string.Format ("{0:00}", seconds);

        //Superati i 20 secondi vuol dire che l'hacking é andato a buon fine e quindi viene restituita la password del device.
        //Setto anche le label che mi dicono la fare e la password del device hackerato.
        if(seconds > 10){
            if(counter < 50){
                messageLabel.text = "FAIL";
            }
            else{
                messageLabel.text = "COMPLETE";
                CamAlarm alarm = cam.GetComponent<CamAlarm>();
                alarm.enabled = false;
                complete = true;
            }
            isHacking = false;
            startTime = -1;
            counter = 0;
            counterBar.value = 0;
        }
    }
}
