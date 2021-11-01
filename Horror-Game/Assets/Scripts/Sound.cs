using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour
{
    //Definiert Sound
    public string name;


    public AudioClip clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

