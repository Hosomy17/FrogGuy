using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    private Apple[] _apples;
    
    [SerializeField]
    private string _level;

    private void Start()
    {
        _apples = FindObjectsOfType<Apple>();
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {
        while (!AllApplesCollected())
        {
            yield return null;
        }
        
        StartCoroutine(OpenNextLevel());
    }

    private IEnumerator OpenNextLevel()
    {
        GameController.instance.SaveScore();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_level);
    }

    private bool AllApplesCollected()
    {
        foreach (var apple in _apples)
        {
            if (apple.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
