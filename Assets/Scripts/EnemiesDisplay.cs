using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesDisplay : MonoBehaviour
{

    Text enemiesText;
    Level level;
    // Start is called before the first frame update
    void Start()
    {
        enemiesText = GetComponent<Text>();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesText.text = "Enemies: " + level.getEnemies();
    }
}
