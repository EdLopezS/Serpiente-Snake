using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SerpienteMovimiento : MonoBehaviour
{
    private Vector2 ubic = Vector2.right;
    private List<Transform> _colita;
    public Transform colitaPrefab;

    int puntos = 10;
    TextMeshProUGUI Puntos;

    private void Start()
    {
        _colita = new List<Transform>();
        _colita.Add(this.transform);

        Puntos = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        puntos = PlayerPrefs.GetInt("puntos");
        Puntos.text = "Puntos: " + this.puntos.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            ubic = Vector2.up;
        }else if(Input.GetKeyDown(KeyCode.S)){
            ubic = Vector2.down;
        }else if(Input.GetKeyDown(KeyCode.A)){
            ubic = Vector2.left;
        }else if(Input.GetKeyDown(KeyCode.D)){
            ubic = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for(int i = _colita.Count - 1; i > 0; i--)
        {
            _colita[i].position = _colita[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + ubic.x,
            Mathf.Round(this.transform.position.y) + ubic.y,
            0.0f
        );
    }

    private void Agregar()
    {
        Transform segment = Instantiate(this.colitaPrefab);
        segment.position = _colita[_colita.Count - 1].position;

        _colita.Add(segment);

    }

    private void Reinicio()
    {
        for(int i = 1; i < _colita.Count; i++){
            Destroy(_colita[i].gameObject);
        }

        _colita.Clear();
        _colita.Add(this.transform);
        this.puntos = 0;
        Puntos.text = "Puntos: " + this.puntos.ToString();

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Manzana")
        {
            int puntos = collision.gameObject.GetComponent<Puntos>().puntos;
            this.puntos += puntos;
            Puntos.text = "Puntos: " + this.puntos.ToString();
            Agregar();
        }else if (collision.tag == "Muro")
        {
            Reinicio();
        }
    }
}
