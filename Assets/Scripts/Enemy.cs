/****************************************************
    文件：Enemy.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：敌人逻辑脚本
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	private int pointIndex = 0;

	private Vector3 targetPosition = Vector3.zero;

	public float speed = 4;

	public float hp = 100;
	private float maxHP = 0;
	public GameObject explosionPrefab;

	private Slider hpSlider;

	private void Start()
	{
		targetPosition = WayPoints.Instance.GetWayPoint(pointIndex);
		hpSlider = transform.Find("Canvas/HPSlider").GetComponent<Slider>();
		hpSlider.value = 1;
		maxHP = hp;
	}

	private void Update()
	{
		transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
		{
			MoveNextPoint();
		}
	}

	private void MoveNextPoint()
	{
		pointIndex++;

		if (pointIndex > WayPoints.Instance.GetLength() - 1)
		{
			GameManager.Instance.Fail();
			Die();
			return;	
		}
		
		targetPosition = WayPoints.Instance.GetWayPoint(pointIndex);
	}

	void Die()
	{
		Destroy(gameObject);
		EnemySpawner.Instance.DecreateEnemyCount();
		GameObject go = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		Destroy(go,1);
	}

	public void TakeDamage(float damage)
	{
		if(hp<=0) return;
		hp -= damage;
		hpSlider.value = (float)hp / maxHP;

		if (hp <= 0)
		{
			Die();
		}
	}
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	private int pointIndex = 0;

	private Vector3 targetPosition = Vector3.zero;

	public float speed = 4;

	public float hp = 100;
	private float maxHP = 0;
	public GameObject explosionPrefab;

	private Slider hpSlider;

	// Start is called before the first frame update
	void Start()
	{
		targetPosition = WayPoints.Instance.GetWayPoint(pointIndex);
		hpSlider = transform.Find("Canvas/HPSlider").GetComponent<Slider>();
		hpSlider.value = 1;
		maxHP = hp;
	}

	// Update is called once per frame
	void Update()
	{

		transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime);

		if( Vector3.Distance(transform.position,targetPosition)<0.1f)
		{
			MoveNextPoint();
		}

	}

	private void MoveNextPoint()
	{
		pointIndex++;
		if (pointIndex > (WayPoints.Instance.GetLength() - 1))
		{
			GameManager.Instance.Fail();
			Die();return;
		}
		targetPosition = WayPoints.Instance.GetWayPoint(pointIndex);
	}
	void Die()
	{
		Destroy(gameObject);
		EnemySpawner.Instance.DecreateEnemyCount();
		GameObject go= GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		Destroy(go, 1);
	}
	public void TakeDamage(float damage)
	{
		if (hp <= 0) return;
		hp -= damage;
		hpSlider.value = (float)hp / maxHP;
		if (hp <= 0)
		{
			Die();
		}
	}
}*/
