using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public string audioClipName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        AudioManager.instance.Play(audioClipName);

    }

    void OnTriggerExit(Collider col)
    {
        AudioManager.instance.Stop(audioClipName);
    }
}
