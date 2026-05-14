using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    class Coin
    {
        private string sideUp;
        public Coin()
        {
            sideUp = "Heads";
        }
       EventLogSession eventLogSession = new EventLogSession();
        public void Toss()
        {
            Random random = new Random();
            int tossResult = random.Next(0, 2); // 0 or 1
            if (tossResult == 0)
            {
                sideUp = "Heads";
            }
            else
            {
                sideUp = "Tails";
            }
        }
        public string GetSideUp()
        {
            return sideUp;
        }
        }
    }