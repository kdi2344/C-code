using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Movement2D movement2D;
    [SerializeField] private Stage_Data stagedata;
    [SerializeField] private Weapon weapon;

    private void Awake()
    {
        movement2D = transform.GetComponent<Movement2D>();
        weapon = transform.GetComponent<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (movement2D.moveSpeed <= 0f)
        {
            movement2D.moveSpeed = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement2D.MoveTo(new Vector3(x, y, 0f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.startFire();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            weapon.stopFire();
        }
    }
    private void LateUpdate()
    {
        //플레이어가 화면 범위 바깥으로 나가지 못하도록 설정
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stagedata.LimitMin.x, stagedata.LimitMax.x),
            Mathf.Clamp(transform.position.y, stagedata.LimitMin.y, stagedata.LimitMax.y),
            0f
            );

    }

}
