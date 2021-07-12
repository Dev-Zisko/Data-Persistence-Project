using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        DataManager.Instance.LoadAll();
        string bestNick = DataManager.Instance.GetBestNick();
        int score = DataManager.Instance.GetScore();
        bestScoreText.text = "Best Score: " + bestNick + ": " + score;
    }

    public void SetNickname()
    {
        DataManager.Instance.SetNickname(nicknameInput.text);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
