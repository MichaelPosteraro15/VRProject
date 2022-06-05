using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Vector3 dPos;
    private bool _open;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dPos;
            transform.position = pos;
        }
        _open = !_open;

    }
}
