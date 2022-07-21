using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        FPSInput player = other.GetComponent<FPSInput>();
        if (player != null)
        { player.die(); }
        Destroy(this.gameObject);
    }
}
