using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest
{
    //USERNAME,MUTE;VOLUME;LEVEL
    [Test]
    public void Initializer_Test()
    {
        PlayerPrefsManager.initialize();
        float volume = PlayerPrefsManager.getVolume();
        int mute = PlayerPrefsManager.getMute();
        int level = PlayerPrefsManager.getLevel();
        string userName = PlayerPrefsManager.getUserName();
        //string userName2 = null; // De activar esta  y la linea 24 saldria erroneo el test Initializer_Test
        //Assert.That(___, Is.EqualTo(expected));
        Assert.IsNotNull(volume);
        Assert.IsNotNull(mute);
        Assert.IsNotNull(level);
        Assert.IsNotNull(userName);
        //Assert.IsNotNull(userName2);
    }
    [Test]
    public void SetVolume_Test()
    {
        PlayerPrefsManager.initialize();
        float previousVolume = PlayerPrefsManager.getVolume();
        float volumeToHalf = 0.5f;
        float volumeToZero = 0f;

        //Lo comprovamos con dos valores por si se diera el caso de que previousVolume coincidiera con uno de ellos ya de base
        PlayerPrefsManager.setVolume(volumeToHalf);
        Assert.That(PlayerPrefsManager.getVolume, Is.EqualTo(volumeToHalf));

        PlayerPrefsManager.setVolume(volumeToZero);
        Assert.That(PlayerPrefsManager.getVolume, Is.EqualTo(volumeToZero));

        //Volvemos a dejarlo como estaba para no afectar al jugador
        PlayerPrefsManager.setVolume(previousVolume);
        Assert.That(PlayerPrefsManager.getVolume, Is.EqualTo(previousVolume));
    }
    [Test]
    public void SetMute_Test()
    {
        PlayerPrefsManager.initialize();
        int previousMute = PlayerPrefsManager.getMute();
        int muteTrue = 1;
        int muteFalse = 0;

        //Comprovamos que de base sea o 0 o 1, y ningun valor negativo o superior
        Assert.That(PlayerPrefsManager.getMute, Is.InRange(muteFalse, muteTrue));
        //Lo comprovamos con dos valores por si se diera el caso de que previousMute coincidiera con uno de ellos ya de base
        PlayerPrefsManager.setMute(muteTrue);
        Assert.That(PlayerPrefsManager.getMute, Is.EqualTo(muteTrue));

        PlayerPrefsManager.setMute(muteFalse);
        Assert.That(PlayerPrefsManager.getMute, Is.EqualTo(muteFalse));

        //Volvemos a dejarlo como estaba para no afectar al jugador
        PlayerPrefsManager.setMute(previousMute);
        Assert.That(PlayerPrefsManager.getMute, Is.EqualTo(previousMute));
    }
    [Test]
    public void SetLevel_Test()
    {
        PlayerPrefsManager.initialize();
        int previousLevel = PlayerPrefsManager.getLevel();
        int minLevel = 1;
        int level3 = 3;

        //Comprovamos que de base sea mayor que 0
        Assert.That(PlayerPrefsManager.getLevel, Is.GreaterThan(0));
        //Lo comprovamos con dos valores por si se diera el caso de que previousLevel coincidiera con uno de ellos ya de base
        PlayerPrefsManager.setLevel(minLevel);
        Assert.That(PlayerPrefsManager.getLevel, Is.EqualTo(minLevel));

        PlayerPrefsManager.setLevel(level3);
        Assert.That(PlayerPrefsManager.getLevel, Is.EqualTo(level3));

        //Volvemos a dejarlo como estaba para no afectar al jugador
        PlayerPrefsManager.setLevel(previousLevel);
        Assert.That(PlayerPrefsManager.getLevel, Is.EqualTo(previousLevel));
    }
    [Test]
    public void SetUserName_Test()
    {
        PlayerPrefsManager.initialize();
        string previousUserName = PlayerPrefsManager.getUserName();
        string userName1 = "Random1";
        string userName2 = "Random2";

        //Comprovamos que de base no sea Null
        Assert.IsNotNull(previousUserName);
        //Lo comprovamos con dos valores por si se diera el caso de que previousUserName coincidiera con uno de ellos ya de base
        PlayerPrefsManager.setUserName(userName1);
        Assert.That(PlayerPrefsManager.getUserName, Is.EqualTo(userName1));

        PlayerPrefsManager.setUserName(userName2);
        Assert.That(PlayerPrefsManager.getUserName, Is.EqualTo(userName2));

        //Volvemos a dejarlo como estaba para no afectar al jugador
        PlayerPrefsManager.setUserName(previousUserName);
        Assert.That(PlayerPrefsManager.getUserName, Is.EqualTo(previousUserName));
    }
}
