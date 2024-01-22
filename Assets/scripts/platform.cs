using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public PlatformType platformType;
    public float bounceSpeed = 4f;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal == Vector2.down)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * bounceSpeed;
            }
            
            //weak platform
            if (platformType == PlatformType.weak) ;
            {
                if (GetComponent<Animation>() != null)
                {
                    GetComponent<Animator>().SetTrigger("Trigger");
                    // gameObject.SetActive(false);
                    Invoke("HideGameObject",0.4f);
                }
            }
        }
    }

    void HideGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            gameObject.SetActive(false);
        }
    }
}
public enum PlatformType
{
    normal,
    weak
}