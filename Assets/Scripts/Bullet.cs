using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //ź���̵��ӷ�
    private Rigidbody bulletRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
       //������ٵ��� �ӵ� = ���ʹ���*�̵��ӷ�
        bulletRigidbody.velocity = transform.forward * speed;
        //3�ʵڿ� �ڻ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }
    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            //�������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if(playerController != null)
            {
                //���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }

    void Update()
    {
        
    }
}