using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camino_Llano : MonoBehaviour
{

    // Moverse de 1 a 5 casillas
    public void ProvocarEfecto(){
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.GetComponent<Jugador_Mapa>().RestarEnergia(6); // Restar 6 puntos de energía
        GameObject casillaActual = jugador.GetComponent<Jugador_Mapa>().casillaActual;
        List<GameObject> casillasPosibles = new List<GameObject>();
        List<GameObject> auxs = new List<GameObject>();
        // Encuentra las casillas a distancia de entre 1 y 5
        for(int i =1;i < 6; i++){
            auxs = casillaActual.GetComponent<Casilla_Mapa>().GetCasillasADistancia(i);
            foreach(GameObject aux in auxs){
                casillasPosibles.Add(aux);
            }
        }

        // Activa el halo de todas ellas
        foreach (GameObject casilla in casillasPosibles){
            casilla.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
}
