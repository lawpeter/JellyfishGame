using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject xpBar;
    public RectTransform xpRect;
    public float startingWidth = 10.0f;
    public float width;
    // Start is called before the first frame update
    void Start()
    {
        xpBar = GameObject.Find("XPBar");
        xpRect = xpBar.GetComponent<RectTransform>();
        width = 10.0f;
        xpRect.SetSizeWithCurrentAnchors(xpRect.rect.width, width);
    }

    // Update is called once per frame
    void Update()
    {
        //XPBarUpdate();
    }

    void XPBarUpdate()
    {
        //xpRect.SetSizeWithCurrentAnchors(startingWidth, xpRect.rect.height);
    }
}
