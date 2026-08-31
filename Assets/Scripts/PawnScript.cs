using UnityEngine;

public class PawnScript : MonoBehaviour
{
    public string pawnName;

    [Header("желудок")]
    public int maxMassa = 2000;//максимальная масса которую выдерживает желудок
    public int coloriesMass = 100;//масса сухой части
    public int coloriesInGramm = 5;//калории в одном грамме
    public int waterInEat = 300;//масса воды

    [Header("запассы")]
    public int waterMass = 56000;//масса воды в тканях
    public int caloriesInFat = 90000;//калории в жире

    [Header("рассход")]
    public int needWater = 3;//расход воды
    public int needCalories = 3;//расход колорий

    [Header("тело")]
    bool men = true;
    public int fleshMassa = 14000;//масса плоти
    public int bloodMassa = 5200;//масса крови
    public int temperature = 36600;//темпера
    int minNeedWater = 4;//минимальный расход воды
    int minNeedColories = 4;//минимальный рассход калорий

    [Header("нужды")]
    public int hunger = 0;//голод
    public int thirst = 0;//жажда

    [Header("Менталка")]
    public int anger = 0;//злость
    public int anguish = 0;//боль
    public int huppiness = 30;//счастье

    public bool dead = false;

    int tiks;

    void FixedUpdate()
    {
        tiks++;

        if (tiks >= 0.5f / Time.fixedDeltaTime)
        {
            Expenditure();
            UpdateNeeds();
        }
    }

    void Expenditure()
    {   
        if (men == true)
        {
            minNeedWater = 4;
            minNeedColories = 4;
        }
        else
        {
            minNeedWater = 3;
            minNeedColories = 3;
        }

        if (temperature < 35000)
        {
            needWater = minNeedWater;
            needCalories = minNeedColories + (35000 - temperature) / 300;
        }
        else if (temperature >= 35000 && temperature <= 37000)
        {
            needWater = minNeedWater;
            needCalories = minNeedColories;
        }
        else if (temperature > 37000)
        {
            needWater = minNeedWater + (temperature - 37000) / 3000;
            needCalories = minNeedColories;
        }

            if (coloriesMass > 0)
            {
                coloriesMass--;
                caloriesInFat += coloriesInGramm - needCalories;
                waterMass -= needWater;
                waterMass += waterInEat;
                waterInEat = 0;
            }
            else if (coloriesMass <= 0)
            {
                caloriesInFat -= needCalories;
            }

            tiks = 0;
    }

    void UpdateNeeds()
    {
        if (coloriesMass + waterInEat <= 0)
        {
            hunger++;
        }
        if (waterInEat < (fleshMassa + caloriesInFat/9000)/0.3)
        {

        }
    }

    void Mental()
    {

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
