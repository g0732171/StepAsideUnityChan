using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour
{


    private GameObject unitychan;
    //private GameObject maincam;

    float interval;
    

    float timer = 0;

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

      

        //UnityChanに設定された速度により15m間隔に必要な時間を計算
        UnityChanController getvelocityZ = new UnityChanController();
        interval = 15 / getvelocityZ.velocityZ;

    }

    // Update is called once per frame
    void Update()
    {
        int num = Random.Range(1, 11);

        //時間を測り、時間が間隔以上になるとアイテム生成を行う。同時にタイマーをリセットする。
        timer += Time.deltaTime;
            if (timer >=interval && (unitychan.transform.position.z + 40f)< goalPos)
            {
            //Debug.Log(timer);
            //Debug.Log(interval);
            timer = 0;


            //どのアイテムを出すのかをランダムに設定
            
                    if (num <= 2)
                    {
                        //コーンをx軸方向に一直線に生成
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, (unitychan.transform.position.z + 40f));
    
                
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
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, (unitychan.transform.position.z + 40f + offsetZ));


  
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, (unitychan.transform.position.z + 40f + offsetZ));

                    }

                　　　　　}
                    }


  

            }
        
    
    }


}
