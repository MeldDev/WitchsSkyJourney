using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class Localization : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset _englishFont;
    [SerializeField] private TMP_FontAsset _russianFont;
    [SerializeField] private TMP_FontAsset _ukraineFont;
    [SerializeField] private LanguageList _language;
    public delegate void LocalizationDelegate();
    public LocalizationDelegate localizationDelegate;

    Dictionary<string, string[]> _stringDictionary = new Dictionary<string, string[]>()
    {
        {"QUALITY", new string[]{ "QUALITY", "Качество", "Якiсть" } },
        {"LOW", new string[]{ "LOW", "Низкое", "Низьке" } },
        {"MEDIUM", new string[]{ "MEDIUM", "Среднее", "Середнє" } },
        {"HIGH", new string[]{ "HIGH", "Высокое", "Висока" } },
        {"Frame frequency", new string[]{ "Frame frequency", "Частота кадров", "Частота кадрiв" } },
        {"SHOW FPS COUNTER", new string[]{ "SHOW FPS COUNTER", "Счетчик кадров", "Лiчильник кадрiв" } },
        {"Language", new string[]{ "Language", "Язык", "Мова" }},
        {"MORE GAMES", new string[]{ "MORE GAMES", "БОЛЬШЕ ИГР", "БIЛЬШЕ IГР" }},
        {"Save Settings", new string[]{ "Save Settings", "Сохранить настройки", "Зберегти налаштування" }},
        {"Information", new string[]{ "Information", "Информация", "Iнформацiя" }},
        {"YOU LOSE", new string[]{ "YOU\nLOSE", "ВЫ\nПРОИГРАЛИ", "ВИ\nПРОГРАЛИ" }},
        {"SKIP", new string[]{ "SKIP", "ПРОПУСТИТЬ", "ПРОПУСТИТИ" }},
        {"watch ad to revive?", new string[]{ "watch ad to revive?", "посмотреть рекламу, чтобы продолжить?", "подивитися рекламу, щоб продовжити?" }},
        {"MAX DISTANCE", new string[]{ "MAX DISTANCE", "МАКСИМАЛЬНОЕ РАССТОЯНИЕ", "МАКСИМАЛЬНА ВІДСТАНЬ" }},
        {"TAP TO PLAY", new string[]{ "TAP TO\nPLAY", "Нажмите\nчтобы\nиграть", "Клацнiть\nщоб грати" }},
        {"TAP TO RESUME", new string[]{ "TAP TO\nRESUME", "Нажмите\nчтобы\nпродолжить", "Клацнiть\nщоб грати" }}
    };

    public enum LanguageList
    {
        English,
        Russian,
        Ukraine
    }
    public void SetLanguage(int lang)
    {
        _language = (LanguageList)lang;
        localizationDelegate?.Invoke();
    }
    public int GetLanguage()
    {
        return (int)Enum.Parse(typeof(LanguageList), _language.ToString());
    }

    public Tuple<TMP_FontAsset, string> GetLocalization(string key)
    {
        switch (_language)
        {
            case LanguageList.English: return Tuple.Create(_englishFont, _stringDictionary[key][(int)_language]);
            case LanguageList.Russian: return Tuple.Create(_russianFont, _stringDictionary[key][(int)_language]);
            case LanguageList.Ukraine: return Tuple.Create(_ukraineFont, _stringDictionary[key][(int)_language]);
            default: return Tuple.Create(_englishFont, _stringDictionary[key][(int)_language]);
        }
    }

    public string GetLocalizationFromKey(string key)
    {
        return _stringDictionary[key][(int)_language];
    }
}