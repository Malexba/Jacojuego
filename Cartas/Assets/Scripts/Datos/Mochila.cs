using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mochila")]
public class Mochila : ScriptableObject
{
    public List<int> mazo = new List<int>(); // Lista con las cartas del mazo

    public void addCarta(int i)
    {
        mazo.Add(i);
    }

    public void mostrarMazo()
    {

    }
}
