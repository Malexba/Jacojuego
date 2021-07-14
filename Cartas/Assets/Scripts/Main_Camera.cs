using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    float tLX, bRX; // Límites de la camera
    public Transform target; // Objetivo de la cámara
    Vector2 velocity; // Speed of the smooth camera
    public float smoothTime = 0.3f; // Tiempo de suavizado de la cámara

    private Vector3 dragOrigin; // Origen del drag
    public float dragSpeed = 3f; // Velocidad de movimiento de la cámara en drag
    private bool dragging; // Boolean que indica si el jugador está arrastrando la cámara

    private float timeDragging; // Timestamp del último arrastre de cámara del jugador

private Vector3 originalPosition; // Posición original de la cámara al empexzar a arrastrar

    // Start is called before the first frame update

    void Start()
    {
        SetBound(GameObject.FindGameObjectWithTag("Fondo"));
        dragging = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Posición X suavizada
        float posX = Mathf.Round(
            Mathf.SmoothDamp(transform.position.x,
                target.position.x, ref velocity.x, smoothTime
            )*100)/100;


        // Mover la cámara hacia el target (si el jugador no está arrastrando la cámara)
        if (!dragging){
            transform.position = new Vector3(
                Mathf.Clamp(posX, tLX, bRX),
                transform.position.y,
                transform.position.z
            );
        }

        // Al iniciar el arrastre
        if (Input.GetMouseButtonDown(0))
        {
            originalPosition = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            dragging = true;
            timeDragging = Time.realtimeSinceStartup;
        }

        // Al finalizar el arrastre, espera un segundo para poner dragging en false
        if (!Input.GetMouseButton(0) && (Time.realtimeSinceStartup - timeDragging) > 1f){
            dragging = false;
        }
 
        // Durante el arrastre, cambia la posición de la cámara
        if (Input.GetMouseButton(0)){
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;
            transform.position = new Vector3(Mathf.Clamp(originalPosition.x -pos.x * dragSpeed, tLX, bRX), transform.position.y, transform.position.z);
        }
    }

    // Define los límites del movimiento de la cámara
    public void SetBound (GameObject map) {
        Renderer rend = map.GetComponent<Renderer>();
        float halfCameraWidth = Camera.main.aspect * Camera.main.orthographicSize;

        tLX = map.transform.position.x - rend.bounds.size.x/2 + halfCameraWidth;
        bRX = map.transform.position.x + rend.bounds.size.x/2 - halfCameraWidth;
    }
}
