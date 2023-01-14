using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class BuildNextWell : MonoBehaviour
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

            WellBalance.instance.PlusCurrencyOnValue(1);
            GemBalance.instance.PlusCurrencyOnValue(1);

            var wellBuilder = GameObject.FindObjectOfType<WellBuilder>();
            wellBuilder.SetBiggestSize();
            wellBuilder.SetFasterWells();
            wellBuilder.BuildWell();
        }
    }
}