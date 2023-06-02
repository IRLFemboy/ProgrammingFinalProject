using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GunSelector : MonoBehaviour
{
    public int selectedGun = 0;
    public GameObject[] guns;
    public TextMeshProUGUI gunName;

    private void Start()
    {
        gunName.text = guns[selectedGun].name;
    }

    void Update()
    {
        if (Input.GetButtonDown("Debug Next"))
        {
            NextGun();
        }
        if (Input.GetButtonDown("Debug Previous"))
        {
            PreviousGun();
        }
        if(Input.GetButtonDown("Submit"))
        {
            StartGame();
        }
    }
    void NextGun()
    {
        guns[selectedGun].SetActive(false);
        selectedGun = (selectedGun + 1) % guns.Length;
        gunName.text = guns[selectedGun].name;
        guns[selectedGun].SetActive(true);
    }

    void PreviousGun()
    {
        guns[selectedGun].SetActive(false);
        selectedGun--;
        if (selectedGun < 0)
        {
            selectedGun += guns.Length;
        }
        gunName.text = guns[selectedGun].name;
        guns[selectedGun].SetActive(true);
    }

    void StartGame()
    {
        PlayerPrefs.SetInt("selectedGun", selectedGun);
        SceneManager.LoadScene("Game");
    }
}
