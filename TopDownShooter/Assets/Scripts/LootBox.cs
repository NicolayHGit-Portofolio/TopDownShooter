using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _itens = new List<GameObject>();
    int _listSize;

    void Start()
    {
        _listSize = _itens.Count;
    }


    public void DropLoot(bool player)
    {
        GameManager.gm.scoreboard.targetHit(10);

        int i = Random.Range(0, _listSize);
        Instantiate(_itens[i], transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
