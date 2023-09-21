using UnityEngine;
using UnityEngine.UI;

public class OroUI : MonoBehaviour
{
    public Text TextoOro;
    void Update()
    {
        TextoOro.text = PlayerStats.Money.ToString();
    }
}
