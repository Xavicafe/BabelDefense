using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public AngelWrapper angel;
	public AngelWrapper trono;
	public AngelWrapper arcangel;
	public AngelWrapper principado;
	public AngelWrapper virtud;
	public AngelWrapper dominio;
	public AngelWrapper potestad;
	public AngelWrapper querubin;
	public AngelWrapper serafin;

	BuildManager buildManager;

	public bool traspasa = false;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void traspasa_false(){
		
		traspasa=false;
	}
	public void traspasa_true(){
		traspasa=true;
	}

	public void SelectAngel()
	{
		Debug.Log("Angel seleccionado");
		buildManager.SetAngelParaColocar(angel);
	}

	public void SelectTrono()
	{
		Debug.Log("Trono seleccionado");
		buildManager.SetAngelParaColocar(trono);
	}

	public void SelectSerafin()
	{
		Debug.Log("Serafin Seleccionado");
		buildManager.SetAngelParaColocar(serafin);
	}

	public void SelectPrincipado()
	{
		Debug.Log("Principado Seleccionado");
		buildManager.SetAngelParaColocar(principado);
	}

	public void SelectVirtud()
	{
		Debug.Log("Virtud Seleccionado");
		buildManager.SetAngelParaColocar(virtud);
	}
	public void SelectDominio()
	{
		Debug.Log("Dominio Seleccionado");
		buildManager.SetAngelParaColocar(dominio);
	}
	public void SelectPotestad()
	{
		Debug.Log("Dominio Seleccionado");
		buildManager.SetAngelParaColocar(potestad);

	}
	public void SelectQuerubin()
	{
		Debug.Log("Dominio Seleccionado");
		buildManager.SetAngelParaColocar(querubin);
	}
	public void SelectArcangel()
	{
		Debug.Log("Dominio Seleccionado");
		buildManager.SetAngelParaColocar(arcangel);
	}
}
