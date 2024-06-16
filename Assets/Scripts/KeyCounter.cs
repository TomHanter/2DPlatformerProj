using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCounter : MonoBehaviour
{
    public static KeyCounter instance;

    [SerializeField] private TMP_Text keyText;
    [SerializeField] private int currrentKey = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        keyText.text = "Key " + currrentKey.ToString() + "/5";
    }

    public void IncreaseKey(int v)
    {
        currrentKey += v;
        keyText.text = "Key " + currrentKey.ToString() + "/5";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Door" && currrentKey == 5)
            SceneManager.LoadScene(0);

    }
}
