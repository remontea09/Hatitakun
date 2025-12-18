using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject hatitakun;

    private Vector3 move = new Vector3(0, 0,-1);

    private void Update()
    {
        move = new Vector3(hatitakun.transform.position.x, 0,-1);
        camera.transform.position = move;
    }

}
