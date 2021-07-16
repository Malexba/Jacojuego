using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    public GameObject[] cosa;
    public Jugador jugador;
    void Start()
    {
        if (jugador.inicio)
        {
            cosa[0].SetActive(true);
            cosa[1].SetActive(false);
        } else
        {
            cosa[0].SetActive(false);
            cosa[1].SetActive(true);
        }
    }
    public void CambioEscena()
    {
        SceneManager.LoadScene("Selector");
    }

    public void Salgo()
    {
        Application.Quit();
    }
}
