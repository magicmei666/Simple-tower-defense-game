/****************************************************
    文件：GameManager.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance { get; private set; }
	
	public GameEndUI GameEndUI;
	
	private void Awake()
	{
		Instance = this;
	}

	public void Fail()
	{
		EnemySpawner.Instance.StopSpawn();
		GameEndUI.Show("失 败");
	}

	public void Win()
	{
		GameEndUI.Show("胜 利");
	}

	public void OnRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnMenu()
	{
		SceneManager.LoadScene(0);
	}

}