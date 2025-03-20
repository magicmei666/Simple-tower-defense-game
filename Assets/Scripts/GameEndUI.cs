/****************************************************
    文件：GameEndUI.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：游戏失败时的弹窗
*****************************************************/

using System;
using TMPro;
using UnityEngine;

public class GameEndUI : MonoBehaviour
{
	private Animator anim;
	public TextMeshProUGUI messageText;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void Show(string message)
	{
		messageText.text = message;
		anim.SetTrigger("show");
	}

	public void OnRestartButtonClick()
	{
		GameManager.Instance.OnRestart();
	}

	public void OnMenuButtonClick()
	{
		GameManager.Instance.OnMenu();
	}
}