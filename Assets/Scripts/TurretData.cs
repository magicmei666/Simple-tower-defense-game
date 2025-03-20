/****************************************************
    文件：TurretData.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：炮台数据
*****************************************************/

using System;
using UnityEngine;

[Serializable]
public class TurretData 
{
	public GameObject turretPrefab;
	public int cost;
	public GameObject turretUpgradedPrefab;
	public int costUpgraded;
	public TurretType Type;
}

public enum TurretType
{
	StandardTurret,
	MissileTurret,
	LaserTurret
}