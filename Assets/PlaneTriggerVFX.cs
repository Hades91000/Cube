using UnityEngine;

public class TriggerSpawnVFX : MonoBehaviour
{
    public GameObject vfxPrefab;  // Le pr�fab du VFX � apparaitre
    private bool cubeInside = false;  // Garde une trace si un objet avec le tag "Cube" est � l'int�rieur du trigger

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant a le tag "Cube"
        if (other.CompareTag("Cube"))
        {
            cubeInside = true;  // Marque qu'un objet "Cube" est � l'int�rieur du trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // V�rifie si l'objet sortant a le tag "Cube"
        if (other.CompareTag("Cube"))
        {
            cubeInside = false;  // Marque qu'aucun objet "Cube" n'est � l'int�rieur du trigger
        }
    }

    private void Update()
    {
        // Si un objet "Cube" est � l'int�rieur du trigger et qu'il n'y a pas d�j� de VFX
        if (cubeInside && !HasVFX())
        {
            // Cr�e le VFX � la position du trigger
            GameObject vfx = Instantiate(vfxPrefab, transform.position, Quaternion.identity);

            // D�truit le VFX apr�s un certain d�lai (par exemple, la dur�e de vie du VFX)
            Destroy(vfx, vfx.GetComponent<ParticleSystem>().main.duration);
        }
    }

    // V�rifie s'il y a d�j� un VFX dans le trigger
    private bool HasVFX()
    {
        return transform.childCount > 0;
    }
}
