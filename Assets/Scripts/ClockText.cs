using UnityEngine;
using TMPro;

public class ClockText : MonoBehaviour
{
    public TMP_Text text;

    void Update()
    {
        text.text = System.DateTime.Now.ToString("HH:mm");
    }
}