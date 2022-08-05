using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        MusicController.Instance.PlayMusic();
        MusicController.Instance.StandMusic = true;
        PlayerPrefs.SetInt("TotalScore", 0);
    }

    public void PlayGame()
    {
        StopAllCoroutines();
        StartCoroutine(WaitToPlay());
    }

    private IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(1f);
        MusicController.Instance.StandMusic = false;
        SceneManager.LoadScene("Level1");
    }
}
