
using UnityEngine;

public class Spine : MonoBehaviour
{
    [SerializeField] private Material bodyMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            
            //Debug.LogError(transform.position.y +" ," + transform.lossyScale.y +" ," + other.transform.position.y);
            float playerHeight = transform.position.y +transform.lossyScale.y;
            float obstacleHeight = other.transform.position.y + other.transform.lossyScale.y;
            float value = playerHeight - obstacleHeight;
            Debug.LogError(playerHeight + " ," + obstacleHeight + " ," + value);
            //float value = (transform.position.y + transform.lossyScale.y) - other.transform.position.y;

            //body.Height(-value * 0.5f);
            Debug.LogError(value * 0.5f);
            Player.instance.GetBody().DecreaseHeight(value * 0.25f);

            
            GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Debug.LogError("Capsule Generated");
            piece.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            piece.transform.localScale = new Vector3(transform.lossyScale.x, value * 0.25f, transform.lossyScale.z);

            piece.GetComponent<MeshRenderer>().material = bodyMat;
            piece.GetComponent<CapsuleCollider>().enabled = false;
            Rigidbody pieceRb = piece.AddComponent<Rigidbody>();

            pieceRb.AddForce(-1, 1, -0.5f, ForceMode.Impulse);
            pieceRb.AddTorque(75, 15, 45);
        }
    }
}
