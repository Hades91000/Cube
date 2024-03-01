using UnityEngine;

public class TriggerSpawnVFX : MonoBehaviour
{
    public GameObject vfxPrefab;  // Le préfab du VFX à apparaitre
    private bool cubeInside = false;  // Garde une trace si un objet avec le tag "Cube" est à l'intérieur du trigger

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Cube"
        if (other.CompareTag("Cube"))
        {
            cubeInside = true;  // Marque qu'un objet "Cube" est à l'intérieur du trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Vérifie si l'objet sortant a le tag "Cube"
        if (other.CompareTag("Cube"))
        {
            cubeInside = false;  // Marque qu'aucun objet "Cube" n'est à l'intérieur du trigger
        }
    }

    private void Update()
    {
        // Si un objet "Cube" est à l'intérieur du trigger et qu'il n'y a pas déjà de VFX
        if (cubeInside && !HasVFX())
        {
            // Crée le VFX à la position du trigger
            GameObject vfx = Instantiate(vfxPrefab, transform.position, Quaternion.identity);

            // Détruit le VFX après un certain délai (par exemple, la durée de vie du VFX)
            Destroy(vfx, vfx.GetComponent<ParticleSystem>().main.duration);
        }
    }

    // Vérifie s'il y a déjà un VFX dans le trigger
    private bool HasVFX()
    {
        return transform.childCount > 0;
    }
}
