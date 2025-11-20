using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 50f;
    GameObject Healthbar;

    public Slider healthSlider;

  public void Update()
  {
    healthSlider.value = maxHealth/100;
  }
}
