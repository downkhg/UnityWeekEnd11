using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject player;
    public float Time;
    public bool isRespon;
    public string prefabsName;

    IEnumerator ProcessTimmer()
    {
        isRespon = true;
        Debug.Log("ProcessTimmer 1");
        yield return new WaitForSeconds(Time);
        GameObject prefabPlayer =
               Resources.Load("Prefabs/"+ prefabsName) as GameObject;

        player = Instantiate(prefabPlayer);
        player.name = prefabsName;
        player.transform.position = this.transform.position;
        Debug.Log("ProcessTimmer 2");
        isRespon = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        prefabsName = player.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null && isRespon == false)
        {
            StartCoroutine(ProcessTimmer());
        }
    }
}
