using UnityEngine;

public class RayFromAbove : MonoBehaviour
{
    MoveChildBlock moveChildBlock;

     void Start()
    {
        moveChildBlock = FindObjectOfType<MoveChildBlock>();
    }

    void Update()
    {
        RaySelfAbove();
    }


    //自身の真上から自身に向けてレイを出す
    void RaySelfAbove()
    {
        Vector3 thisPos = this.gameObject.transform.position; 

        Ray ray = new Ray(new Vector3(thisPos.x,thisPos.y+1,thisPos.z), Vector3.down);
        RaycastHit hit = new RaycastHit();
        
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) )
        {
            if(hit.collider.gameObject.name == this.gameObject.name)
            {
                hit.collider.gameObject.layer = LayerMask.NameToLayer("Top");
            }
            
            if(hit.collider.gameObject.name != this.gameObject.name && moveChildBlock.isMove == false)
            {
                this.gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
    }

}
