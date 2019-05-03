using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovaChildBlock : MonoBehaviour
{
    [HideInInspector]
     public bool isMove;

    [HideInInspector]
    public Vector3 beforeMovePosition;

    GameObject moveObj;

    void Update()
    {
        //左クリックでRay
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMove = false;

            if(moveObj != null)
            {
                //元の位置に戻す
                moveObj.transform.position = beforeMovePosition;

                //コライダーの大きさ比較用クラスが引っ付いてたら削除
                if (moveObj.GetComponent<ColliderCompare>() != null)
                {
                    Destroy(moveObj.GetComponent<ColliderCompare>());
                }
            }
        }

        if (isMove)
        {
            MovePoisition();
        }
    }

    //マウスからのレイ
    void RayCheck()
    {
        Ray ray = new Ray();
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            moveObj = hit.collider.gameObject;

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Top") && moveObj.GetComponent<ColliderCompare>()==null)
            {
                //移動前のポジションを保存
                beforeMovePosition = moveObj.transform.position;

                //コライダーの大きさ比較用クラスをくっつける
                hit.collider.gameObject.AddComponent<ColliderCompare>();

                isMove = true;         
            }
        }
    }

    //マウスに合わせて移動
    void MovePoisition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(this.gameObject.transform.position).z);

        Vector3 moveTo = Camera.main.ScreenToWorldPoint(mousePos);

        moveObj.transform.position = moveTo;
    }
}
