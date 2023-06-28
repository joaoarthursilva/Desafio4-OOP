using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUpCotroller : MonoBehaviour
{
    private TextMeshPro text;
    public static GameController gameController;
    private Color textColor;
    private float disapearTimer;

    public static DamagePopUpCotroller Create(Transform damagePopUp, Vector3 position, int damage)
    {

        Transform damagePopUpTransform = Instantiate(damagePopUp, position, Quaternion.identity);
        DamagePopUpCotroller damagePopUpController = damagePopUpTransform.GetComponent<DamagePopUpCotroller>();
        damagePopUpController.Setup(damage);

        return damagePopUpController;
    }

    private void Awake()
    {
        text = transform.GetComponent<TextMeshPro>();
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(int damage)
    {
        text.SetText(damage.ToString());
        textColor = text.color;
        disapearTimer = 1f;
    }

    private void Update()
    {
        float moveSpeed = 20f;
        transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;

        disapearTimer -= Time.deltaTime;
        if (disapearTimer < 0)
        {
            float disapearSpeed = 3f;
            textColor.a -= disapearSpeed * Time.deltaTime;
            text.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
