using UnityEngine;

public class test : MonoBehaviour
{
    private BoxCollider boxCollider;
    public Transform tt;
    
    // 그리드의 크기
    public float gridSize = 1f;
    // 그리드 중심에서의 오프셋
    private Vector3 gridOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        // 그리드의 중심에서의 오프셋 계산
        gridOffset = new Vector3(gridSize / 2f, gridSize / 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // 클릭한 위치를 그리드의 로컬 좌표로 변환
                Vector3 localHitPoint = hit.collider.transform.InverseTransformPoint(hit.point);

                // 그리드 상에서의 이동 위치 계산
                Vector3 gridPosition = new Vector3(
                    Mathf.Round((localHitPoint.x - gridOffset.x) / gridSize) * gridSize + gridOffset.x,
                    Mathf.Round((localHitPoint.y - gridOffset.y) / gridSize) * gridSize + gridOffset.y,
                    Mathf.Round((localHitPoint.z - gridOffset.z) / gridSize) * gridSize + gridOffset.z
                );
                
                tt.localPosition = gridPosition;
            }
        }
    }
}