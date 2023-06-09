using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject xpBar;
    public RectTransform xpRect;
    private float xpStartingWidth = 10.0f;
    private float xpMaxWidth = 494.0f;
    private int score = 0;
    private float xpMultiplier = 100.0f;
    private float levelScale = 1.2f;
    public GameObject Jellyfish;
    public int xp;
    public int level;
    public TextMeshProUGUI levelText;
    public Button speedButton;
    public Button sizeButton;

    //private Camera camera = Camera.main;
    // Start is called before the first frame update
    void Start()
    {
        xpBar = GameObject.Find("XPBar");
        xpRect = xpBar.GetComponent<RectTransform>();
        level = 0;
        levelText.text = "Level: " + level;
        xpRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xpStartingWidth);
    }

    // Update is called once per frame
    void Update()
    {
        XPBarUpdate();
    }

    void XPBarUpdate()
    {
        if (score * xpMultiplier < xpMaxWidth && score != 0)
        {
            xpRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, score * xpMultiplier);
        } 

        if (score * xpMultiplier > xpMaxWidth)
        {
            xpRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xpMaxWidth);
            score = 0;
            xpMultiplier /= levelScale;
            level++;
            speedButton.gameObject.SetActive(true);
            sizeButton.gameObject.SetActive(true);
            xpRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xpStartingWidth);
        }
    }

    public void UpdateScore()
    {
        score++;
        xp += score;
        levelText.text = "Level: " + level;
    }
}
