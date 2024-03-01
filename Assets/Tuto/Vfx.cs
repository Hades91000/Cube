using UnityEngine;

public class CubeFallAndSpawnVFX : MonoBehaviour
{
    public GameObject vfxPrefab;  // Le préfab du VFX à apparaitre
    private bool hasTouchedGround = false;  // Pour garder une trace si le cube a touché le sol

    void Update()
    {
        // Vérifie si le cube n'a pas encore touché le sol
        if (!hasTouchedGround)
        {
            // Déplace le cube vers le bas
            transform.Translate(Vector3.down * Time.deltaTime);

            // Si le cube touche le sol (lorsque sa position Y est inférieure ou égale à 0)
            if (transform.position.y <= 0f)
            {
                hasTouchedGround = true;  // Marque le cube comme ayant touché le sol
                SpawnVFX();  // Appelle la fonction pour créer le VFX
            }
        }
    }

    void SpawnVFX()
    {
        // Crée le VFX à la position du cube
        GameObject vfx = Instantiate(vfxPrefab, transform.position, Quaternion.identity);

        // Détruit le VFX après un certain délai (par exemple, la durée de vie du VFX)
        Destroy(vfx, vfx.GetComponent<ParticleSystem>().main.duration);

        // Détruit le cube après avoir déclenché le VFX
        Destroy(gameObject);
    }
}
