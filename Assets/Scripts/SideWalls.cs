using UnityEngine;

public class SideWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Score(transform.name);
        GetComponent<AudioSource>().Play();
        collision.gameObject.SendMessage("ResetBall");  //better way than find the object or reference it
            }
}
