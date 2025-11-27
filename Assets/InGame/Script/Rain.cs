using UnityEngine;

public class Rain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerGrowth growth = other.GetComponent<PlayerGrowth>();

        if (growth)
        {
            growth.Grow(); // ¬’·{‰è‚ÌØ‚è‘Ö‚¦
        }
    }
}
