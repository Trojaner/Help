using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API.Collections;
using SDG.Unturned;
using Rocket.API;

namespace fr34kyn01535.RewardExtension
{

    public class RewardExtension : RocketPlugin<RewardExtensionConfiguration>
    {
        public static RewardExtension Instance;

        protected override void Load()
        {
            Instance = this;
            if (IsDependencyLoaded("Uconomy"))
            {
                Logger.Log("Optional dependency Uconomy is present.");
            }
            else
            {
                Logger.Log("Optional dependency Uconomy is not present.");
            }
            {
                Votifier.Votifier.Instance.OnPlayerVoted += Instance_OnPlayerVoted;





            }

        }
        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    { "votifierxp_player_has_voted","Thanks for voting on {0}, you have received {1}" } ,
                       { "votifierxpuconomy_player_has_voted","Thanks for voting on {0}, you have received {1} and now have {2} in your balance." }


                };
            }
        }



        private void Instance_OnPlayerVoted(UnturnedPlayer player, Votifier.ServiceDefinition definition)




        {


            string XPReceived = Configuration.Instance.XP + "Sup";

            player.Experience += Configuration.Instance.XP.Value;

            UnturnedChat.Say(player, Instance.Translations.Instance.Translate("votifierxp_player_has_voted", definition.Name, XPReceived));
            Logger.Log(player.DisplayName + " has received " + XPReceived + " because he voted on " + definition.Name);





            string moneyReceived = Configuration.Instance.Money + Uconomy.Uconomy.Instance.Configuration.Instance.MoneyName;
            string newTotalMoney = Uconomy.Uconomy.Instance.Database.IncreaseBalance(player.Id, Configuration.Instance.Money) + Uconomy.Uconomy.Instance.Configuration.Instance.MoneyName;

            UnturnedChat.Say(player, Instance.Translations.Instance.Translate("votifierxpuconomy_player_has_voted", definition.Name, moneyReceived, newTotalMoney));
            Logger.Log(player.DisplayName + " has received " + moneyReceived + " because he voted on " + definition.Name);
        }

    }
}