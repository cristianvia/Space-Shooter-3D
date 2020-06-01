using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoresTest 
{
    //ScoresCollection scoresCollection1, scoresCollection2;
    string rootFolder = Application.dataPath; //El test solo funciona en el editor asi que no hace falta gestionar para otras plataformas
    string xml = "UnitTest.xml";
    [Test]
    public void scores_Test()
    {
        //Creamos scores
        Score s0 = new Score("Player0", 0);
        Score s1 = new Score("Player1", 1);
        Score s2 = new Score("Player2", 2);
        List<Score> scores1 = new List<Score>();
        ScoresCollection scoresCollection = new ScoresCollection();

        //Los añadimos a scoresCollection1
        scoresCollection.scores.Add(s0);
        scoresCollection.scores.Add(s1);
        scoresCollection.scores.Add(s2);

        //Lo guardamos en la ruta RootFolder y en el fichero scores.xml
        scoresCollection.Save(Path.Combine(rootFolder, xml));
        //Cargamos lo que acabamos de guardar en scores1
        scores1 = ScoresCollection.Load(Path.Combine(rootFolder, xml)).scores;

        //Por cada instancia en socresCollection.scores comprobamos si coincide con scores1 su valor y su nombre
        int index = 0;
        foreach(Score s in scoresCollection.scores)
        {
            Assert.That(scores1[index].value, Is.EqualTo(s.value));
            Assert.That(scores1[index].name, Is.EqualTo(s.name));
            index++;
        }
    }
}
