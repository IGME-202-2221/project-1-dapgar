using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public float score;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        text = GameObject.Find("Scene").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }
}
