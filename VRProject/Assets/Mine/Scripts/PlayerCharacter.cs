using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCharacter : MonoBehaviour
{
    private int _health;
    private int healthPackValue;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fillImg;
    [SerializeField] private Text gameOver; //testo che apparirà quando il gioco finisce ovvero quando il personaggio muore
    [SerializeField] private Image damageImage;//immagine di dolore che appare quando vieniamo colpiti
    private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private float flashSpeed = 5f;
    private float barValueDamage;
    private Image healthBarBackground;
    private bool damaged;

    // Start is called before the first frame update
    void Start()
    {//assegnamo i valori grazie al Manager
        _health = Managers.Player.health;
        healthBar.maxValue = Managers.Player.maxHealth;
        healthPackValue = Managers.Player.healthPackValue;

        barValueDamage = Managers.Player.barValueDamage;
        healthBarBackground = healthBar.GetComponentInChildren<Image>(); //con GetComponentInChildren ci andiamo a prendere il component image figlio
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H) && Managers.Inventory.GetItemCount("health") != 0)
        {
            _health += healthPackValue;
            healthBar.value += (barValueDamage * healthPackValue);

            if (_health > Managers.Player.health)
            {
                _health = Managers.Player.health;
                healthBar.value = healthBar.maxValue;
            }
            Managers.Inventory.ConsumeItem("health");
        }

        if (_health <= 0)
        {
            Death();
        }
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    //quando il giocatore viene colpito la sua salute diminuisce
    public void hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Health:" + _health);
        damaged = true;
        healthBar.value -= barValueDamage;//riduciamo il valore della barra
    }


    //quando   muore
    public void Death()
    {
        fillImg.enabled = false; //disabilitiamo il fill image dentro lo slider della barra della salute
        gameOver.enabled = true;//abilitiamo la scritta gameover

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0; //mette in pausa il gioco 
        healthBarBackground.color = Color.red;
        GameEvent.isPaused = true;
    }

}
