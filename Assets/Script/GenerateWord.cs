using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public interface IGenWord
{
    string GeneratingWord(int wordLength);
}
public class GenerateWord : IGenWord
{
    static Dictionary<int,List<string>> sortedWord = new Dictionary<int, List<string>>();
    public class WordData
    {
        public int length { get; set; }
        public List<string> word { get; set; }
    }
    private TextAsset textFile;
    public string GeneratingWord(int wordLength)
    {
        textFile = Resources.Load<TextAsset>("WordData");

        var wordDataBase = new StringReader(textFile.text);

        var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        var wordData = deserializer.Deserialize<WordData[]>(wordDataBase);

        for (int i = 0;i < wordData.Length;i++)
        {
            if(!sortedWord.ContainsKey(wordData[i].length))
            {
                sortedWord.Add(wordData[i].length,new List<string>());
            }
            foreach (var item in wordData[i].word)
            {
                if(!sortedWord[wordData[i].length].Contains(item))
                {
                    sortedWord[wordData[i].length].Add(item);
                }
            }
        }

        string word = sortedWord[wordLength][Random.Range(0,sortedWord[wordLength].Count)];
        return word;
    }
}
