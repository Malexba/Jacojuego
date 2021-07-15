using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Mapa : MonoBehaviour

{
    public GameObject casillaActual; // Casilla en la que se encuentra
    public Sprite sprite; // Sprite que usa el jugador

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        MoverACasilla(casillaActual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverACasilla(GameObject casilla){
        transform.position = casillaActual.transform.position + new Vector3(0,sprite.bounds.size.y/2,0);
    }
}
