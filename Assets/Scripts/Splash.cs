using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TMP_Text))]
public class Splash : MonoBehaviour
{
    private TMP_Text _text;

    private float _faceDilate;

    private void Awake()
    {
        TryGetComponent(out _text);
        _faceDilate = 2;
    }

    private void Start()
    {
        Invoke("OpenMenu", 5f);
    }

    private void Update()
    {
        _faceDilate -= Time.deltaTime;
        _faceDilate = Mathf.Clamp(_faceDilate, 0, 2);
        
        _text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, _faceDilate);
    }

    private void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
