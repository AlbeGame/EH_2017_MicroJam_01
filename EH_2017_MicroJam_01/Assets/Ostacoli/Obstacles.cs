using UnityEngine;

public class Obstacles : MonoBehaviour {

    public StatoDelBlob StatoRichiesto;
    public float Speed = 10f;

    private void Update()
    {
        transform.position -= Vector3.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player playR = other.GetComponent<Player>();

        if (playR == null)
            return;
        else
        {
            if (playR.State == StatoRichiesto)
                return;
            else
            {
                playR.Die();
                Destroy(this.gameObject);
            }
        }
    }
}
