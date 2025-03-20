/****************************************************
    文件：Turret.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：炮台逻辑
*****************************************************/

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
	public List<GameObject> enemyList = new List<GameObject>();

	public GameObject bulletPrefab;
	public Transform bulletPosition;
	public float attackRate = 1;
	private float nextAttackTime;

	private Transform head;

	protected virtual void Start()
	{
		head = transform.Find("Head");
	}

	private void Update()
	{
		DirectionControl();
		Attack();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			enemyList.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Enemy")
		{
			enemyList.Remove(other.gameObject);
		}
	}

	protected virtual void Attack()
	{
		if(enemyList == null || enemyList.Count == 0) return;
		//GameObject go = enemyList[0];

		if (Time.time > nextAttackTime)
		{
			Transform target = GetTarget();
			if (target != null)
			{
				GameObject go = GameObject.Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
				//go.GetComponent<Bullet>().SteTarget(enemyList[0].transform);
				go.GetComponent<Bullet>().SteTarget(target);
				nextAttackTime = Time.time + attackRate;
			}
			
		}
	}

	public Transform GetTarget()
	{
		if (enemyList != null && enemyList.Count > 0 && enemyList[0] != null)
		{
			return enemyList[0].transform;
		}

		if (enemyList == null || enemyList.Count == 0) return null;
		List<int> indexList = new List<int>();
		for (int i = 0; i < enemyList.Count; i++)
		{
			if (enemyList[i] == null || enemyList[i].Equals(null)) 
			{
				indexList.Add(i);
			}
		}

		for (int i = indexList.Count - 1; i >= 0; i--)
		{
			//indexList.RemoveAt(indexList[i]);
			enemyList.RemoveAt(indexList[i]);
		}

		if (enemyList != null && enemyList.Count != 0)
		{
			return enemyList[0].transform;
		}

		return null;
	}

	private void DirectionControl()
	{
		//GameObject target = GetTarget().gameObject;
		Transform target = GetTarget();

		if (target == null) return;

		Vector3 targetPosition = target.transform.position;
		targetPosition.y = head.position.y;
		
		head.LookAt(targetPosition);
	}
}

