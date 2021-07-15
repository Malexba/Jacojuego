using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string nombre = "Nombre";
    public string nombre2 = "Nombre2";
    public int tipo = 0;
    public int energia = 10; // Energ�a del personaje para usar cartas
    public int motivacion = 7; // Motivaci�n del personaje para conseguir m�s cartas
    public int tamInv = 4; // N� m�ximo de cartas que puede llevar el personaje
    public Sprite img; // Sprite del personaje
    public Sprite img2;
    public string info = "Info personaje";
    public string dialogo = "Perorata del tipo en cuestión";
    public string dialogo2 = "Perorata del tipo en cuestión";
}