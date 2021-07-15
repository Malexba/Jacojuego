using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Casilla_Mala : MonoBehaviour
{
    // Provocar efecto negativo
    public void ProvocarEfecto(){
        // Selecciona un efecto negativo al azar
        int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
        if (efecto==2) efecto=1;
        // 0 = ¡Te ha salido una agujeta! Pierdes 4 de energía.
        if (efecto == 0){
            // Poner popup (el efecto se implementa en un método al pulsar el botón "Aceptar" del popup)
        }
        // 1 = ¡Te han asaltado unos labrones! Pierdes una carta aleatoria de tu mano.
        else if (efecto==1) {
            // Poner popup (el efecto se implementa en un método al pulsar el botón "Aceptar" del popup)
        }
    }
}
