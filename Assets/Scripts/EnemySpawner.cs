/****************************************************
    文件：EnemySpawner.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：敌人生成逻辑
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public static EnemySpawner Instance { get; private set; }
	public Transform startPoint;
	public List<Wave> waveList;

	private int enemyCount = 0;

	private Coroutine spawnCoroutine;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		spawnCoroutine = StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy()//会出现4波敌人出现时间间隔很短，这时候要写一个判断前一波敌人死完了再出现下一波敌人
	{
		foreach (Wave wave in waveList)
		{
			for (int i = 0; i < wave.count; i++)
			{
				GameObject.Instantiate(wave.enemyPrefab,startPoint.position,Quaternion.identity);
				enemyCount++;
				if (i != wave.count - 1)
				{
					yield return new WaitForSeconds(wave.rate);
				}
				yield return new WaitForSeconds(wave.rate);
			}

			while (enemyCount > 0)
			{
				yield return 0;
			}
		}

		yield return null;

		while (enemyCount >0)
		{
			yield return 0;
		}
		GameManager.Instance.Win();
	}

	public void StopSpawn()
	{
		StopCoroutine(spawnCoroutine);
	}

	public void DecreateEnemyCount()
	{
		if (enemyCount > 0)
		{
			enemyCount--;
		}
	}
}