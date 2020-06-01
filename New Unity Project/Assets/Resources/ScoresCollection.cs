using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

// https://forum.unity.com/threads/saving-and-loading-data-xmlserializer.85925/

[XmlRoot("ScoreCollection")]
//public class Scores : MonoBehaviour
public class ScoresCollection 
{
    [XmlArray("scores"), XmlArrayItem("score")]
    //public Score[] scores;
    public List<Score> scores = new List<Score>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ScoresCollection));

        Debug.Log(path);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
    public ScoresCollection() { }
    public static ScoresCollection Load(string path)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(ScoresCollection));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as ScoresCollection;
            }
        }
        catch (Exception e)
        {
            //Esto puede passar si aun no existe el fichero y así evitamos que el codigo deje de ejecutarse
            Debug.LogError("Error: " + e);
            return new ScoresCollection();
        }

    }
    override
    public string ToString()
    {
        string myContent = "";
        foreach(Score s in scores)
        {
            myContent += s.name + ": " + s.value + "\n";
        }
        return myContent;
    }
}
