using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jugador")]
public class Jugador : ScriptableObject
{
    public int personaje; // Entero que indica el personaje elegido
    public List<int> mazo; // Lista con las cartas del mazo del jugador
    public Sprite[] carta;
    public bool inicio = true; // Indica si es ha empezado la etapa o la ha terminado

    public void addCarta(int i)
    {
        mazo.Add(i);
    }

    public Sprite spriteCarta(int i)
    {
        return carta[i];
    }
}