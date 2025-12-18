using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;  // è„â∫ÇÃà⁄ìÆãóó£
    public float speed = 2f;         // à⁄ìÆë¨ìx

    private Vector3 startPosition;
    private Vector3 topPosition;
    private Vector3 bottomPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
        topPosition = startPosition + Vector3.up * moveDistance;
        bottomPosition = startPosition - Vector3.up * moveDistance;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, topPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, topPosition) < 0.01f)
                movingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position, bottomPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, bottomPosition) < 0.01f)
                movingUp = true;
        }
    }
}
