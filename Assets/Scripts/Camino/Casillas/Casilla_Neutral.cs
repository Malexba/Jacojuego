using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Casilla_Neutral : MonoBehaviour
{
    // Provocar efecto neutral
    public void ProvocarEfecto(){
        // Selecciona un efecto negativo al azar
        int efecto = (int)Math.Floor(2*UnityEngine.Random.value);
        if (efecto==2) efecto=1;
        /* 0 = ¿Quieres tomar un atajo?
            ◦Sí (de manera aleatoria avanzas o retrocedes 4 casillas)
            ◦No (no sucede nada)
            */
        if (efecto == 0){
            // Poner popup (cada botón activa el efecto correspondiente y cierra el popup)
        }
        /* 1 = Te encuentras con un compañero peregrino herido.¿Decides ayudarle?
            ◦Sí (pierdes 5 de energía. Añade 2 cartas de “Compañía agradable ” a tu mazo )
            ◦No(no sucede nada)
            */
        else if (efecto==1) {
            // Poner popup (cada botón activa el efecto correspondiente y cierra el popup)
        }
    }
}
