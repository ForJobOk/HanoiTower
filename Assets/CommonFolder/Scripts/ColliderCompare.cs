using UnityEngine;

public class ColliderCompare : MonoBehaviour
{
    MoveChildBlock moveChildBlock;

    void Start()
    {
        moveChildBlock = FindObjectOfType<MoveChildBlock>();
    }

    //ブロック同士の衝突時にルール通りの移動か判定する
    void OnTriggerEnter(Collider other)
    {
        BoxCollider thisCollider = this.gameObject.GetComponent<BoxCollider>();

        GameObject otherObj = other.gameObject;

        BoxCollider otherObjBoxCollider = otherObj.GetComponent<BoxCollider>();

        //コライダーの大きさを比較して衝突先の方が大きければ移動
        if (otherObjBoxCollider.size.x > thisCollider.size.x)
        {
            Vector3 otherObjPos = otherObj.transform.position;
            moveChildBlock.beforeMovePosition = new Vector3(otherObjPos.x, otherObjPos.y+ thisCollider.size.y*3, otherObjPos.z);
            moveChildBlock.isMove = false;
        }
    }
}
