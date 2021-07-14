using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string nombre = "Nombre";
    public int energia = 10; // Energ�a del personaje para usar cartas
    public int motivacion = 7; // Motivaci�n del personaje para conseguir m�s cartas
    public int tamInv = 4; // N� m�ximo de cartas que puede llevar el personaje
    public Sprite img; // Sprite del personaje
    public string info = "Info personaje";

}