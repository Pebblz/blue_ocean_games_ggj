using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] TMP_Text bulletText;
    public void UpdateText(int bulletAmount)
    {
        if(bulletAmount > 0 )
            bulletText.text = bulletAmount.ToString();
        else
        {
            bulletText.text = "";
        }
    }
}
