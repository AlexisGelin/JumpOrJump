using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private string nameOfItem;

    [SerializeField]
    private RuntimeAnimatorController animOfTheItem;

    [SerializeField]
    private int price;

    [SerializeField]
    private Image imageBackground;

    [SerializeField]
    private GameObject textAcquis;

    [SerializeField]
    private GameObject textPrice;
    void Start()
    {
        if (PlayerPrefs.GetString("skin") == nameOfItem)
        {
            changePlayerAnimator();
        }


        if (GameManager.skin == nameOfItem)
        {
            imageBackground.color = Color.white;
        }

        if (PlayerPrefs.GetInt("skin" + name) == 1)
        {
            textPrice.SetActive(false);
            textAcquis.SetActive(true);
        }



    }

    public void buyPlayerAnimator()
    {
        if (GameManager.money >= price && PlayerPrefs.GetInt("skin" + name) == 0) // buy product
        {
            GameManager.money -= price;
            PlayerPrefs.SetInt("Money", GameManager.money);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Animator animPlayer = player.GetComponent<Animator>();
            animPlayer.runtimeAnimatorController = animOfTheItem;
            GameManager.skin = nameOfItem;

            //change color
            GameObject[] items = GameObject.FindGameObjectsWithTag("ItemShop");
            foreach (GameObject item in items)
            {
                Image imgitem = item.GetComponent<Image>();
                imgitem.color = new Color(0.525f, 0.643f, 0.717f);
            }
            imageBackground.color = Color.white;

            PlayerPrefs.SetString("skin", nameOfItem);

            if (PlayerPrefs.GetInt("skin" + name) == 0)
            {
                PlayerPrefs.SetInt("skin"+ name, 1);
                textPrice.SetActive(false);
                textAcquis.SetActive(true);
            }

        } 
        if (PlayerPrefs.GetInt("skin" + name) == 1)
        {
            changePlayerAnimator();
        }

    }

    public void changePlayerAnimator()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator animPlayer = player.GetComponent<Animator>();
        animPlayer.runtimeAnimatorController = animOfTheItem;
        GameManager.skin = nameOfItem;

        //change color
        GameObject[] items = GameObject.FindGameObjectsWithTag("ItemShop");
        foreach (GameObject item in items)
        {
            Image imgitem = item.GetComponent<Image>();
            imgitem.color = new Color(0.525f, 0.643f, 0.717f);
        }
        imageBackground.color = Color.white;

        PlayerPrefs.SetString("skin", nameOfItem);
    }
}
