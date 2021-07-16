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
        GameObject g = GameObject.FindGameObjectWithTag("Musica");
        if (g.GetComponent<AudioSource>().clip == null)
        {
            jugador.inicio = true;
        }
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

    void Update(){
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
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
