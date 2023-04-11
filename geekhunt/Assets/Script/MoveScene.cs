using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour
{
	public static bool first = false;

	//　スタートボタンを押したら実行する
	public void StartGame()
	{
		SceneManager.LoadScene("Tresure");
	}

	//　ゲーム終了ボタンを押したら実行する
	public void EndGame()
	{
		Destroy(gameObject);
		GameManager.instance.levelText.text = "See You!";
	}

	public void ReturnMenu()
	{
		GameManager.instance.food = 100;
		GameManager.instance.level = 1;
		GameManager.instance.attack = 1;
		first = true;
		SceneManager.LoadScene("Start");
	}
}
