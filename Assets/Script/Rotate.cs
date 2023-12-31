using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotationSpeed = 20.0f;  // 回転速度（度/秒）
    private float rotationInterval = 7.0f;  // 回転間隔（秒）

    private float nextRotationTime;
    private bool rotateClockwise = true;

    // Start is called before the first frame update
    void Start()
    {
        nextRotationTime = Time.time + rotationInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の時間が回転間隔を超えたら回転方向を切り替える
        if (Time.time >= nextRotationTime)
        {
            rotateClockwise = !rotateClockwise;
            nextRotationTime = Time.time + rotationInterval;
        }

        // 時計回りまたは反時計回りに回転
        float rotationDirection = rotateClockwise ? 1.0f : -1.0f;
        float rotationAngle = rotationSpeed * rotationDirection * Time.deltaTime;

        // オブジェクトを回転
        transform.Rotate(Vector3.up, rotationAngle);
    }
}
