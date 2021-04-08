using UnityEngine;
using System.Collections;

public class TouchCamera : MonoBehaviour 
{
    private float Speed = 25f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;
	public Camera mainCamera;

    public float orthoZoomSpeed = .1f;      //줌인,줌아웃할때 속도(OrthoGraphic모드 용)
	public float perspectiveZoomSpeed = .1f;
    
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch (0);
            if(touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                mainCamera.transform.Translate(movePos); 

                prePos = touch.position - touch.deltaPosition;
            }
        }

		if (Input.touchCount == 2) //손가락 2개가 눌렸을 때
        {
            Touch touchZero = Input.GetTouch(0); //첫번째 손가락 터치를 저장
            Touch touchOne = Input.GetTouch(1); //두번째 손가락 터치를 저장

            //터치에 대한 이전 위치값을 각각 저장함
            //처음 터치한 위치(touchZero.position)에서 이전 프레임에서의 터치 위치와 이번 프로임에서 터치 위치의 차이를 뺌
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; //deltaPosition는 이동방향 추적할 때 사용
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
            // 각 프레임에서 터치 사이의 벡터 거리 구함
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; //magnitude는 두 점간의 거리 비교(벡터)
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // 거리 차이 구함(거리가 이전보다 크면(마이너스가 나오면)손가락을 벌린 상태_줌인 상태)
            float deltaMagnitudeDiff = (prevTouchDeltaMag - touchDeltaMag);

            /*mainCamera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 100f, 640f);*/

			mainCamera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 100f, 640f);
            
        }
    }  
}