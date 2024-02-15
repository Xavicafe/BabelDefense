using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static int Money;
	public int startMoney = 400;

	public static int Vidas;
	public int VidasIniciales = 20;

	public static int Ronda;

	public static int Piso;

	void Start()
	{
		Money = startMoney;
		Vidas = VidasIniciales;
		Piso = 0;
		Ronda = 0;
		
	}
}
