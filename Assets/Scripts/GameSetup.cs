using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace EntitasTest
{
    [CreateAssetMenu, Game, Unique]
    public class GameSetup : ScriptableObject
    {
        public GameObject Player => player;
        public GameObject Laser => laser;
        public float RotationSpeed => rotationSpeed;
        public float MovementSpeed => movementSpeed;
        public float LaserSpeed => laserSpeed;
        public float AsteroidSpeed => asteroidSpeed;
        
        public GameObject[] Bigs => bigs;
        public GameObject[] Meds => meds;
        public GameObject[] Smalls => smalls;
        public GameObject[] Tinys => tinys;
        
        [SerializeField] private GameObject player = null;
        [SerializeField] private GameObject laser = null;
        [SerializeField] private float rotationSpeed = 180f;
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float laserSpeed = 5f;
        [SerializeField] private float asteroidSpeed = 0.3f;
        
        [SerializeField] private GameObject[] bigs = null;
        [SerializeField] private GameObject[] meds = null;
        [SerializeField] private GameObject[] smalls = null;
        [SerializeField] private GameObject[] tinys = null;
    }
}