using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierBehaviour : MonoBehaviour
{
    [SerializeField] private float lifetime, timer, velocity;
    [SerializeField] private Animator animator;
    [SerializeField] private bool death;
    [SerializeField] private Transform[] targets;
    [SerializeField] private Transform actualTarget;
    [SerializeField] private Vector3 targetDirection;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
        timer = 0;
        actualTarget = targets[0];
        targetDirection = actualTarget.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!death)
        {
            SoldierBehaviourStep();
            timer += Time.deltaTime;
            if (timer > lifetime)
            {
                death = true;
            }
        }
        else
        {
            animator.SetBool("Death", true);
        }
    }

    void SoldierBehaviourStep()
    {
        targetDirection = actualTarget.position - this.transform.position;
        transform.LookAt(new Vector3(actualTarget.position.x,this.transform.position.y, actualTarget.position.z));
        this.transform.position = new Vector3(this.transform.position.x + (targetDirection.normalized.x * velocity) * Time.deltaTime, this.transform.position.y, this.transform.position.z + (targetDirection.normalized.z * velocity) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Esquina")
        {
            Debug.Log("Colision");
            actualTarget = targets[1];
            targetDirection = actualTarget.position - this.transform.position;
        }
    }
}
