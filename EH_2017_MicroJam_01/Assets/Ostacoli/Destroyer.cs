using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int AvoidedObstacles = 0;
    public TextMesh text;

    private void OnTriggerEnter(Collider other)
    {
        Obstacles obstcl = other.GetComponent<Obstacles>();

        if (obstcl != null)
        {
            AvoidedObstacles++;
            if (text)
                text.text = "Evitati: " + AvoidedObstacles;
        }

        Destroy(other.gameObject);
        Debug.Log(AvoidedObstacles);
    }
}
