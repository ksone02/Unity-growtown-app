using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchToMoveCamera : MonoBehaviour {
    //터치위치 배열로 생성
    Vector2?[] touchPrevPos = {null, null};
    Vector2 touchPrevVector;
    float touchPrevDist;

    void Start() {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void LateUpdate() {
        //터치가 없다면 null로 초기화
        if(Input.touchCount == 0) {
            touchPrevPos[0] = null;
            touchPrevPos[1] = null;
        } else if (Input.touchCount == 1) {
            if(touchPrevPos[0] ==null || touchPrevPos[1] != null) {
                touchPrevPos[0] = Input.GetTouch(0).position;
                touchPrevPos[1] = null;
            } else {
                Vector2 touchNewPos = Input.GetTouch(0).position;
                transform.position += transform.TransformDirection((Vector3)((touchPrevPos[0] - touchNewPos)*
                    Camera.main.orthographicSize / Camera.main.pixelHeight * 2f));
                
                MoveLimit();

                touchPrevPos[0] = touchNewPos;
            }
        } else if (Input.touchCount == 2) {
            if(touchPrevPos[1] == null) {
                touchPrevPos[0] = Input.GetTouch(0).position;
                touchPrevPos[1] = Input.GetTouch(1).position;
                touchPrevVector = (Vector2)(touchPrevPos[0] - touchPrevPos[1]);
                touchPrevDist = touchPrevVector.magnitude;
            } else {
                //?
                Vector2 screen = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);

                //새위치 배열 저장
                Vector2[] touchNewPos = { Input.GetTouch(0).position, Input.GetTouch(1).position };
                Vector2 touchNewVector = touchNewPos[0] - touchNewPos[1];
                float touchNewDist = touchNewVector.magnitude;

                transform.position += transform.TransformDirection((Vector3)((touchPrevPos[0] + touchPrevPos[1] - screen) * 
                    Camera.main.orthographicSize / screen.y));
                Camera.main.orthographicSize += touchPrevDist / touchNewDist;
                transform.position -= transform.TransformDirection((touchNewPos[0] + touchNewPos[1] - screen) *
                    Camera.main.orthographicSize/ screen.y);

                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 3f);
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, 5f);
            
                touchPrevPos[0] = touchNewPos[0];
                touchPrevPos[1] = touchNewPos[1];
                touchPrevVector = touchNewVector;
                touchPrevDist = touchNewDist;
            }
        } else {
            return;
        }
    }

    void MoveLimit() {
        Vector3 temp;
        temp.x = Mathf.Clamp(transform.position.x, 360.77f, 362.77f);
        temp.y = Mathf.Clamp(transform.position.y, -29, -109);
        temp.z = Mathf.Clamp(transform.position.z, -910.0f, -910.0f);

        transform.position = temp;
    }

}
