using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public float health;
    public float MaxHealth;
    [SerializeField] GameObject loose;
    [SerializeField] Slider slider;
    private void Start()
    {
        health = MaxHealth;
        slider.maxValue = MaxHealth;
        slider.minValue = 0;

    }
    private void Update()
    {
        slider.value = health;
    }
    public void TakeDmg(float dmg)
    {
        if (health - dmg <= 0)
        {
            loose.SetActive(true);
            StartCoroutine(ReloadScene());
        }
        else
        {
            health -= dmg;
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Main_Menu");
    }
}
