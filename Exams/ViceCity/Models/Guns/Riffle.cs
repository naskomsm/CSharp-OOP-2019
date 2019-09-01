namespace ViceCity.Models.Guns
{
    public class Riffle : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        private const int bulletsShot = 5;

        public Riffle(string name)
            : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - bulletsShot > 0)
            {
                this.BulletsPerBarrel -= bulletsShot;
            }

            else
            {
                if (this.TotalBullets > 0)
                {
                    this.BulletsPerBarrel += bulletsShot;
                    this.TotalBullets -= bulletsShot;
                }
            }

            return bulletsShot;
        }
    }
}
