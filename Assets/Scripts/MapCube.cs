/****************************************************
    文件：MapCube.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：地图格子脚本
*****************************************************/

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
	private GameObject turretGo;
	private TurretData TurretData;

	public GameObject buildEffect;

	private Color normalColor;
	private bool isUpgrade = false;

	private void Start()
	{
		normalColor = GetComponent<MeshRenderer>().material.color;
	}

	private void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject()==true) return;
		if (turretGo != null)
		{
			BuildManager.Instance.ShowUpgradeUI(this,transform.position,isUpgrade);
		}
		else
		{
			
			BuildTurret();
		}
	}

	private void BuildTurret()
	{
		TurretData = BuildManager.Instance.selectedTurretData;
		if(TurretData == null || TurretData.turretPrefab==null) return;
		
		if (BuildManager.Instance.IsEnough(TurretData.cost) == false)
		{
			return;
		}

		BuildManager.Instance.ChangeMoney(-TurretData.cost);

		turretGo = InstantiateTurret(TurretData.turretPrefab);
	}

	private void OnMouseEnter()
	{
		if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false)
		{
			GetComponent<MeshRenderer>().material.color = normalColor*0.7f;
		}
	}

	private void OnMouseExit()
	{
		GetComponent<MeshRenderer>().material.color = normalColor;
		
	}

	public void OnTurretUpgrade()
	{
		if (BuildManager.Instance.IsEnough(TurretData.costUpgraded))
		{
			isUpgrade = true;
			BuildManager.Instance.ChangeMoney(-TurretData.costUpgraded);
			Destroy(turretGo);
			turretGo = InstantiateTurret(TurretData.turretUpgradedPrefab);
		}
	}

	public void OnTurretDestroy()
	{
		Destroy(turretGo);
		TurretData = null;
		turretGo = null;
		GameObject go = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
		Destroy(go,2);
	}

	private GameObject InstantiateTurret(GameObject prefab)
	{
		GameObject turretGo = GameObject.Instantiate(TurretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
		GameObject go = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
		Destroy(go,2);
		return turretGo;
	}
}



















