/****************************************************
    文件：Wave.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：敌人波次
*****************************************************/

using System;
using UnityEngine;

[Serializable]
public class Wave
{
	public GameObject enemyPrefab;
	public int count;
	public float rate;
}