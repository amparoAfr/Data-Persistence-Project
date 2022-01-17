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
    public InputField name;
    public TextMeshProUGUI bestScore;

    // Start is called before the first frame update
    void Start()
    {
        if (Persistence.Instance.namePlayer != null)
        {
            bestScore.text = "Best score: " + Persistence.Instance.namePlayer + ": " + Persistence.Instance.points;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame() {
        Debug.Log("Nombre " + name.text);
        Persistence.Instance.newName = name.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
