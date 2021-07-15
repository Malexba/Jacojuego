using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camino_Llano : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Moverse de 1 a 5 casillas
    public void ProvocarEfecto(){
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        GameObject casillaActual = jugador.GetComponent<Jugador_Mapa>().casillaActual;
        List<GameObject> casillasPosibles = new List<GameObject>();
        List<GameObject> auxs = new List<GameObject>();
        for(int i =1;i < 6; i++){
            auxs = casillaActual.GetComponent<Casilla_Mapa>().GetCasillasADistancia(i);
            foreach(GameObject aux in auxs){
                casillasPosibles.Add(aux);
            }
        }

    }
}
