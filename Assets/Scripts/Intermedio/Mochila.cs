using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mochila : MonoBehaviour // En verdad esto es el gestor de toda la escena
{
    public GameObject popUp;
    public GameObject mazo;
    public GameObject hablar;
    public GameObject arriba;
    public GameObject abajo;
    public GameObject[] carta;
    public Image astro;
    public Sprite[] astros;
    public Text nombre;
    public Image img;
    public Text texto;
    public Jugador jugador;
    bool mochi;
    private int posLista = 0; // Posición en la lista del mazo (mod 3)
    public bool inicio; // Indica si es el fin o el inicio de la etapa

    void Start()
    {
        if (inicio)
        {
            astro.sprite = astros[0];
        } else
        {
            astro.sprite = astros[1];
        }
    }

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
        if (jugador.mazo.Count > 3*(posLista+1)) // Quedan elementos después de estos tres, podemos seguir bajando
            abajo.GetComponent<Button>().interactable = true;
        muestraCartas();
    }

    public void desplazoLista(bool arr)
    {
        if (arr) // Pulsamos botón subir
        {
            posLista--;
            abajo.GetComponent<Button>().interactable = true; // Venimos de abajo, sabemos que podemos bajar
            if (posLista == 0) // Estamos en el comienzo de la lista, no podemos subir más
            {
                arriba.GetComponent<Button>().interactable = false;
            }
        } else // Pulsamos botón bajar
        {
            posLista++;
            arriba.GetComponent<Button>().interactable = true; // Venimos de arriba, sabemos que podemos subir
            if (jugador.mazo.Count > 3*(posLista+1)) // Quedan elementos después de estos tres, podemos seguir bajando
                abajo.GetComponent<Button>().interactable = true;
            else // Estamos en los tres, dos o un último elemento
                abajo.GetComponent<Button>().interactable = false;
        }
        muestraCartas();
    }

    private void muestraCartas()
    {
        int i = 3;
        if (jugador.mazo.Count < 3*(posLista+1)) // En esta parte de la lista hay menos de tres cartas
            i = jugador.mazo.Count % 3;
        for (int j = 0; j < 3; j++) // Muestro u oculto las tres cartas; así como actualizo sus sprites
        {
            if (j < i)
            {
                carta[j].SetActive(true);
                carta[j].GetComponent<Image>().sprite = jugador.spriteCarta(3*posLista+j);
            } else
                carta[j].SetActive(false);
        }
    }

    public void cerrarPopUp()
    {
        if (mochi)
            mazo.SetActive(false);
        else
            hablar.SetActive(false);;
        popUp.SetActive(false);
    }
    public void avanzar()
    {
        if (inicio)
        {
            SceneManager.LoadScene("Camino");
        }
    }
}
