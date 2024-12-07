using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieses : MonoBehaviour
{
    public string piesesName;
    public int piesesNum;
    public static event Action PiesesAttached;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RoomSprite>().roomName == piesesName)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.SetActive(false);
            PiesesAttached?.Invoke();
        }
    }
}
