/****************************************************
    文件：WayPoints.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：转弯处路径点
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
	public static WayPoints Instance { get; private set; }
	
	private List<Transform> waypointList;

	private void Awake()
	{
		Instance = this;
		Init();
	}

	private void Init()
	{
		Transform[] transforms = transform.GetComponentsInChildren<Transform>();
		waypointList = new List<Transform>(transforms);
		waypointList.RemoveAt(0);
	}

	public int GetLength()
	{
		return waypointList.Count;
	}

	public Vector3 GetWayPoint(int index)
	{
		return waypointList[index].position;
	}
}