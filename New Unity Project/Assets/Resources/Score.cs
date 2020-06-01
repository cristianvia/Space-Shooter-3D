using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Score
{
    //[XmlAttribute("level")]
    //public int level;

    [XmlAttribute("name")]
    public string name;
    [XmlAttribute("value")]
    public float value;

    public Score (String name, float value)
    {
        this.name = name;
        this.value = value;
    }
    public Score() { }
}

