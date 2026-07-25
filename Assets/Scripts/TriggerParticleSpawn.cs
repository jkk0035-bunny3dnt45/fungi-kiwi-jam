using UnityEngine;

public class TriggerParticleSpawn : MonoBehaviour
{
    // public string Tag = "Player";
    // public float spawnAreaHeight = 2f;
    // public float riseSpeed = 1.5f;
    // public float horizontalDrift = 0.3f;
    // public int particleCount = 30;
    // public float particleLifetime = 3f;
    // public float particleSize = 0.1f;
    // public float emissionRate = 10f;
    //
    // private ParticleSystem particleSystem;
    // private bool isEmitting;
    //
    // private void Awake()
    // {
    //     var go = new GameObject("TriggerParticles");
    //     go.transform.SetParent(transform);
    //     go.transform.localPosition = Vector3.zero;
    //
    //     particleSystem = go.AddComponent<ParticleSystem>();
    //     ConfigureParticleSystem();
    // }
    //
    // private void ConfigureParticleSystem()
    // {
    //     var main = particleSystem.main;
    //     main.duration = 999f;
    //     main.loop = true;
    //     main.startSpeed = riseSpeed;
    //     main.startSize = particleSize;
    //     main.startLifetime = particleLifetime;
    //     main.maxParticles = 1000;
    //     main.simulationSpace = ParticleSystemSimulationSpace.World;
    //     main.startColor = Color.red;
    //     main.emissionRate = emissionRate;
    //
    //     var emission = particleSystem.emission;
    //     emission.rateOverTime = emissionRate;
    //
    //     var shape = particleSystem.shape;
    //     shape.shapeType = ParticleSystemShapeType.Box;
    //     shape.scale = new Vector3(
    //         transform.localScale.x,
    //         spawnAreaHeight,
    //         transform.localScale.z
    //     );
    //     shape.position = Vector3.zero;
    //     shape.randomDirectionAmount = horizontalDrift;
    //
    //     var colorOverLifetime = particleSystem.colorOverLifetime;
    //     colorOverLifetime.enabled = true;
    //     Gradient gradient = new Gradient();
    //     gradient.SetKeys(
    //         new GradientColorKey[] {
    //             new GradientColorKey(Color.red, 0f),
    //             new GradientColorKey(Color.red, 1f)
    //         },
    //         new GradientAlphaKey[] {
    //             new GradientAlphaKey(1f, 0f),
    //             new GradientAlphaKey(0f, 1f)
    //         }
    //     );
    //     colorOverLifetime.color = gradient;
    //
    //     var noise = particleSystem.noise;
    //     noise.enabled = true;
    //     noise.strength = new Vector3(horizontalDrift, 0f, horizontalDrift);
    //     noise.frequency = 0.5f;
    //
    //     particleSystem.Stop();
    //     isEmitting = false;
    // }
    //
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag(Tag) && !isEmitting)
    //     {
    //         particleSystem.Play();
    //         isEmitting = true;
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.CompareTag(Tag) && isEmitting)
    //     {
    //         particleSystem.Stop();
    //         isEmitting = false;
    //     }
    // }
}
