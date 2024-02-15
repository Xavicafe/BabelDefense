using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarclick : MonoBehaviour
{
    public NodeUI NodeUI;
    BuildManager buildManager;
    public click_NodeUI cl;
    private int num =0;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        click();
    }

    private void click(){
        if(Input.GetMouseButtonDown(0)){
            if(NodeUI.angel != null && num >= 1 && !cl.Dentro){
                BuildManager.instance.DeselectNode();
                num=0;
            }
            else if(NodeUI.angel != null){num++;}
        }
    }
}
