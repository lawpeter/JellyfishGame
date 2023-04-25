using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject xpBar;
    public RectTransform xpRect;
    private int score = 1;
    private float xpMultiplier = 10.0f;
    public GameObject Jellyfish;
    // Start is called before the first frame update
    void Start()
    {
        xpBar = GameObject.Find("XPBar");
        xpRect = xpBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        XPBarUpdate();
    }

    void XPBarUpdate()
    {
        xpRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, score * xpMultiplier);
        Debug.Log(score);
    }

    public void UpdateScore()
    {
        score++;
    }
}
