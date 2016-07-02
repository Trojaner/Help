using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.RewardExtension
{
    public class RewardExtensionConfiguration : IRocketPluginConfiguration
    {
        public uint? XP = null;
        public decimal Money;
        public void LoadDefaults()
        {
            XP = 190;
            Money = 0;
        }
    }
}