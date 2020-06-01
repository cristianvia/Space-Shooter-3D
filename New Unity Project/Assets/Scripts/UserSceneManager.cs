using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class UserSceneManager : MonoBehaviour
{

    public PlayerMovement player;                           //referencia a nuestro jugador
    public PlayerBox playerBox;                             //Referencia al playerBox de la escena
    public EnemyCreator enemyCreator;                       //Referencia al creador de enemigos situado en la estrella de la muerte
    public PauseMenuScript menusManager;                    //Referencia al gestor de menus
    public Text textOnStart;                                //Texto que nos pide que toquemos la pantalla al empezar el juego
    public bool started = false;                            //Variable  que nos indicará si el juego a empezado (una vez tocada la pantalla)
    public bool gameOver = false;                           //Variable que nos indicará si nos hemos quedado sin vida
    public float timeGame= 0f;                              //Variable que nos ayuda a contar el tiempo y compararlo con finalTime
    public float finalTime = 90f;                           //variable para ajustar cuanto dura el nivel, devbe ser mayor que 5
    public Transform camera;                                //Referencia a la camara, para quitarla del parent en la animación final
    public MeshCollider colliderPlayer;                     //Referencia del collider del player para desactivarlo en la animación final
    public GameObject wonMenu;                              //Referencia al menú que se desplegará al ganar
    public TMPro.TextMeshProUGUI wonMenuScore;              //Referencia al wonMenuscore que se desplegará en caso de que el usuario quiera ver las scores
    public GameObject wonSound;                             //Prefab que accionará el sonido de victoria
    public GameObject pauseMusic;                           //Prefab que accionará el sonido de pausa
    public GameObject negrosMusic;
    public AudioSource muteMusic;                           //Variable para parar la musica
    
    bool backGroundMusicMute = false;                       //Variable para limitar que el sonido de win solo suene una vez

    private bool ending = false;                            //Activa la animación final cuando esta acabando el nivel
    ScoresCollection scoresCollection;                      //Variable para cargar y guardar las scores en un fichero XML
    string rootFolder;                                      //Path donde se guardarán las scores
    bool gameSaved = false;                                 //Variable necesaria para que no guarde la nueva score a cada frame

    public int nextLevel = 2;                               
    private void Start()
    {
        //Si estamos desde el editor de Unity cogera el path de la aplicación
#if UNITY_EDITOR
        rootFolder = Application.dataPath;
        //Si estamos en Android o iOS cogerá el path de persistentDataPath, que es una carpeta que crea unity en estos dispositivos con
        //los archivos que necesitará mas tarde como es el caso
#elif UNITY_ANDROID || UNITY_IOS
        rootFolder = Application.persistentDataPath;
#endif
        scoresCollection = ScoresCollection.Load(Path.Combine(rootFolder, "scores.xml"));

        Time.timeScale = 0f;
       
    }
    private void Update()
    {
        timeGame += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && !started || Input.GetKeyDown(KeyCode.Mouse0) && !started)
        {
            textOnStart.enabled = false;
            started = true;
            Time.timeScale = 1f;
        }
        if(player.life <= 0)
        {
            player.life = 0;
            gameOver = true;
            menusManager.LoadDiedMenu();
            if (backGroundMusicMute == false)
            {
                muteMusic.mute = true;
                Instantiate(negrosMusic);
                backGroundMusicMute = true;
            }
        }
        if ( timeGame >= finalTime)
        {
            FinalAnimation();
        }
        if (ending && timeGame >= 5f)
        {
            wonMenu.SetActive(true);
            wonMenuScore.text = "SCORE: " + player.score.ToString("0");
            Time.timeScale = 0f;

            //Si aun no hemos guardado, lo hará pero solo una vez
            if (!gameSaved)
            {
                //Creamos una Score
                Score myScore = new Score(PlayerPrefsManager.getUserName(), player.score);
                //La añadimos a scoresCollection
                scoresCollection.scores.Add(myScore);
                //Lo guardamos en la ruta RootFolder y en el fichero scores.xml
                scoresCollection.Save(Path.Combine(rootFolder, "scores.xml"));
                //Indicamos que ya se ha guardado para que en el siguiente frame no lo vuelva a hacer
                gameSaved = true;

                if(nextLevel > PlayerPrefsManager.getLevel())
                    PlayerPrefsManager.setLevel(nextLevel);
            }
            
            if (backGroundMusicMute == false) {
                muteMusic.mute = true;
                Instantiate(pauseMusic);
                backGroundMusicMute = true;
            }
        }
    }
    public void SetOnMusic(float volume, bool mute)
    {
        if (backGroundMusicMute == false)
        {
            muteMusic.mute = mute;
            muteMusic.volume = volume;
        }
    }

    private void FinalAnimation()
    {
        colliderPlayer.enabled = false;
        enemyCreator.transform.parent = null;
        camera.parent = null;
        timeGame = 0f;
        ending = true;
        Instantiate(wonSound);
        //muteMusic.mute = true; 
        
        Enemy[] enemys = FindObjectsOfType<Enemy>();

        foreach (Enemy e in enemys)
        {
            e.Explode();
        }
        
    }
}
