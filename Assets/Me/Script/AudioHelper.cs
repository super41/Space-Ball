using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public AudioClip gameOverClip;
    public AudioClip getCoinClip;
    // Start is called before the first frame update
    private static AudioHelper INSTANCE;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            throw new System.Exception("AudioHelper has aleray instance");
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayClip(AudioClip clip, Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(clip, pos);
    }

    public void PlayGameOverClip(Vector3 pos)
    {
        PlayClip(gameOverClip, pos);
    }

    public void PlayGetCoinClip(Vector3 pos)
    {
        PlayClip(getCoinClip, pos);
    }

    public static AudioHelper GetInstance()
    {
        return INSTANCE;
    }
}
