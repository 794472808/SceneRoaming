using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Rigidbody player;
    public float speed = 10.0f; // 小车的移动速度
    public float turnSpeed = 50.0f; // 小车的转向速度
    public float smoothMovement = 0.1f; // 平滑移动参数
    public float smoothRotation = 0.1f; // 平滑旋转参数
    void Start()
    {
        
    }

    void Update()
    {
        // // 获取垂直和水平输入（WASD或箭头键）
        // float moveVertical = Input.GetAxis("Vertical");
        // float moveHorizontal = Input.GetAxis("Horizontal");
        //
        // // 计算移动和旋转向量
        // Vector3 movement = transform.forward * moveVertical * speed;
        // Quaternion turnRotation = Quaternion.Euler(0f, moveHorizontal * turnSpeed, 0f);
        //
        // // 应用平滑移动和旋转
        // Vector3 smoothMovementVelocity = Vector3.Lerp(player.velocity, movement, smoothMovement);
        // player.velocity = smoothMovementVelocity;
        //
        // Quaternion smoothRotationVelocity = Quaternion.Slerp(player.rotation, player.rotation * turnRotation, smoothRotation);
        // player.MoveRotation(smoothRotationVelocity);

        
        // float Steeringwheel = Input.GetAxis("Horizontal");
        // Debug.Log("方向盘转弯参数："+Steeringwheel);
        
        // //脚踏板
        // //油门
        // float throttle = Input.GetAxisRaw("Throttle");
        // Debug.Log("油门参数" + throttle);
        //
        // //刹车
        // float brake = Input.GetAxisRaw("Brake");
        // Debug.Log("刹车参数：" + brake);

    }
}
