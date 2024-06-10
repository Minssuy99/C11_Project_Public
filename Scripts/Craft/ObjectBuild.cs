using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectBuild : MonoBehaviour
{
    public GameObject previewGameObejct; //����
    public LayerMask createAbleLayer; //��ġ������ ���̾�
    public LayerMask createUnableLayer; //��ġ�Ұ��� ���̾�

    GameObject selectGameObject;
    Vector3 pos;

    Material material;

    bool createAble = true;
    CreateObjectSO data;

    private void Start()
    {
        material = previewGameObejct.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if(previewGameObejct.activeInHierarchy) PreviewObject(); //Ȱ��ȭ �����϶��� �۵�
        if (Input.GetMouseButtonDown(0)) CreateObject();
    }

    //�̸�����
    public void PreviewObject()
    {
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance = transform.position.y + 10f;

        if(Physics.Raycast(ray,out RaycastHit hit, distance, createAbleLayer))
        {
            Vector3 point = hit.point;
            float x = point.x;//Mathf.RoundToInt(hit.point.x);
            float z = point.z;//Mathf.RoundToInt(hit.point.z);

            previewGameObejct.transform.position = pos = new Vector3(x, 0.5f, z);
        }
    }

    //�����
    public void CreateObject()
    {
        if (!createAble) return;

        Instantiate(selectGameObject).transform.position = pos;
        previewGameObejct.SetActive(false);

        Inventory inventory = CharacterManager.Instance._player.controller.inventory;

        foreach (RequirResource resource in data.resources)
        {
            int index = (int)resource.type;
            inventory.resourceAmount[index] -= resource.amount;
        }

        gameObject.SetActive(false);
    }

    //�̸����� ������Ʈ��ü
    public void ChangeObject(GameObject go,CreateObjectSO data)
    {
        selectGameObject = go;
        this.data = data;

        previewGameObejct.GetComponent<MeshFilter>().mesh = go.GetComponentInChildren<MeshFilter>().sharedMesh;
        Transform t = go.GetComponentInChildren<MeshFilter>().gameObject.transform;
        previewGameObejct.transform.localScale = t.localScale;

        previewGameObejct.SetActive(true);
    }

    //�Ǽ�������Ʈ�� �������, Oncollision�� ��������� ������� ������ �����̴°� ����
    private void OnTriggerStay(Collider other)
    {
        if (createUnableLayer.value == 1 << other.gameObject.layer)
        {
            material.color = new Color(255, 0, 0, 150 / 255.0f);
            createAble = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (createUnableLayer.value == 1 << other.gameObject.layer)
        {
            material.color = new Color(255, 255, 255, 150 / 255.0f);
            createAble = true;
        }
    }
}
