using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
  public Image fadeScreen;
  public float fadeSpeed;

  public void MakeFade()
  {
        fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
            Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed* Time.deltaTime));
  }
}
