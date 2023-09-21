using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	public AngelWrapper AngelParaColocar;
	public GameObject objetoPiso;

	public Vector3 localizacionPiso = new Vector3(0,0,0);
	public Vector3 altura = new Vector3(0, 10, 0);

	private Altar selectedAltar;
	public NodeUI nodeUI;
	public GameObject rango;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public bool CanBuild { get { return AngelParaColocar != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= AngelParaColocar.cost; } }

	public void SetAngelParaColocar(AngelWrapper angel)
    {
		AngelParaColocar = angel;
		selectedAltar = null;
	}
	public void SelectAltar(Altar altar)
	{
		if (selectedAltar == altar)
		{
			DeselectNode();
			return;
		}

		selectedAltar = altar;
		AngelParaColocar = null;
		rango.SetActive(true);
		rango.transform.position = selectedAltar.GetBuildPosition();
		angel an = altar.angel.transform.GetComponent<angel>(); 
		rango.transform.localScale = new Vector3(an.range*2,an.range/4,an.range*2);
		Debug.Log("BUILDER:"+an.range);
		nodeUI.SetTarget(altar);
	}

	public void DeselectNode()
	{
		rango.SetActive(false);
		selectedAltar = null;
		nodeUI.Hide();
	}
	public void crearPiso(int numeroPiso) {
		Instantiate(objetoPiso,  localizacionPiso + altura*numeroPiso , Quaternion.identity);
	}
}
