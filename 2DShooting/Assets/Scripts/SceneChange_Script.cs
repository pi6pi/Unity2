//シーンチェンジスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Script : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
