using System;
using UnityEngine;

public class QuestCompl : MonoBehaviour
{
    public QuestGiver _questGiver;
    public Stats _stats;
    
    
    //! PROVERKA VIPOLNENYA QUESTS
    private void Update()
    {
       if (_questGiver.checkQuestEnd && !_questGiver.notcompl && _questGiver._quest >= 2)
       {
           _stats.Money += _questGiver.congr;
           _questGiver.notcompl = true;
       }
    }

    //! TRIGGER NA CAR DLYA QUEST
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Car")
        {
            if (gameObject.name == "PointQ1")
            {
                _stats.Money += _questGiver.congr;
                _questGiver.checkQuest = false;
                _questGiver.checkQuestEnd = true;
            }
            if (gameObject.name == "PointQ3")
            {
                _questGiver.stepQuest = true;
            }

            if (gameObject.name == "PointQ3.1")
            {
                _stats.Money += _questGiver.congr;
                _questGiver.checkQuest = false;
                _questGiver.stepQuest = false;
                _questGiver.checkQuestEnd = true;
            }
            
            if (gameObject.name == "PointQ4")
            {
                _questGiver.stepQuest = true;
            }
            if (gameObject.name == "PointQ4.1")
            {
                _questGiver.stepQuest = true;
                _stats.Money += _questGiver.congr;
                _questGiver.checkQuest = false;
                _questGiver.checkQuestEnd = true;
            }
        }
    }
}
