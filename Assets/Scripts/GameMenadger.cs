using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pawnPrefab;
    public List<PawnScript> allPawns = new List<PawnScript>();

    // База данных для генерации уникальных имен
    private string[] firstNames = { "Иван", "Петр", "Сергей", "Алексей", "Михаил", "Дмитрий" };
    private string[] lastNames = { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов" };
    private string[] middleNames = { "Иванович", "Петрович", "Сергеевич", "Алексеевич", "Михайлович" };
    private string[] nicknames = { "Хмурый", "Быстрый", "Левша", "Док", "Проныра", "Трус" };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnNewPawn(new Vector3 (0,1,0));
        }
    }

    private void FixedUpdate()
    {
        for (int NumberPawn = 0; NumberPawn < allPawns.Count; NumberPawn++)
        {
            if (allPawns[NumberPawn].dead == true)
            {
                allPawns[NumberPawn].Destroy();
                allPawns.RemoveAt(NumberPawn);
            }
        }
    }

    public void SpawnNewPawn(Vector3 spawnPosition)
    {
        if (pawnPrefab == null) return;

        // 1. Спавним пешку из стандартного префаба
        GameObject newPawnObject = Instantiate(pawnPrefab, spawnPosition, Quaternion.identity);
        PawnScript pawnScript = newPawnObject.GetComponent<PawnScript>();

        if (pawnScript != null)
        {
            // 2. Генерируем случайное ИФО + Прозвище
            string fName = firstNames[Random.Range(0, firstNames.Length)];
            string lName = lastNames[Random.Range(0, lastNames.Length)];
            string mName = middleNames[Random.Range(0, middleNames.Length)];
            string nName = nicknames[Random.Range(0, nicknames.Length)];

            // Склеиваем в формат: Иванов Иван Иванович "Хмурый"
            string fullName = $"{lName} {fName} {mName} \"{nName}\"";

            // 3. Присваиваем имя объекту в Unity и переменной в скрипте
            newPawnObject.name = fullName; // Имя отобразится в окне Hierarchy
            pawnScript.pawnName = fullName; // Сохраняем в параметры пешки

            // 4. Добавляем в общий список
            allPawns.Add(pawnScript);

            Debug.Log($"Появился новый житель: {fullName}");
        }
    }
}
