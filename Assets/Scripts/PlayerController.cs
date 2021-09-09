using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private BallController ball;
   
    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float yNeu = transform.position.y + yInput * speed * Time.deltaTime;
        if(yNeu >= 3.5f)
        {
            yNeu = 3.5f;
        }
        if(yNeu <= -3.5f)
        {
            yNeu = -3.5f;
        }
        
        transform.position = new Vector3(transform.position.x, yNeu, 0);

        if (!ball.ballUnterwegs)
        {
            transform.position = new Vector3(-8, 0, 0);
        }
    }
}
