using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreen : MonoBehaviour
{
	public TMP_Text highscore;

	public void Start() {
		highscore.text = string.Format("High score: {0:D7}", PlayerPrefs.GetInt("highscore"));
	}

	public void OnBtnNewGame() {
		// Hide menu
		SceneManager.LoadScene("Main");

		// Init game..
	}

	public void OnBtnQuit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
