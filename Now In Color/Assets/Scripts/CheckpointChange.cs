using UnityEngine;

public class CheckpointChange : MonoBehaviour
{
    public Sprite coloredVersion;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.sprite = coloredVersion;
        }
    }
}
