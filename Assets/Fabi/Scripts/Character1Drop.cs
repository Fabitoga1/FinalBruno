using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character1Drop : MonoBehaviour
{
    static public Character1Drop instance { get; set; }

    void Awake()
    {
        instance = this;
    }

    public GameObject theCharacter;
    public int xPos;
    public int zPos;
    public int CharacterCount;
    public bool original = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (!original) return;
        StartCoroutine(CharacterDrop());
    }

    IEnumerator CharacterDrop()
    {
        for (int i = 0; i < CharacterCount; ++i)
        {
            InstantiateCharacter();
            yield return new WaitForSeconds(0.1f);
            

        }
    }

    public void InstantiateCharacter()
    {
        xPos = Random.Range(-7, 1);//-0.02, 0.01
        zPos = Random.Range(-4, 0); //-0.01, 0.01
        float y = 0.589f;
        Instantiate(theCharacter, new Vector3(xPos, y, zPos), Quaternion.identity); //-0.058
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
