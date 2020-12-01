using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public partial class SpaceImpact : Form
    {
        private static readonly Random Rnd = new Random();
        private Player _player;
        private Boss _boss;
        private Heart _heart;
        private readonly List<Minion> _minions = new List<Minion>();
        private static readonly Dictionary<string, Image> Images = new Dictionary<string, Image>();
        private static readonly Dictionary<string, SoundPlayer> Sounds = new Dictionary<string, SoundPlayer>();
        private readonly string _imgPath = Path.Combine(AppContext.BaseDirectory, "Images");
        private readonly string _soundPath = Path.Combine(AppContext.BaseDirectory, "Sounds");
        private readonly int[] _spawnIntervals = { 70, 110, 150, 170, 420 };
        private static Keys _activeKey;
        private static bool
            _gameInSession,
            _heartInPlay,
            _bossMode,
            _darkMode;
        private static int
            _timeElapsed,
            _score;

        public SpaceImpact()
        {
            InitializeComponent();
        }

        private void SpaceImpact_Load(object sender, EventArgs e)
        {
            LoadImages();
            SetImages();
            LoadSounds();
            _player = new Player();
            _heart = new Heart();
            _boss = new Boss();
        }

        private void LoadImages()
        {
            Images.Add("ship", Image.FromFile(Path.Combine(_imgPath, "ship.png")));
            Images.Add("shipGreen", Image.FromFile(Path.Combine(_imgPath, "shipGreen.png")));
            Images.Add("heart", Image.FromFile(Path.Combine(_imgPath, "heart.png")));
            Images.Add("heartGreen", Image.FromFile(Path.Combine(_imgPath, "heartGreen.png")));
            Images.Add("minion", Image.FromFile(Path.Combine(_imgPath, "minion.png")));
            Images.Add("minionGreen", Image.FromFile(Path.Combine(_imgPath, "minionGreen.png")));
            Images.Add("boss", Image.FromFile(Path.Combine(_imgPath, "boss.png")));
            Images.Add("bossGreen", Image.FromFile(Path.Combine(_imgPath, "bossGreen.png")));
            Images.Add("surface", Image.FromFile(Path.Combine(_imgPath, "surface.png")));
            Images.Add("surfaceGreen", Image.FromFile(Path.Combine(_imgPath, "surfaceGreen.png")));
        }

        private void SetImages()
        {
            foreach (var o in this.Controls)
            {
                if (o.GetType() == typeof(PictureBox))
                    ((PictureBox)o).BackColor = Color.Transparent;
            }
            Surface.BackgroundImage = Images["surface"];
            Surface2.BackgroundImage = Images["surface"];
            Heart1.BackgroundImage = Images["heart"];
            Heart2.BackgroundImage = Images["heart"];
            Heart3.BackgroundImage = Images["heart"];
            Heart4.BackgroundImage = Images["heart"];
            Heart5.BackgroundImage = Images["heart"];
        }

        private void LoadSounds()
        {
            Sounds.Add("shoot", new SoundPlayer(Path.Combine(_soundPath, "shoot.wav")));
            Sounds.Add("hit", new SoundPlayer(Path.Combine(_soundPath, "hit.wav")));
            Sounds.Add("hitBoss", new SoundPlayer(Path.Combine(_soundPath, "hitBoss.wav")));
            Sounds.Add("heal", new SoundPlayer(Path.Combine(_soundPath, "heal.wav")));
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Controls.Add(_player.Model);
            _gameInSession = true;
            InfoLabel.Visible = false;
            StartButton.Visible = false;
            _score = 0;
            HighScoreLabel.Text = GetHighScore();
            MainTimer.Enabled = true;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            _timeElapsed++;
            DeleteEntitiesOutsideWindow();
            CheckCollisions();
            MoveSurface();
            _player.MoveProjectiles();
            if (_player.Cooldown != 0)
                _player.Cooldown--;

            if (_heartInPlay)
                _heart.Move();
            else if (_timeElapsed % (_spawnIntervals[Rnd.Next(0, 4)] * 50) == 0)
            {
                _heart = new Heart();
                this.Controls.Add(_heart.Model);
                _heartInPlay = true;
            }

            if (_bossMode)
            {
                _boss.Move();
                _boss.MoveProjectiles();
                if (_boss.Health == 0)
                    NextLevel();
                if (_boss.Cooldown != 0)
                    _boss.Cooldown--;
                else
                {
                    _boss.Shoot();
                    this.Controls.Add(_boss.Projectiles.Last().Model);
                }
            }
            else
            {
                foreach (Minion m in _minions)
                    m.Move();
                if (_timeElapsed % _spawnIntervals[Rnd.Next(0, 4)] == 0)
                {
                    _minions.Add(new Minion());
                    this.Controls.Add(_minions.Last().Model);
                }
                if (_timeElapsed == 3000)
                {
                    ClearMinions();
                    _boss = new Boss();
                    this.Controls.Add(_boss.Model);
                    _bossMode = true;
                    _timeElapsed = 0;
                }
            }
        }

        private void ShipMovementTimer_Tick(object sender, EventArgs e)
        {
            _player.Move();
        }

        private void ShootingTimer_Tick(object sender, EventArgs e)
        {
            if (_player.Cooldown != 0)
                return;
            _player.Shoot();
            this.Controls.Add(_player.Projectiles.Last().Model);
        }

        private void LevelTransitionTimer_Tick(object sender, EventArgs e)
        {
            _player.Model.Left += 10;
            if (_player.Model.Left > 800)
            {
                _player.Model.Location = new Point(20, 220);
                MainTimer.Enabled = true;
                LevelTrainsitionTimer.Enabled = false;
                SwitchColors();
            }
        }

        private void SpaceImpact_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainTimer.Enabled == false)
                return;
            if (IsArrow(e.KeyCode))
            {
                _activeKey = e.KeyCode;
                ShipMovementTimer.Enabled = true;
            }
            else if (e.KeyCode == Keys.X)
                ShootingTimer.Enabled = true;
        }

        private void SpaceImpact_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == _activeKey)
                ShipMovementTimer.Enabled = false;
            else if (e.KeyCode == Keys.X)
                ShootingTimer.Enabled = false;
        }

        private bool IsArrow(Keys k)
        {
            switch (k)
            {
                case Keys.Down:
                    return true;
                case Keys.Up:
                    return true;
                case Keys.Left:
                    return true;
                case Keys.Right:
                    return true;
                default: return false;
            }
        }

        private void PauseUnpause(object sender, MouseEventArgs e)
        {
            if (!_gameInSession || LevelTrainsitionTimer.Enabled)
                return;
            MainTimer.Enabled = !MainTimer.Enabled;
            PausedLabel.Visible = !PausedLabel.Visible;
            InfoLabel.Visible = !InfoLabel.Visible;
            SaveScore();
        }

        private void UpdateHealth()
        {
            switch (_player.Health)
            {
                case 0:
                    Heart1.Visible = false;
                    EndGame();
                    break;
                case 1:
                    Heart2.Visible = false;
                    Heart1.Visible = true;
                    break;
                case 2:
                    Heart3.Visible = false;
                    Heart2.Visible = true;
                    break;
                case 3:
                    Heart4.Visible = false;
                    Heart3.Visible = true;
                    break;
                case 4:
                    Heart5.Visible = false;
                    Heart4.Visible = true;
                    break;
                case 5:
                    Heart5.Visible = true;
                    break;
            }
        }

        private void UpdateScore()
        {
            ScoreLabel.Text = _score.ToString("D6");
        }

        private void MoveSurface()
        {
            Surface.Left -= 2;
            Surface2.Left -= 2;
            if (Surface.Right == 0) Surface.Left = 800;
            if (Surface2.Right == 0) Surface2.Left = 800;
        }

        private void DeleteEntitiesOutsideWindow()
        {
            for (int i = 0; i < _player.Projectiles.Count; i++)
                if (_player.Projectiles[i].OutTheWindow)
                {
                    this.Controls.Remove(_player.Projectiles[i].Model);
                    _player.Projectiles.Remove(_player.Projectiles[i]);
                }
            for (int i = 0; i < _minions.Count; i++)
                if (_minions[i].OutTheWindow)
                {
                    this.Controls.Remove(_minions[i].Model);
                    _minions.Remove(_minions[i]);
                    _score -= 5;
                    UpdateScore();
                }
            if (_bossMode)
                for (int i = 0; i < _boss.Projectiles.Count; i++)
                {
                    if (_boss.Projectiles[i].OutTheWindow)
                    {
                        this.Controls.Remove(_boss.Projectiles[i].Model);
                        _boss.Projectiles.Remove(_boss.Projectiles[i]);
                    }
                }
            if (_heart.OutTheWindow)
            {
                this.Controls.Remove(_heart.Model);
                _heartInPlay = false;
            }
        }

        private void CheckCollisions()
        {
            if (_heartInPlay)
                CheckPlayerWithHeart();
            if (_bossMode)
            {
                CheckPlayerWithBossProjectiles();
                CheckProjectilesWithBoss();
            }
            else
            {
                CheckPlayerWithMinions();
                CheckProjectilesWithMinions();
            }
        }

        private void CheckProjectilesWithMinions()
        {

            for (int i = 0; i < _player.Projectiles.Count; i++)
                for (int j = 0; j < _minions.Count; j++)
                {
                    if (IsTouching(_player.Projectiles[i], _minions[j]))
                    {
                        this.Controls.Remove(_minions[j].Model);
                        _minions.Remove(_minions[j]);
                        this.Controls.Remove(_player.Projectiles[i].Model);
                        _player.Projectiles.Remove(_player.Projectiles[i]);
                        _score += 10;
                        UpdateScore();
                        Sounds["hit"].Play();
                        return;
                    }
                }
        }

        private void CheckProjectilesWithBoss()
        {
            for (int i = 0; i < _player.Projectiles.Count; i++)
            {
                if (IsTouching(_player.Projectiles[i], _boss))
                {
                    this.Controls.Remove(_player.Projectiles[i].Model);
                    _player.Projectiles.Remove(_player.Projectiles[i]);
                    _boss.Health--;
                    _score += 5;
                    UpdateScore();
                    Sounds["hitBoss"].Play();
                    return;
                }
            }
        }

        private void CheckPlayerWithMinions()
        {
            for (int i = 0; i < _minions.Count; i++)
            {
                if (IsTouching(_player, _minions[i]))
                {
                    this.Controls.Remove(_minions[i].Model);
                    _minions.Remove(_minions[i]);
                    _player.Health--;
                    UpdateHealth();
                    ClearMinions();
                    Sounds["hit"].Play();
                    return;
                }
            }
        }

        private void CheckPlayerWithBossProjectiles()
        {
            for (int i = 0; i < _boss.Projectiles.Count; i++)
            {
                if (IsTouching(_boss.Projectiles[i], _player))
                {
                    this.Controls.Remove(_boss.Projectiles[i].Model);
                    _boss.Projectiles.Remove(_boss.Projectiles[i]);
                    _boss.Health--;
                    UpdateHealth();
                    Sounds["hit"].Play();
                    return;
                }
            }
        }

        private void CheckPlayerWithHeart()
        {
            if (IsTouching(_player, _heart))
            {
                this.Controls.Remove(_heart.Model);
                _heartInPlay = false;
                if (_player.Health < 5)
                {
                    _player.Health++;
                    Sounds["heal"].Play();
                    UpdateHealth();
                }
            }
        }

        private bool IsTouching(Entity ent, Entity ent2)
        {
            PictureBox x = ent.Model;
            PictureBox y = ent2.Model;
            if (x.Right > y.Left && x.Right < y.Right || x.Left > y.Left && x.Left < y.Right)
            {
                if ((x.Top > y.Top && x.Top < y.Bottom) || (x.Bottom > y.Top && x.Bottom < y.Bottom))
                    return true;
            }
            return false;
        }

        private void NextLevel()
        {
            _bossMode = false;
            _boss.Health = 30;
            _score += 10;
            UpdateScore();
            this.Controls.Remove(_boss.Model);
            ClearProjectiles();
            MainTimer.Enabled = false;
            LevelTrainsitionTimer.Enabled = true;
        }

        private void ClearMinions()
        {
            foreach (var minion in _minions)
                this.Controls.Remove(minion.Model);
            _minions.Clear();
        }

        private void ClearProjectiles()
        {
            foreach (var projectile in _boss.Projectiles)
                this.Controls.Remove(projectile.Model);
            _boss.Projectiles.Clear();

            foreach (var projectile in _player.Projectiles)
                this.Controls.Remove(projectile.Model);
            _player.Projectiles.Clear();
        }

        private void SwitchColors()
        {
            _darkMode = !_darkMode;
            SwitchImages();
            this.BackColor = _darkMode ? Color.Black : Color.Olive;
            foreach (var o in this.Controls)
            {
                if (o.GetType() == typeof(Label))
                {
                    ((Label)o).BackColor = _darkMode ? Color.Black : Color.Olive;
                    ((Label)o).ForeColor = _darkMode ? Color.Olive : Color.Black;
                }
                else if (o.GetType() == typeof(Button))
                {
                    ((Button)o).BackColor = _darkMode ? Color.Black : Color.Olive;
                    ((Button)o).ForeColor = _darkMode ? Color.Olive : Color.Black;
                }
            }
        }

        private void SwitchImages()
        {
            if (_darkMode)
            {
                _player.Model.BackgroundImage = Images["shipGreen"];
                Surface.BackgroundImage = Images["surfaceGreen"];
                Surface2.BackgroundImage = Images["surfaceGreen"];
                Heart1.BackgroundImage = Images["heartGreen"];
                Heart2.BackgroundImage = Images["heartGreen"];
                Heart3.BackgroundImage = Images["heartGreen"];
                Heart4.BackgroundImage = Images["heartGreen"];
                Heart5.BackgroundImage = Images["heartGreen"];
            }
            else
            {
                _player.Model.BackgroundImage = Images["ship"];
                Surface.BackgroundImage = Images["surface"];
                Surface2.BackgroundImage = Images["surface"];
                Heart1.BackgroundImage = Images["heart"];
                Heart2.BackgroundImage = Images["heart"];
                Heart3.BackgroundImage = Images["heart"];
                Heart4.BackgroundImage = Images["heart"];
                Heart5.BackgroundImage = Images["heart"];
            }
        }

        private string GetHighScore()
        {
            try
            {
                var path = Path.Combine(AppContext.BaseDirectory, "score.txt");
                var sr = new StreamReader(path);
                var highscore = sr.ReadLine();
                sr.Close();
                if (highscore == null)
                    return "0";
                return highscore;
            }
            catch (Exception)
            {
                return "0";
            }
        }

        private void SaveScore()
        {
            if (_score > int.Parse(GetHighScore()))
            {
                var path = Path.Combine(AppContext.BaseDirectory, "score.txt");
                var sw = new StreamWriter(path);
                sw.WriteLine(_score.ToString());
                sw.Close();
            }
        }

        private void EndGame()
        {
            ClearProjectiles();
            ClearMinions();
            SaveScore();
            if (_bossMode)
            {
                this.Controls.Remove(_boss.Model);
                _bossMode = false;
            }
            _player.Model.Visible = false;
            _gameInSession = false;
            MainTimer.Enabled = false;
            InfoLabel.Visible = true;
            GameOverLabel.Visible = true;
            RestartButton.Visible = true;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                _player.Health++;
                UpdateHealth();
            }
            if (_darkMode)
                SwitchColors();
            if (_bossMode)
                _bossMode = false;
            _player.Model.Location = new Point(20, 220);
            GameOverLabel.Visible = false;
            RestartButton.Visible = false;
            _player.Model.Visible = true;
            StartButton_Click(sender, e);
        }

        public abstract class Entity
        {
            public PictureBox Model;
            protected int UpperBound;
            protected int LowerBound;
            protected string WiggleDirection;
            public bool OutTheWindow;

            protected void CheckBoundries()
            {
                if (Model.Top < UpperBound)
                    WiggleDirection = "down";
                if (Model.Bottom > LowerBound)
                    WiggleDirection = "up";
                if (Model.Right < 0 || Model.Left > 800)
                    OutTheWindow = true;
            }
        }

        public class Player : Entity
        {
            public List<Projectile> Projectiles;
            public int Cooldown;
            public int Health;
            public Player()
            {
                Model = new PictureBox
                {
                    Size = new Size(100, 70),
                    BackColor = Color.Transparent,
                    BackgroundImage = _darkMode ? Images["shipGreen"] : Images["ship"],
                    Location = new Point(20, 220)
                };
                Health = 3;
                Projectiles = new List<Projectile>();
                Cooldown = 0;
            }

            public void Move()
            {
                switch (_activeKey)
                {
                    case Keys.Down:
                        if (Model.Bottom < 460)
                            Model.Top += 4;
                        break;
                    case Keys.Up:
                        if (Model.Top > 60)
                            Model.Top -= 4;
                        break;
                    case Keys.Left:
                        if (Model.Left > 0)
                            Model.Left -= 4;
                        break;
                    case Keys.Right:
                        if (Model.Right < 600)
                            Model.Left += 4;
                        break;
                }
            }

            public void Shoot()
            {
                Projectiles.Add(new Projectile(this));
                Cooldown = 30;
                Sounds["shoot"].Play();
            }

            public void MoveProjectiles()
            {
                foreach (Projectile p in Projectiles)
                    p.Move();
            }
        }

        public class Projectile : Entity
        {
            private readonly bool _friendly;
            public Projectile(Entity sender)
            {
                var m = sender.Model;
                var spawnX = m.Left + m.Size.Width / 2 - 20;
                var spawnY = m.Top + m.Size.Height / 2 - 10;
                Model = new PictureBox
                {
                    Size = new Size(20, 10),
                    BackColor = _darkMode ? Color.Olive : Color.Black,
                    Location = new Point(spawnX, spawnY)
                };
                if (sender.GetType() == typeof(Player))
                    _friendly = true;
            }

            public void Move()
            {
                if (_friendly)
                    Model.Left += 10;
                else
                    Model.Left -= 5;
                this.CheckBoundries();
            }
        }

        public class Heart : Entity
        {
            public Heart()
            {
                Model = new PictureBox
                {
                    Size = new Size(40, 40),
                    BackColor = Color.Transparent,
                    BackgroundImage = _darkMode ? Images["heartGreen"] : Images["heart"],
                    Location = new Point(800, 250)
                };
                UpperBound = 60;
                LowerBound = 460;
                WiggleDirection = "up";
            }

            public void Move()
            {
                Model.Left--;
                if (WiggleDirection == "up")
                    Model.Top--;
                else
                    Model.Top++;
                this.CheckBoundries();
            }
        }

        public class Minion : Entity
        {
            public Minion()
            {
                var spawnY = Rnd.Next(130, 350);
                Model = new PictureBox
                {
                    Size = new Size(40, 40),
                    BackColor = Color.Transparent,
                    BackgroundImage = _darkMode ? Images["minionGreen"] : Images["minion"],
                    Location = new Point(800, spawnY)
                };
                UpperBound = spawnY - 60;
                LowerBound = spawnY + 60;
                WiggleDirection = "up";
            }
            public void Move()
            {
                Model.Left -= 2;
                if (WiggleDirection == "up")
                    Model.Top--;
                else
                    Model.Top++;
                this.CheckBoundries();
            }
        }

        public class Boss : Entity
        {
            public List<Projectile> Projectiles;
            public int Cooldown;
            public int Health;

            public Boss()
            {
                Model = new PictureBox
                {
                    Size = new Size(152, 160),
                    BackColor = Color.Transparent,
                    BackgroundImage = _darkMode ? Images["bossGreen"] : Images["boss"],
                    Location = new Point(800, 250)
                };
                UpperBound = 60;
                LowerBound = 460;
                WiggleDirection = "up";
                Health = 30;
                Projectiles = new List<Projectile>();
                Cooldown = 0;
            }

            public void Move()
            {
                if (Model.Right > 800)
                    Model.Left--;
                if (WiggleDirection == "up")
                    Model.Top--;
                else
                    Model.Top++;
                this.CheckBoundries();
            }

            public void Shoot()
            {
                Projectiles.Add(new Projectile(this));
                Cooldown = 100;
                Sounds["shoot"].Play();
            }

            public void MoveProjectiles()
            {
                foreach (Projectile p in Projectiles)
                    p.Move();
            }
        }
    }
}
