using UnityEngine;
using System;
public class SpikeStucker : MonoBehaviour
{

    public Action Dead;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<SpikeEntity>())
        {
            Debug.Log("dead");
            Dead?.Invoke();
        }
    }
}
