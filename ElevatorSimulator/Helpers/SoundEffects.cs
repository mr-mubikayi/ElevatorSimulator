using System;

namespace ElevatorSimulator.Helpers
{
    public static class SoundEffects
    {
        public static void PlayMoveBetweenFloors()
        {
            Console.Beep(800, 200);
        }

        public static void PlayDoorOpen()
        {
            Console.Beep(1000, 120);
            Console.Beep(1200, 120);
        }

        public static void PlayDoorClose()
        {
            Console.Beep(1200, 120);
            Console.Beep(1000, 120);
        }

        public static void PlayArrival()
        {
            Console.Beep(1500, 350);
        }

        public static void PlayButtonPress()
        {
            Console.Beep(600, 80);
        }
    }
}
