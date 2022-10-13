using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public float score;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.activeSceneChanged += NewSceneLoaded;
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }

    void NewSceneLoaded(Scene current, Scene next)
    {
        text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
}
