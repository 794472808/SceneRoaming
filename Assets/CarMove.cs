using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float moveSpeed = 1500;
    public float maxSpeed = 1500;
    public float maxAngle = 25;
    public float angleSpeed = 30;

    public float wheelRadius = 4.2f; // 假设车轮的半径为0.5米
    
    public WheelCollider leftF;
    public WheelCollider leftB;
    public WheelCollider rightF;
    public WheelCollider rightB;

    public Transform model_leftF;
    public Transform model_leftB;
    public Transform model_rightF;
    public Transform model_rightB;


    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        leftB.motorTorque = v * moveSpeed;
        rightB.motorTorque = v * moveSpeed;

        //左转向
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log(leftF.steerAngle);
            leftF.steerAngle -= Time.deltaTime * angleSpeed;
            rightF.steerAngle -= Time.deltaTime * angleSpeed;
            if (leftF.steerAngle < (0 - maxAngle) || rightF.steerAngle < (0 - maxAngle))
            {
                //到最大值后就不能继续加角度了
                leftF.steerAngle = (0 - maxAngle);
                rightF.steerAngle = (0 - maxAngle);
            }
        }

        //右转向
        if (Input.GetKey(KeyCode.D))
        {
            leftF.steerAngle += Time.deltaTime * angleSpeed;
            rightF.steerAngle += Time.deltaTime * angleSpeed;
            if (leftF.steerAngle > maxAngle || rightF.steerAngle > maxAngle)
            {
                leftF.steerAngle = maxAngle;
                rightF.steerAngle = maxAngle;
            }
        }

        //松开转向后，方向打回
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            leftF.steerAngle = rightF.steerAngle = 0;
        }

        // 转向回正逻辑
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            leftF.steerAngle = Mathf.Lerp(leftF.steerAngle, 0, Time.deltaTime * angleSpeed);
            rightF.steerAngle = Mathf.Lerp(rightF.steerAngle, 0, Time.deltaTime * angleSpeed);
        }

        float leftSpeed = leftB.rpm * 2 * Mathf.PI * wheelRadius * 0.0166667f; // 将rpm转换为线速度（m/s）
        float rightSpeed = rightB.rpm * 2 * Mathf.PI * wheelRadius * 0.0166667f; // 将rpm转换为线速度（m/s）

        float currentSpeed = Mathf.Sqrt(leftSpeed * leftSpeed + rightSpeed * rightSpeed);

        if (currentSpeed > maxSpeed)
        {
            leftB.motorTorque = 0;
            rightB.motorTorque = 0;
        }

        //当车轮碰撞器位置角度改变，随之也变更车轮模型的位置角度
        WheelsModel_Update(model_leftF, leftF);
        WheelsModel_Update(model_leftB, leftB);
        WheelsModel_Update(model_rightF, rightF);
        WheelsModel_Update(model_rightB, rightB);
    }


    //控制车轮模型移动 转向
    void WheelsModel_Update(Transform t, WheelCollider wheel)
    {
        return;
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        wheel.GetWorldPose(out pos, out rot);

        t.position = pos;
        t.rotation = rot;
    }
}