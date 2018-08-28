using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager GetInstance;                                //单例

    public float sceneStartTimer = 10f;                                         //初始延迟-计时器
    public int currentWave = 0;                                                 //当前是第几波
    private int spawnPointCount;                                                //有多少个敌人刷新点
    private List<Transform> spawnPointTransform = new List<Transform>();        //敌人的刷新点
    public List<EnemyWave> enemyWaves = new List<EnemyWave>();                  //敌人的数据

    public bool sceneStart = false;                                             //场景开始了
    public bool isSpawn = false;                                                //这一波敌人刷完了
    public float waveEndTimer = 0f;                                             //每波敌人刷完之后-计时器
    public bool spawnFinish;                                                    //实例化怪物完毕
    public Material eliteMaterial;                                              //精英材质球
    public Material bossMaterial;                                               //首领材质球


    public GameObject downtownPortal;
    public GameObject sceneStartPoint;

    [System.Serializable]
    public class EnemyWave                              //每一波敌人
    {
        public EnemyPackage enemyPackage;               //每一波敌人有什么组成
        public float startDelay;                        //每一波敌人开始的等待时间
        public float endDelay;                          //每一波敌人刷完之后的等待时间
    }

    [System.Serializable]
    public class EnemyPackage                           //每一次的敌人
    {
        public bool haveElite;                          //有精英敌人(刷新的第一个怪物就是精英)
        public bool isBoss;                             //是首领敌人
        public EnemyData[] enemyData;                   //在其中随机抽取一种敌人
        private Transform spawnTransform;               //敌人刷新点Transform，随机抽取刷新点
        public float spawnInterval;                     //敌人刷新间隔
        public int amount;                              //这一波敌人的数量
    }

    [System.Serializable]                               //每一个敌人
    public class EnemyData
    {
        public GameObject enemyPrefab;                  //具体敌人
        public GameObject enemyPortal;                  //敌人传送门
    }

    void Awake()
    {
        GetInstance = this;                                                     //单例模式
        spawnPointCount = transform.childCount;                                 //有多少个怪物刷新点

        for (int i = 0; i < spawnPointCount; i++)
        {
            spawnPointTransform.Add(this.transform.GetChild(i));                //获得每一个子物体位置，也就是敌人刷新点的transform
        }
    }

    void Start()
    {
        //TODO 初始化 怪物种类之类													//在一个单例类的所有怪物列表里随机怪物


    }

    void Update()
    {
        if (!sceneStart)
        {
            sceneStartTimer -= Time.deltaTime;                                  //场景开始之前的计时器
            if (sceneStartTimer < 0)
            {
                sceneStart = true;
                StartCoroutine(SpawnAsync());                                   //开始刷怪
            }
        }
        else
        {
            if (!isSpawn)
            {
                waveEndTimer -= Time.deltaTime;                                 //每一波敌人刷完之后的计时器
            }
        }

        if (spawnFinish)
        {
            if (!SceneSetting.GetInstance.HaveEnemyAlive())
            {
                Debug.Log("Player Win");
                //玩家胜利

                //获得战利品

                //激活返回城镇的传送门（蓝色）
                Instantiate<GameObject>(downtownPortal, sceneStartPoint.transform.position, Quaternion.identity);
                Destroy(this);
            }
        }
    }

    IEnumerator SpawnAsync()//每一波敌人
    {
        yield return null;
        for (int i = 0; i < enemyWaves.Count; i++)
        {
            isSpawn = true;                                                                     //刷怪开始了
            currentWave++;                                                                      //波数增加
            EnemySpawnTimerUI.GetInstance.CountDown(enemyWaves[i].startDelay);                  //这波倒计时UI
            yield return new WaitForSeconds(enemyWaves[i].startDelay);                          //等待 - 每一波开始等待时间
            EnemySpawnWaringUI.GetInstance.ShowWarning(currentWave, enemyWaves.Count);          //这波敌人出现UI
            yield return StartCoroutine(SpawnEnemyAsync(i));                                    //这一波刷怪开始，直到这一波怪物全部刷完
            waveEndTimer = enemyWaves[i].endDelay;
            Debug.Log("Spawn Over");
            while ((!isSpawn && SceneSetting.GetInstance.HaveEnemyAlive()) && waveEndTimer >= 0)            //怪打完了 或者 时间到了 就刷下一波
            {
                Debug.Log("CoRoutine");
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("Finished One Wave");
        }
        Debug.Log("Finish All Waves");
        spawnFinish = true;
        Debug.Log("Spawn Over");

    }

    IEnumerator SpawnEnemyAsync(int index)//每一个敌人
    {
        yield return null;
        for (int i = 0; i < enemyWaves[index].enemyPackage.amount; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPointCount);                                                         //随机敌人刷新位置
            int spawnEnemyIndex = Random.Range(0, enemyWaves[index].enemyPackage.enemyData.Length);                         //随机敌人刷新类型
            GameObject tempPortal = Instantiate<GameObject>(enemyWaves[index].enemyPackage.enemyData[spawnEnemyIndex].enemyPortal,
            spawnPointTransform[spawnPointIndex].position, Quaternion.Euler(0f, Random.Range(0f, 360.0f), 0f));             //实例化传送门
            yield return new WaitForSeconds(1f);                                                                            //传送门等待
            GameObject tempEnemy = Instantiate<GameObject>(enemyWaves[index].enemyPackage.enemyData[spawnEnemyIndex].enemyPrefab,
            tempPortal.transform.position, tempPortal.transform.rotation);                                                  //在传送门的位置，实例化敌人
            tempEnemy.GetComponent<EnemyProperties>().level += SceneSetting.GetInstance.level;                              //设置等级增强
            tempEnemy.GetComponent<EnemyProperties>().LevelEnhance();                                                       //等级增强

            //精英
            if (enemyWaves[index].enemyPackage.haveElite && i == 0)
            {
                //第一个敌人是精英怪,由普通怪物升级
                tempEnemy.transform.localScale = 1.25f * tempEnemy.transform.localScale;                                    //1.25倍缩放
                tempEnemy.GetComponent<EnemyProperties>().enemyType = eEnemyType.Elite;                                     //改变敌人种类为精英
                tempEnemy.GetComponent<EnemyProperties>().EliteEnhance();                                                   //精英增强
                Renderer[] render = tempEnemy.GetComponentsInChildren<Renderer>();                                          //改变材质球颜色(发光)
                foreach (var item in render)
                {
                    Texture tex = item.material.mainTexture;
                    item.material = eliteMaterial;
                    item.material.mainTexture = tex;
                }
                tempEnemy.GetComponent<EnemyProperties>().healthBar.NameColor = Color.red;                                  //血条UI改进
                tempEnemy.GetComponent<EnemyProperties>().healthBar.NameFontSize += 2;
            }

            //BOSS首领
            if (enemyWaves[index].enemyPackage.isBoss)
            {
                Renderer[] render = tempEnemy.GetComponentsInChildren<Renderer>();                                          //改变材质球颜色(发光)
                foreach (var item in render)
                {
                    Texture tex = item.material.mainTexture;
                    item.material = bossMaterial;
                    item.material.mainTexture = tex;
                }
                tempEnemy.GetComponent<EnemyProperties>().healthBar.NameColor = Color.red;      //new Color(1f,0.85f,0f,1f);//血条UI改进
                tempEnemy.GetComponent<EnemyProperties>().healthBar.NameFontSize += 4;
            }

            tempEnemy.GetComponent<EnemyProperties>().Reset();
            tempEnemy.GetComponent<EnemyProperties>().RefreshUI();                                                          //刷新UI

            yield return new WaitForSeconds(enemyWaves[index].enemyPackage.spawnInterval);                                  //等待下一个敌人
        }
        isSpawn = false;
    }
}
