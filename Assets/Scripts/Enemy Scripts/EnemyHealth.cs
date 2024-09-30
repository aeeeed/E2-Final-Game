using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHP;
    public bool isEnemyHit = false;
    // Update is called once per frame
    void Update()
    {
        if (EnemyHP == 0)
        {
            SceneManager.LoadScene(5);
        }
        
    }
}
