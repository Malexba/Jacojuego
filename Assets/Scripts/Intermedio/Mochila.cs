using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mochila : MonoBehaviour // En verdad esto es el gestor de toda la escena
{
    public GameObject popUp;
    public GameObject mazo;
    public GameObject hablar;
    public Text nombre;
    public Image img;
    public Text texto;
    public Jugador jugador;
    bool mochi;

    public void platicar(Character c)
    {
        if (jugador.personaje != c.tipo)
        {
            popUp.SetActive(true);
            hablar.SetActive(true);
            mochi = false;
            nombre.text = c.nombre;
            img.sprite = c.img;
            texto.text = c.dialogo;
        }
    }

    /*void establecerInterlocutor(int p)
    {
        switch(p) {
            case 0: // Experto
                break;
            case 1: // Motivado
                break;
            case 2: // Veloz
                break;
            case 3: // NPC
                break;
            case 4: // Lugar
                break;
        }
    }*/

    public void mostrarMazo()
    {
        popUp.SetActive(true);
        mazo.SetActive(true);
        mochi = true;
        // Habría que generar las cartas y meterlas ahí para que se viesen (los sprites)
    }

    public void cerrarPopUp()
    {
        if (mochi)
            mazo.SetActive(false);
        else
            hablar.SetActive(false);;
        popUp.SetActive(false);
    }
}
