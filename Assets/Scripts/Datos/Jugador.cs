using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jugador")]
public class Jugador : ScriptableObject
{
    public int personaje; // Entero que indica el personaje elegido
    public List<int> mazo; // Lista con las cartas del mazo del jugador
    public bool inicio; // Indica si es ha empezado la etapa o la ha terminado

    public void addCarta(int i)
    {
        mazo.Add(i);
    }

    public Sprite spriteCarta(int i)
    {
        Sprite sprite = null; // Asigna sprite en función de id de la carta; i es índice en lista de mazo
        return sprite;
    }
}