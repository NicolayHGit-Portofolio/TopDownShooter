using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int _health = 100;   

    public void Damage(int damage)
    {
        _health -= damage;

        if (gameObject.tag == "Player")
            GameManager.gm.UpdateHealth(_health);

        if (_health <= 0)
        {
            _health = 0;
            if (gameObject.tag == "Enemy")
            {
                GameManager.gm.scoreboard.targetHit(20);
                Destroy(gameObject);
            }
            else
               GameManager.gm.EndGame();
        }
    }

    public void Heal(int newHealth)
    {
        _health = newHealth;
        GameManager.gm.UpdateHealth(_health);
    }
}
