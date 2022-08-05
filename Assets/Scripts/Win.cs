using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void OnBackMenuButton()
    {
        StopAllCoroutines();
        StartCoroutine(WaitToPlay());
    }
    
    private IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(1f);
        MusicController.Instance.StandMusic = false;
        SceneManager.LoadScene("Menu");
    }
}
