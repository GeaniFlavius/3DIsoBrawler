using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public Image ringHealthBar;

    public float health;
    float maxHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {

        lerpSpeed = 2f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (health / 100), lerpSpeed);
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        ringHealthBar.color = healthColor;

    }
}
