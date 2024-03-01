using UnityEngine;

public class CubeFallAndSpawnVFX : MonoBehaviour
{
    public GameObject vfxPrefab;  // Le pr�fab du VFX � apparaitre
    private bool hasTouchedGround = false;  // Pour garder une trace si le cube a touch� le sol

    void Update()
    {
        // V�rifie si le cube n'a pas encore touch� le sol
        if (!hasTouchedGround)
        {
            // D�place le cube vers le bas
            transform.Translate(Vector3.down * Time.deltaTime);

            // Si le cube touche le sol (lorsque sa position Y est inf�rieure ou �gale � 0)
            if (transform.position.y <= 0f)
            {
                hasTouchedGround = true;  // Marque le cube comme ayant touch� le sol
                SpawnVFX();  // Appelle la fonction pour cr�er le VFX
            }
        }
    }

    void SpawnVFX()
    {
        // Cr�e le VFX � la position du cube
        GameObject vfx = Instantiate(vfxPrefab, transform.position, Quaternion.identity);

        // D�truit le VFX apr�s un certain d�lai (par exemple, la dur�e de vie du VFX)
        Destroy(vfx, vfx.GetComponent<ParticleSystem>().main.duration);

        // D�truit le cube apr�s avoir d�clench� le VFX
        Destroy(gameObject);
    }
}
