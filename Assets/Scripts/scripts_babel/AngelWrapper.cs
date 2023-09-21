using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AngelWrapper
{
	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public double Daño;
	public double VelocidadDeAtaque;

	public double DañoMejorado;
	public double VelocidadDeAtaqueMejorada;

	public double DañoDeArea;
	public double Slow;

	public Sprite logo;

	public int GetSellAmount()
	{
		return cost / 2;
	}
}
