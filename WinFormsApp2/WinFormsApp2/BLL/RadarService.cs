using System;
using System.Collections.Generic;
using WinFormsApp2.Domain;

namespace WinFormsApp2.BLL
{
    public sealed class RadarService
    {
        public List<Target> GetCurrentTargets()
        {
            // Simulate radar distances; could be replaced with real input.
            // Includes one out-of-range target to show "no weapon" behavior.
            return new List<Target>
            {
                new Target(5),
                new Target(12),
                new Target(75),
                new Target(150),
                new Target(220) // out of supported range
            };
        }

        public List<Target> RefreshTargets()
        {
            // Optionally randomize to emulate radar updates.
            var rnd = Random.Shared;
            int count = rnd.Next(4, 8);
            var list = new List<Target>(count);
            for (int i = 0; i < count; i++)
            {
                // 0..250 km
                double d = Math.Round(rnd.NextDouble() * 250, 2);
                list.Add(new Target(d));
            }
            return list;
        }
    }
}