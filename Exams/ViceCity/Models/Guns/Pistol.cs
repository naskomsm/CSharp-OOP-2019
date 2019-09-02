namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        private const int bulletsShot = 1;

        public Pistol(string name)
            : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < bulletsShot || this.BulletsPerBarrel == 0)
            {
                //reload
                if (this.TotalBullets >= bulletsPerBarrel)
                {
                    this.BulletsPerBarrel += bulletsPerBarrel;
                    this.TotalBullets -= bulletsPerBarrel;
                }

                //cant reload
                else
                {
                    return 0;
                }
            }

            else
            {
                this.BulletsPerBarrel -= bulletsShot;
            }

            return bulletsShot;
        }
    }
}
