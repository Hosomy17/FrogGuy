using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    private bool _standMusic;
    private AudioSource _BGM;
    private static MusicController _instance;

    [SerializeField]
    private float _standTime;
    public static MusicController Instance => _instance;

    public bool StandMusic
    {
        get => _standMusic;
        set => _standMusic = value;
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            _standMusic = false;
            TryGetComponent(out _BGM);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        _BGM.Play();
        _BGM.time = 0f;
        StartCoroutine(StartMusic());
    }

    public void StopMusic()
    {
        StopAllCoroutines();
        _BGM.Stop();
    }

    private IEnumerator StartMusic()
    {
        while(true)
        {
            if (_standMusic && _BGM.time >= _standTime)
            {
                _BGM.time = 0f;
            }

            yield return null;
        }
    }
}
