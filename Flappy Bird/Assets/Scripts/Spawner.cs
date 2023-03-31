using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1.5f;
    public float maxHeight = 1.5f;

    private void OnEnable()                                     //özel durumlarda tekrarlaması gibi, misal ölünce duracak
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {                                                                                //objeyi klonlamak için "Instantiate" kullanıyoruz  
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);    //Quaternion.identity --> rotation yok
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
