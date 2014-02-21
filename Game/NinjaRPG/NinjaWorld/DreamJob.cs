namespace NinjaWorld
{
    public class DreamJob : Building
    {
        private static DreamJob firstInstanceOfDreamJob = null;
        private DreamJob(string name)
            : base(name)
        {
        }

        public static DreamJob getInstance(string name)
        {
            if (firstInstanceOfDreamJob == null)
            {
                firstInstanceOfDreamJob = new DreamJob(name);
            }
           
            return firstInstanceOfDreamJob;
        }
        public void OfferReward()
        {
            // TODO: Offer GAMEOVER + WIN!!!
        }
    }
}
