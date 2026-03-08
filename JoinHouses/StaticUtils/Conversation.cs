using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace JoinHouses.StaticUtils {
    public static class Conversation {
        public static bool JoinHousesAllowed() {
           Hero target = Hero.OneToOneConversationHero;
           bool flag = Hero.MainHero.Spouse != null || target.Spouse != null;

           if (flag)
           {
               return false;
            }
            else
            {
               Clan clan = target.Clan;
               bool flag2 = clan == null || !clan.IsNoble || clan.Leader != target;
               return !flag2;
            }

        }

        public static bool JoinHousesAccepted() {
            Hero otherHero = Hero.OneToOneConversationHero;

            float relationNeeded = (float)JoinHouses.Settings.RelationValue;

            if (Hero.MainHero.IsFactionLeader) relationNeeded += -40f;
            if (otherHero.IsFactionLeader) relationNeeded += 50f;

            relationNeeded += (Hero.MainHero.Clan.Tier * -8);
            relationNeeded += (otherHero.Clan.Tier * 10);

            return otherHero.GetRelationWithPlayer() >= relationNeeded;
        }

        public static void JoinHousesHandle() {
            Clan playerClan = Hero.MainHero.Clan;
            Clan otherClan = Hero.OneToOneConversationHero.Clan;

            Utils.JoinHouses(otherClan);

            // Marry
            MarriageAction.Apply(Hero.MainHero, Hero.OneToOneConversationHero);

            // Join party
            if (Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.LeaderHero == Hero.MainHero)
                AddHeroToPartyAction.Apply(Hero.OneToOneConversationHero, Hero.MainHero.PartyBelongedTo);
        }
    }
}
