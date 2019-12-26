using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;

    public Transform checkpoint;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(checkpoint.position, -checkpoint.up * 2);
    }

    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        //r2d.AddForce(new Vector2(-speed, 0));// 世界座標
        r2d.AddForce(-transform.right * speed); //區域座標 2D transfor,.right 右邊 `tranform.up 上方

        //碰撞資訊 = 物理.射線碰撞
        RaycastHit2D hit = Physics2D.Raycast(checkpoint.position, -checkpoint.up, 2, 1 << 8);

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }

    }


    //持續觸發
    private void OnTriggerstay2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            Track(collision.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "狐狸")
        {
            collision.gameObject.GetComponent<Fox>().Damage(damage);
        }
    }

    #region 方法
    ///  <summary> 隨機移動

    /// <summary>
    /// 追中玩家
    /// </summary>
    /// <param name="target">玩家座標</param>
    private void Track(Vector3 target)
    {
        // 如果 玩家在左邊 角度 =0
        // 如果 玩家在右邊角度 =180
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;  // new vector3(0 , 0, 0)
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    #endregion
}