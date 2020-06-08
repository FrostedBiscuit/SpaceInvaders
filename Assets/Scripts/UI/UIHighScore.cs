using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHighScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    // Update is called once per frame
    void Update()
    {
        Text.text = $"HIGH SCORE: {GameManager.instance.HighScore}";
    }
}
