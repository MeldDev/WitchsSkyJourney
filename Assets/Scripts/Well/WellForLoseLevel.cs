using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class WellForLoseLevel : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<PolygonCollider2D>().isTrigger = true;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Witch")
        {
            LevelSettings.instance.FinishLevel();
        }
    }
}
