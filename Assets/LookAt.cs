using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
    public Camera cameraToLookAt;
    public static Quaternion m_InitRotation;
    void Start()
    {
       // m_InitRotation = cameraToLookAt.rotation;
        //m_InitRotation = Quaternion.Inverse(m_InitRotation);
    }

    void FixedUpdate()
    {
        //transform.rotation = new Quaternion(0.0f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
       
        transform.rotation = m_InitRotation;
    }

    void Update()
    {
        Vector3 delta = cameraToLookAt.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(-cameraToLookAt.transform.forward) ;
        
    }
}