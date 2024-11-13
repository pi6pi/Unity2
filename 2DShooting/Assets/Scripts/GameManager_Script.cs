using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    string _gameClearScene = "3ClearScene";
    string _gameOverScene = "4OverScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameClear()
    {
        SceneManager.LoadScene( _gameClearScene );
    }

    public void GameOver()
    {
        SceneManager.LoadScene( _gameOverScene );
    }
}
