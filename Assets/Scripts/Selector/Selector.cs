using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    public int personajeActual; // Contador del personaje actual en el selector
    public Text nombre; // Nombre del personaje actual
    public Text info; // Descripci�n del personaje actual
    public Image img; // Sprite del personaje actual
    public Character[] personaje; // Array de personajes (almacena datos para cargarlos)
    public Jugador jugador;

    // Start is called before the first frame update
    void Start()
    {
        personajeActual = 0;
        asignarPersonaje();

    }

    void asignarPersonaje()
    {
        nombre.text = personaje[personajeActual].nombre;
        info.text = personaje[personajeActual].info;
        img.sprite = personaje[personajeActual].img;
    }

    public void cambioPersonaje(bool dcha)
    {
        if (dcha) // Pulsa flecha derecha
        {
            if (personajeActual < personaje.Length - 1)
                personajeActual++;
            else
                personajeActual = 0;
        } else // Pulsa flecha izquierda
        {
            if (personajeActual > 0)
                personajeActual--;
            else
                personajeActual = personaje.Length - 1;
        }
        asignarPersonaje();
    }

    public void meLoQuedo()
    {
        jugador.personaje = personajeActual;
        SceneManager.LoadScene("Intermedio");
    }
}
