using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public bool isBlock = true;
    private AudioSource audioSource;
    public GameObject bombParticle;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �v���C���[�̉������փ��C���o��
        float distance = 0.9f;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f); ;
        Ray ray = new Ray(rayPosition, Vector3.down);
        isBlock = Physics.Raycast(ray, distance);

        // �W�����v�A�j���[�V�����؂�ւ�
        if (isBlock == true)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }

        // ���C�̕\��
        //if (isBlock == true)
        //{
        //    Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        //}
        //else
        //{
        //    Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        //}

        float moveSpeed = 3.0f;
        Vector3 v = rb.velocity;

        if (GoalScript.isGameClear == true)
        {
            v.x = 0;
            v.y = 0;
            rb.velocity = v;
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            animator.SetBool("walk", true);

        }
        else
        {
            v.x = 0;
            animator.SetBool("walk", false);
        }

        rb.velocity = v;
    }

    
    void Update()
    {

        if (GoalScript.isGameClear == true)
        {
            return;
        }

        float jumpSpeed = 10.0f;
        Vector3 v = rb.velocity;

        // ���n���Ă����
        if (isBlock == true)
        {
            // �X�y�[�X�L�[�ŃW�����v
            if (Input.GetKeyDown(KeyCode.Space))
            {
               // animator.SetBool("jump", true);
                v.y = jumpSpeed;
            }
        }
        else
        {
            //animator.SetBool("jump", false);
        }

        rb.velocity = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;

            // �����p�[�e�B�N������
            Instantiate(bombParticle, transform.position, Quaternion.identity);

        }
    }
}
