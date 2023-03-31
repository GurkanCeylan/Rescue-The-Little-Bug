using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkerEffect : MonoBehaviour
{
    public SpriteRenderer darkImage;
    public int deadCounter;

    private void Start() 
    {
        darkImage = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        GetDarker();
    }
    public void GetDarker()
    {
        deadCounter = GameManager.Instance.GetDeadCounter();

         switch (deadCounter)
            {
                case 10: darkImage.color = new Color(darkImage.color.r, darkImage.color.g, darkImage.color.b, 0.1f);
                    break; 
                case 20: darkImage.color = new Color(darkImage.color.r, darkImage.color.g, darkImage.color.b, 0.2f);
                    break;
                case 30: darkImage.color = new Color(darkImage.color.r, darkImage.color.g, darkImage.color.b, 0.3f);
                    break;
                case 40: darkImage.color = new Color(darkImage.color.r, darkImage.color.g, darkImage.color.b, 0.4f);
                    break;
                case 50: darkImage.color = new Color(darkImage.color.r, darkImage.color.g, darkImage.color.b, 0.5f);
                    break;
                case 60: darkImage.color = new Color(darkImage.color.r, darkImage.color.g, darkImage.color.b, 0.6f);
                    break;
            }
        
    }
}
