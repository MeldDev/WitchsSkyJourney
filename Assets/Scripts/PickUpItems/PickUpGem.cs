using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PickUpGem : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Witch")
        {
            GameObject.FindObjectOfType<PumpkinsBalance>().AddCoins(this, 1);
            Destroy(this.gameObject);
        }
    }
}