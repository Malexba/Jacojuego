using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string nombre = "Nombre";
    public int energia = 10; // Energía del personaje para usar cartas
    public int motivacion = 7; // Motivación del personaje para conseguir más cartas
    public int tamInv = 4; // Nº máximo de cartas que puede llevar el personaje
    public Sprite img; // Sprite del personaje
    public string info = "Info personaje";
}