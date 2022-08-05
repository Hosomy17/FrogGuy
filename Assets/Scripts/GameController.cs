using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    private float cacheScore;

    public static GameController instance;

    public GameObject gameOver;

    [SerializeField]
    private TMP_Text _text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Update()
    {
        cacheScore += 0.2f;
        cacheScore = Mathf.Clamp(cacheScore, 0, totalScore);
        
        _text.text = String.Format("{0,5:D5}", (int)cacheScore);
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        StartCoroutine(WaitToRestart(lvlName));
    }

    public IEnumerator WaitToRestart(string lvlName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(lvlName);
    }
    
    
}

