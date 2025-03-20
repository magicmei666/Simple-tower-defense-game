/****************************************************
    文件：CameraController.cs
	作者：magicmei666(hxm)
    邮箱: 1539290389@qq.com
	GitHub：https://github.com/magicmei666
    日期：#CreateTime#
	功能：镜头控制逻辑
*****************************************************/

using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float speed = 3;
	public float rotationSpeed = 3.0f; // 旋转灵敏度
	public float zoomSpeed = 400;
	private Vector3 lastMousePosition;
	void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
		
		transform.Translate(new Vector3(horizontal*speed,-scroll*zoomSpeed,vertical*speed) *Time.deltaTime,Space.World);
		HandleRotation();
	}
	
	// 处理鼠标左键旋转摄像机
	private void HandleRotation()
	{
		if (Input.GetMouseButton(0)) // 鼠标左键按住
		{
			Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
			float yaw = deltaMouse.x * rotationSpeed * Time.deltaTime; // 左右旋转
			float pitch = -deltaMouse.y * rotationSpeed * Time.deltaTime; // 上下旋转（反向调整）

			transform.eulerAngles += new Vector3(pitch, yaw, 0);
		}

		lastMousePosition = Input.mousePosition;
	}
}
