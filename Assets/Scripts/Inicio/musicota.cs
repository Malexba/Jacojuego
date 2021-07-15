using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicota : MonoBehaviour
{
    public GameObject g;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Musica");
        DontDestroyOnLoad(g);
        cambioPista(0);
    }

    public void cambioPista(int i)
    {
        if (g.GetComponent<AudioSource>().clip != clip[i])
        {
            g.GetComponent<AudioSource>().clip = clip[i];
            g.GetComponent<AudioSource>().Play();
        }
        
    }
}
