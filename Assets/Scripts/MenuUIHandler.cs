using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif    

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField PlayerName;
    
    void Start() {
        PlayerName.text = DataManager.Instance.PlayerName;
    }


    public void StartGame() {
        
        if ( PlayerName.text == ""  )
        {
            Debug.Log("Please enter a valid name");
        } else {
            DataManager.Instance.PlayerName = PlayerName.text.ToString();
            SceneManager.LoadScene(1);
        }
        


    }

    public void QuitGame() {
        DataManager.Instance.Save();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    
}
