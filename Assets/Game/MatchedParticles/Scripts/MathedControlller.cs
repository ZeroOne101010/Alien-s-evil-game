using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathedControlller : MonoBehaviour
{

    public int worth;
    public ValutaType type;

    private ShotEffect[] shotEffect;

    void Start()
    {
        shotEffect = GetComponents<ShotEffect>();
        StartCoroutine("DestroyACoint");
    }

    void Update()
    {
        
    }

    public void effect(GameObject entity)
    {
        EntityMoveController entityMoveController = entity.GetComponent<EntityMoveController>();
        bool isRight = entityMoveController.isRight;
        for(int x = 0; x < shotEffect.Length; x++)
        {
            shotEffect[x].effect(isRight);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Entity")
        {
            EntityController entityController = collision.gameObject.GetComponent<EntityController>();
            if (entityController is IMathedController)
            {
                effect(collision.gameObject);
                IMathedController controller = entityController as IMathedController;
                controller.addValue(this);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator DestroyACoint()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
