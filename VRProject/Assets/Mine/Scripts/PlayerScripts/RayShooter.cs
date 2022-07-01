using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private GameObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI() {
        int size = 24;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/2;
<<<<<<< HEAD
       // GUI.Label(new Rect(posX, posY, size, size), "*");
        
=======
        GUI.Label(new Rect(posX, posY, size, size), "*");
>>>>>>> feature
    }
    

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                currentObject = hit.transform.gameObject;
            }
        }
    }

    public GameObject getCurrentObject(){
        return currentObject;
    }

}
