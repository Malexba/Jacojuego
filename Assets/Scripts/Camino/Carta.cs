using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Carta : EventTrigger
{
    public bool dragging; // Booleano que dice si se está arrastrando la carta
    
    private float altura; // Altura de la carta

    private GameObject mano; // La mano del jugador

    public int posicionEnMano; // La posicion de la carta en la mano

    private float limite; // Limite de la pantalla a partir del cual se activa la carta

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        RectTransform rt = (RectTransform) transform;
        altura = rt.rect.height;

        mano = GameObject.FindGameObjectWithTag("Mano");

        rt = (RectTransform) mano.transform;
        limite = mano.transform.position.y+rt.rect.height/2;
    }

    // Update is called once per frame
    void Update()
    {
        // Arrastrar cuando se mantiene pulsado sobre la carta
        if (dragging){
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }

        // Si se suelta en el tablero, llamar al método UsarCarta()
        if (!dragging && transform.position.y > limite){
            mano.GetComponent<Mano>().UsarCarta(posicionEnMano);
        }
        
    }

    // Se activa cuando se pulsa sobre la carta
    public override void OnPointerDown(PointerEventData eventData){
        if (mano.GetComponent<Mano>().GetArrastrables()){
            dragging = true;
        }
    }

    // Se activa cuando se deja de pulsat sobre la carta
    public override void OnPointerUp(PointerEventData eventData){
        dragging = false;
    }

    public void LlamarEfecto(){
        BroadcastMessage("ProvocarEfecto");
    }
    

    
}
