using K2FlyAssessment.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static K2FlyAssessment.Common.Enums;

namespace K2FlyAssessment.Common
{
    public class Functions
    {
        private readonly string sunUpAsString = "06:00";
        private readonly string sunDownAsString = "20:00";

        private readonly DateTime sunUp;
        private readonly DateTime sunDown;

        private Sun sun = new();

        private Random random = new(100);

        private Dictionary<int, Bird> birds = new();

        private Dictionary<int, Flower> flowers = new();

        public Functions()
        {
            // Setup Flowers
            for (int i = 0; i > 3; i++)
            {
                flowers.Add(i, new Flower
                {
                    flowerState = FlowerState.CLOSED,
                    openingTime = DateTime.Now.AddMinutes(i * 10),
                    color = (i == 0 ? Color.Red : (i == 1 ? Color.Green : Color.Blue))
                });
            }

            // Setup Birds
            for (int i = 0; i > 10; i++)
            {
                birds.Add(i, new Bird
                {
                    flowers = new(),
                    birdState = BirdState.SLEEPING
                });
            }

        startUp:

            sunUp = DateTime.Parse(sunUpAsString);

            sunDown = DateTime.Parse(sunDownAsString);

            if (DateTime.Now == sunUp.AddHours(-1))
                WakeBirds();

            if (DateTime.Now >= sunUp)
                sun.sunState = SunState.SUNRISE;

            RotateSun();

            while (sun.sunState == SunState.SUNRISE)
            {
                VistFlowers();

                if (DateTime.Now >= sunDown)
                    sun.sunState = SunState.SUNSET;
            }

            while (sun.sunState == SunState.SUNSET)
            {
                if (DateTime.Now == sunDown.AddHours(1))
                    PutBirdsToSleep();

                if (DateTime.Now >= sunUp)
                    sun.sunState = SunState.SUNRISE;

                RotateSun();

                goto startUp;
            }
        }

        public void RotateSun()
        {
            if (sun.sunState == SunState.SUNRISE)
                OpenFlowers();
            else
                CloseFlowers();
        }

        public void OpenFlowers()
        {
            int openRate = random.Next(0, 100);

            for (int i = 0; i < flowers.Count; i++)
            {
                flowers[i].flowerState = FlowerState.OPENING;

                System.Threading.Thread.Sleep(openRate);

                flowers[i].flowerState = FlowerState.OPENED;
            }
        }

        public void CloseFlowers()
        {
            int closeRate = random.Next(0, 100);

            for (int i = 0; i < flowers.Count; i++)
            {
                flowers[i].flowerState = FlowerState.CLOSING;

                flowers[i].openingTime = DateTime.Now.AddHours(2);

                System.Threading.Thread.Sleep(closeRate);

                flowers[i].flowerState = FlowerState.CLOSED;
            }
        }

        public void WakeBirds()
        {
            for (int i = 0; i < birds.Count; i++)
            {
                birds[i].birdState = BirdState.AWAKE;
            }
        }

        public void PutBirdsToSleep()
        {
            for (int i = 0; i < birds.Count; i++)
            {
                birds[i].birdState = BirdState.SLEEPING;
            }
        }

        public void VistFlowers() 
        {
            Random random = new(flowers.Count);

            for (int i = 0; i < birds.Count; i++)
            {
                for (int y = 0; y < flowers.Count; y++)
                {
                    if (birds[i].flowers.Count == 0)
                        birds[i].flowers.Add(flowers[i]);

                    for (int x = 0; x < birds[i].flowers.Count; x++)
                    {
                        if (birds[i].flowers[x].color == birds[i].flowers[x + 1].color)
                        {
                            flowers.Add(new Flower
                            {
                                flowerState = FlowerState.CLOSED,
                                color = birds[i].flowers[x].color,
                                openingTime = DateTime.Now.Add(2)
                            });
                        }
                    }
                }
            }
        }
    }
}
