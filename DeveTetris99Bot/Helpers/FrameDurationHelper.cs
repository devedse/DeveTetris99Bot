namespace DeveTetris99Bot.Helpers
{
    public static class FrameDurationHelper
    {
        private static readonly double DurationOneFrame = 1000.0 / 60.0;

        public static int ToFrameDuration(int frameCount)
        {
            return (int)(frameCount * DurationOneFrame);
        }
    }
}
