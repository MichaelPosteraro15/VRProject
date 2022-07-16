using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeviceWithScreen : MonoBehaviour
{
    [SerializeField] protected PasswordScreen screen;
    [SerializeField] protected string password;

    public void OnMouseDown(){ screen.Open(); }

    // Start is called before the first frame update
    void Start(){ screen.Close(); }

    // Update is called once per frame
    void Update(){ Operation(); }

    protected abstract void Operation();
}
