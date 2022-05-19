using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//! SYSTEMA SOXRANENYA PROGRESSA 
public class SaveSysten : MonoBehaviour
{
   public float x, y, z, ry;
   public Transform player;
   public Stats _stats;
   public QuestGiver _questGiver;
   public DonDestroyOnLoAD _donDestroy;
   public Image _iconSave;
   public float kd = 5;
   public bool savecheck;
   private void Awake()
   {
      kd = 5;
      if (GameObject.Find("Car"))
      {
         player = GameObject.Find("Car").transform;
      }
      else
      {
         return;
      }
      _donDestroy = DonDestroyOnLoAD.instance;
      _stats = GetComponent<Stats>();
      if (PlayerPrefs.GetInt("FirstSave") == 0)
      {
         FirstSave();
      }
      StartCoroutine(AutoSave());
      load();
   }

   private void Update()
   {
      if(GameObject.Find("Car"))
         player = GameObject.Find("Car").transform;

      if (savecheck)
      {
         _iconSave.gameObject.SetActive(true);
         kd -= Time.deltaTime;
         _iconSave.gameObject.SetActive(false);
         kd = 5;
      }
   }

   public void save()
   {
      savePos();
      PlayerPrefs.SetFloat("x",x);
      PlayerPrefs.SetFloat("y",y);
      PlayerPrefs.SetFloat("z",z);
      PlayerPrefs.SetFloat("Fuel",_stats.CurrentFuel);
      PlayerPrefs.SetFloat("Money",_stats.Money);
      PlayerPrefs.SetInt("Car1",_donDestroy.checkCar);
      PlayerPrefs.SetInt("Quest",_questGiver._quest);
      PlayerPrefs.Save();
   }

   public void saveGarage()
   {
      savePos();
      PlayerPrefs.SetFloat("x",x);
      PlayerPrefs.SetFloat("y",y);
      PlayerPrefs.SetFloat("z",z+5f);
      PlayerPrefs.SetFloat("Fuel",_stats.CurrentFuel);
      PlayerPrefs.SetFloat("Money",_stats.Money);
      PlayerPrefs.SetInt("Car1",_donDestroy.checkCar);
      PlayerPrefs.SetInt("Quest",_questGiver._quest);
      PlayerPrefs.SetFloat("ry",ry);
      PlayerPrefs.Save();
   }
   public void load()
   {
      if (PlayerPrefs.HasKey("x"))
      {
         x = PlayerPrefs.GetFloat("x");
      }
      if (PlayerPrefs.HasKey("y"))
      {
         y = PlayerPrefs.GetFloat("y");
      }
      if (PlayerPrefs.HasKey("z"))
      {
         z = PlayerPrefs.GetFloat("z");
      }
      _stats.CurrentFuel = PlayerPrefs.GetFloat("Fuel");
      _stats.Money = PlayerPrefs.GetFloat("Money");
      _questGiver._quest = PlayerPrefs.GetInt("Quest");
   }
   IEnumerator AutoSave()
   {
      yield return new WaitForSeconds(300);
      save();
      StartCoroutine(AutoSave());
   }

   public void savePos()
   {
      x = player.transform.position.x;
      y = player.transform.position.y;
      z = player.transform.position.z;
      ry = player.transform.rotation.y;
   }

   public void FirstSave()
   {
      x = -45.34f;
      y = 41.86f;
      z = -137.45f;
      ry = 90;
      PlayerPrefs.SetFloat("ry",ry);
      PlayerPrefs.SetFloat("x",x);
      PlayerPrefs.SetFloat("y",y);
      PlayerPrefs.SetFloat("z",z);
      PlayerPrefs.SetFloat("Fuel",1f);
      PlayerPrefs.SetFloat("Money",500);
      PlayerPrefs.SetInt("Car1",_donDestroy.checkCar);
      PlayerPrefs.SetInt("CurrentCar",0);
      PlayerPrefs.SetInt("Quest",1);
      PlayerPrefs.SetFloat("TimerQ",600);
      PlayerPrefs.SetInt("tut",0);
      PlayerPrefs.Save();
      _donDestroy.FirstSaveCompl();
   }
}
