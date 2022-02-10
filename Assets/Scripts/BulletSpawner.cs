using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab; //������ ź���� ���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //Playercontroller ������Ʈ�� ���� ���ӿ�����Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0;
            //bulletPrefab�� ��������
            //transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            //������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
