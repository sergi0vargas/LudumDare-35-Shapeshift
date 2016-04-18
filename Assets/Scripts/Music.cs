using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    private static Music _instance;

    public static Music Instance { get { return _instance; } }

    public AudioClip[] musica;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
    }

    void Start()
    {
        int i = Random.Range(0, 3);
        GetComponent<AudioSource>().clip = musica[i];
        GetComponent<AudioSource>().Play();
    }


    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            int i = Random.Range(0, 3);
            GetComponent<AudioSource>().PlayOneShot(musica[i]);
        }
    }
}
