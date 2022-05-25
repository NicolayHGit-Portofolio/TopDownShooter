using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    void Update()
    {
        if (GameManager.gm.gameOver)
            return;

        this.transform.position = new Vector3(target.position.x, target.position.y, -1);
    }
}
