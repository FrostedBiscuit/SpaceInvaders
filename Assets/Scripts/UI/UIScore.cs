using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    // Update is called once per frame
    void Update()
    {
        Text.text = $"SCORE: {GameManager.instance.HighScore}";
    }
}
