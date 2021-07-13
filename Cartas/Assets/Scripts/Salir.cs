using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    public void CambioEscena()
    {
        SceneManager.LoadScene("Selector");
    }

    public void Salgo()
    {
        Application.Quit();
    }
}
