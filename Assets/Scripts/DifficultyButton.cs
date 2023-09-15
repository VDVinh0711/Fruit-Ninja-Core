using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    Button choseLevel;
    public float diffyculty;
    private void Start()
    {
        choseLevel = GetComponent<Button>();
        choseLevel.onClick.AddListener(SetdiffycultyButton);

    }
    void SetdiffycultyButton()
    {
        GameManager.Innstance.StarGame(diffyculty);
    }  
}
