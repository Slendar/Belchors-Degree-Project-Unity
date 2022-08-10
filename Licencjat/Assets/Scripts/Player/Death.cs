using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public AlternateMovement movement;
    public GameObject player;
    public CreateCheckpoint checkpointPos;
    public Timer time;
    public DeathsCounter deaths;
    public Animator animator;

    [SerializeField] private float timeDie = 2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            deaths.deaths++;
            movement.enabled = false;
            time.startTimer = false;
            animator.SetBool("IsDead", true);
            FindObjectOfType<AudioManager>().Play("Death");
            
            Invoke("tpPlayer", timeDie);
        }
    }
    void movementOn()
    {
        time.startTimer = true;
        movement.enabled = true;
    }
    void tpPlayer()
    {
        player.transform.position = checkpointPos.checkpoint;
        animator.SetBool("IsDead", false);
        Invoke("movementOn", 0.1f);
    }
}
