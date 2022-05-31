using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour
{
    private GameObject unitychan;
    //private UnityChanController getspeed;

    public List<int> spacez = new List<int>() { };

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //getspeed = unitychan.GetComponent<UnityChanController>();
       for (int i = startPos ; i < goalPos; i += 15)
        {
            spacez.Add(i);
        }

    }


    // Update is called once per frame
    void Update()
    {


        
        //for(int i = startPos; i < goalPos; i += 15)
        for(int k=0;k<spacez.Count;k++)
        {

            //どのアイテムを出すのかをランダムに設定
            //if (spacez[k] >= unitychan.transform.position.z + 40 && spacez[k] <= unitychan.transform.position.z + 40.3f)
            //if (spacez[k] == unitychan.transform.position.z + 40)
            //if (spacez[k] == (getspeed.velocityZ * Time.deltaTime) + 40f)
            //if (unitychan.transform.position.z + 40 >= i)
            if (unitychan.transform.position.z + 40 >= spacez[k] )
            {
                
                int num = Random.Range(1, 11);
                    if (num <= 2)
                    {
                        //コーンをx軸方向に一直線に生成
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, spacez[k]);
                        }
                    }
                    else
                    {

                        //レーンごとにアイテムを生成
                        for (int j = -1; j <= 1; j++)
                        {
                            //アイテムの種類を決める
                            int item = Random.Range(1, 11);
                            //アイテムを置くZ座標のオフセットをランダムに設定
                            int offsetZ = Random.Range(-5, 6);
                            //60%コイン配置:30%車配置:10%何もなし
                            if (1 <= item && item <= 6)
                            {
                                //コインを生成
                                GameObject coin = Instantiate(coinPrefab);
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, spacez[k] + offsetZ);
                            }
                            else if (7 <= item && item <= 9)
                            {
                                //車を生成
                                GameObject car = Instantiate(carPrefab);
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, spacez[k] + offsetZ);
                            }
                        }
                    }
                spacez.RemoveAt(0);
            }
        }
    }
}