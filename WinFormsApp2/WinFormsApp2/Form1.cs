using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.BLL;
using WinFormsApp2.DAL;
using WinFormsApp2.Domain;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly RadarService _radar = new();
        private readonly FireControlService _fireControl;
        private readonly List<IWeapon> _weapons;
        private IWeapon? _currentWeapon;

        public Form1()
        {
            InitializeComponent();

            _weapons = new List<IWeapon>
            {
                new ShortRangeCannon(),
                new UltrasonicCannon(),
                new BionicLaser()
            };

            var repo = new JsonShotRepository(GetShotsFilePath());
            _fireControl = new FireControlService(_weapons, repo);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            BindTargets(_radar.GetCurrentTargets());
            BindHistory();
            UpdateWeaponLabel();
        }

        private void btnRefreshTargets_Click(object? sender, EventArgs e)
        {
            BindTargets(_radar.RefreshTargets());
        }

        private void btnAutoSelect_Click(object? sender, EventArgs e)
        {
            var target = GetSelectedTarget();
            if (target is null)
            {
                MessageBox.Show("Select a target first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var weapon = _fireControl.Selector.SelectForDistance(target.DistanceKm);
            if (weapon is null)
            {
                MessageBox.Show("No suitable weapon for this distance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentWeapon = weapon;
            UpdateWeaponLabel();
        }

        private void btnNextWeapon_Click(object? sender, EventArgs e)
        {
            if (_currentWeapon is null)
            {
                _currentWeapon = _weapons.First();
            }
            else
            {
                _currentWeapon = _fireControl.Selector.Next(_currentWeapon);
            }
            UpdateWeaponLabel();
        }

        private void btnFire_Click(object? sender, EventArgs e)
        {
            var target = GetSelectedTarget();
            if (target is null)
            {
                MessageBox.Show("Select a target first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_currentWeapon is null)
            {
                var auto = _fireControl.Selector.SelectForDistance(target.DistanceKm);
                if (auto is null)
                {
                    MessageBox.Show("No suitable weapon for this distance.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _currentWeapon = auto;
                UpdateWeaponLabel();
            }

            var shot = _fireControl.Fire(_currentWeapon, target.DistanceKm);

            MessageBox.Show(
                $"{(_currentWeapon.Name)} fired at {target.DistanceKm:0.##} km.\n" +
                $"Result: {(shot.Hit ? "HIT" : "MISS")}.",
                "Shot",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            BindHistory();
        }

        private void BindTargets(List<Target> targets)
        {
            lstTargets.DataSource = null;
            lstTargets.DisplayMember = nameof(Target.Description);
            lstTargets.ValueMember = nameof(Target.Id);
            lstTargets.DataSource = targets;
        }

        private void BindHistory()
        {
            var list = _fireControl.GetHistory()
                .OrderByDescending(s => s.TimestampUtc)
                .ToList();

            dgvHistory.AutoGenerateColumns = true;
            dgvHistory.DataSource = list;
        }

        private Target? GetSelectedTarget()
        {
            return lstTargets.SelectedItem as Target;
        }

        private void UpdateWeaponLabel()
        {
            lblCurrentWeapon.Text = _currentWeapon?.Name ?? "(none)";
        }

        private static string GetShotsFilePath()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dir = Path.Combine(appData, "WinFormsApp2");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, "shots.json");
        }
    }
}
