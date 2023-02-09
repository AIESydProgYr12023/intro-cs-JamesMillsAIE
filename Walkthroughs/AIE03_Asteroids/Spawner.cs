using System.Numerics;

namespace AIE03_Asteroids
{
    public class Spawner
    {
        private List<GameObject> GameObjects
        {
            get
            {
                return game.gameObjects;
            }
        }

        private Game game;
        private Player player;

        private const int MAX_ASTEROID_COUNT = 100;
        private const int MAX_BULLET_COUNT = 100;

        private int currentAsteroidCount;
        private int currentBulletCount;

        private float asteroidSpawnCooldown = 4.0f;
        private float asteroidSpawnTime;

        public Spawner(Game _game)
        {
            game = _game;

            asteroidSpawnTime = asteroidSpawnCooldown;
        }

        public void Load()
        {
            player = new Player(
                this,
                new Vector2(Game.WINDOW_WIDTH / 2, Game.WINDOW_HEIGHT / 2),
                new Vector2(64, 64)
                );

            GameObjects.Add(player);
        }

        public void Update(float _deltaTime)
        {
            asteroidSpawnTime -= _deltaTime;
            if(asteroidSpawnTime < 0)
            {
                SpawnNewAsteroid();
                asteroidSpawnTime = asteroidSpawnCooldown;
            }

            CheckBulletAsteroidCollisions();
        }

        public void SpawnNewAsteroid()
        {
            // Pick a random side of the screen
            // 0 = left, 1 = top, 2 = right, 3 = bottom
            Random rand = new Random();
            int side = rand.Next(0, 4);

            // Create a random direction for the asteroid to move in.
            float randRot = rand.NextSingle() * 360f;
            Vector2 direction = new Vector2(MathF.Cos(randRot), MathF.Sin(randRot));

            const int DEFAULT_RADIUS = 40;

            switch (side)
            {
                case 0: // Left Side
                    SpawnAsteroid(new Vector2(0, rand.Next(0, Game.WINDOW_HEIGHT)), direction, DEFAULT_RADIUS);
                    break;

                case 1: // Top side
                    SpawnAsteroid(new Vector2(rand.Next(0, Game.WINDOW_WIDTH), 0), direction, DEFAULT_RADIUS);
                    break;

                case 2: // Right side
                    SpawnAsteroid(new Vector2(Game.WINDOW_WIDTH, rand.Next(0, Game.WINDOW_HEIGHT)), direction, DEFAULT_RADIUS);
                    break;

                case 3: // Bottom side
                    SpawnAsteroid(new Vector2(rand.Next(0, Game.WINDOW_WIDTH), Game.WINDOW_HEIGHT), direction, DEFAULT_RADIUS);
                    break;

                default:
                    break;
            }
        }

        public void SpawnAsteroid(Vector2 _position, Vector2 _direction, float _radius)
        {
            if (currentAsteroidCount == MAX_ASTEROID_COUNT)
                return;

            currentAsteroidCount++;
            Asteroid asteroid = new Asteroid(this, _position, _direction);
            asteroid.Generate(12, _radius);
            GameObjects.Add(asteroid);
        }

        public void SpawnBullet(Vector2 _position, Vector2 _direction)
        {
            if (currentBulletCount == MAX_BULLET_COUNT)
                return;

            Bullet bullet = new Bullet(this, _position, _direction);
            currentBulletCount++;
            GameObjects.Add(bullet);
        }

        public void SplitAsteroid(Bullet _bullet, Asteroid _asteroid)
        {
            Random rand = new Random();
            int splitAmount = rand.Next(1, 5);
            for (int i = 0; i < splitAmount; i++)
            {
                Vector2 newDir = _asteroid.direction;
                newDir.X *= rand.NextSingle() + 0.5f;
                newDir.Y *= rand.NextSingle() + 0.5f;

                Asteroid split = new Asteroid(this, _asteroid.position, newDir);
                split.Generate(12, _asteroid.radius / 2);

                GameObjects.Add(split);
            }

            GameObjects.Remove(_bullet);
            GameObjects.Remove(_asteroid);
        }

        private void CheckBulletAsteroidCollisions()
        {
            List<Bullet> bullets = new List<Bullet>();
            List<Asteroid> asteroids = new List<Asteroid>();

            foreach(GameObject gameObject in GameObjects)
            {
                if(gameObject is Bullet bullet)
                {
                    bullets.Add(bullet);
                }

                if(gameObject is Asteroid asteroid)
                {
                    asteroids.Add(asteroid);
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < asteroids.Count; j++)
                {
                    if (Vector2.Distance(bullets[i].position, asteroids[j].position) < asteroids[j].radius)
                    {
                        SplitAsteroid(bullets[i], asteroids[j]);
                        bullets.RemoveAt(i);
                        asteroids.RemoveAt(j);

                        i--;
                        j--;
                        currentAsteroidCount--;
                        currentBulletCount--;

                        if(bullets.Count == 0 || asteroids.Count == 0 || i < 0 || j < 0)
                            break;
                    }
                }
            }
        }
    }
}
