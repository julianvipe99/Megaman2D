using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int enemiesN = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void countEnemies()
    {
        enemiesN++;
        
    }

    public void winLevel()
    {
        enemiesN--;
        if (enemiesN <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public int getEnemies()
    {
        return enemiesN;
    }
}
