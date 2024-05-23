using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private NavMeshAgent agentPlayer;
    private Ray lastRay;

    // Start is called before the first frame update
    void Start()
    {
        agentPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }

    }

    private void MoveToCursor()
    {
        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(lastRay.origin, lastRay.direction * 100, Color.red, 5);

        RaycastHit hit;
        var hasHit = Physics.Raycast(lastRay, out hit);

        if (hasHit)
        {
            agentPlayer.SetDestination(hit.point);
        }
    }
}
