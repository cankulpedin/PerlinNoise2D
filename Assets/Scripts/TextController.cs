using UnityEngine;
using TMPro;
using System;

public class TextController : MonoBehaviour
{
    GameObject player;
    public TMP_Text posText;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 location = player.transform.position;

        posText.text = $"{Math.Round(location.x, 2)},{Math.Round(location.y, 2)}";
    }
}
