using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bolao.Aplicacao.ViewModels
{
    public class SelfViewModel
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class CompetitionViewModel
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class HrefTeamViewModel
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class LinksViewModel
    {
        [JsonProperty("self")]
        public SelfViewModel Self { get; set; }

        [JsonProperty("competition")]
        public CompetitionViewModel Competition { get; set; }

        [JsonProperty("homeTeam")]
        public HrefTeamViewModel HomeTeam { get; set; }

        [JsonProperty("competition")]
        public HrefTeamViewModel AwayTeam { get; set; }
    }

    public class ResultViewModel
    {
        [JsonProperty("goalsHomeTeam")]
        public int? GoalsHomeTeam { get; set; }

        [JsonProperty("goalsAwayTeam")]
        public int? GoalsAwayTeam { get; set; }
    }

    public class FixtureViewModel
    {
        [JsonProperty("_links")]
        public LinksViewModel Links { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("matchday")]
        public int Matchday { get; set; }

        [JsonProperty("homeTeamName")]
        public string HomeTeamName { get; set; }

        [JsonProperty("awayTeamName")]
        public string AwayTeamName { get; set; }

        [JsonProperty("result")]
        public ResultViewModel Result { get; set; }

        [JsonProperty("odds")]
        public object Odds { get; set; }
    }

    public class ResultadoViewModel
    {
        [JsonProperty("_links")]
        public LinksViewModel Links { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("fixtures")]
        public IList<FixtureViewModel> Fixtures { get; set; }
    }

    public class TeamViewModel
    {
        [JsonProperty("_links")]
        public LinksViewModel Links { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("squadMarketValue")]
        public object SquadMarketValue { get; set; }

        [JsonProperty("crestUrl")]
        public string CrestUrl { get; set; }
    }

    public class TimesViewModel
    {
        [JsonProperty("_links")]
        public LinksViewModel Links { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("teams")]
        public IList<TeamViewModel> Teams { get; set; }
    }

    public class AViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class BViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class CViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class DViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class EViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class FViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class GViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class HViewModel
    {

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestURI { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public int GoalDifference { get; set; }
    }

    public class StandingsViewModel
    {
        [JsonProperty("A")]
        public IList<AViewModel> A { get; set; }

        [JsonProperty("B")]
        public IList<BViewModel> B { get; set; }

        [JsonProperty("C")]
        public IList<CViewModel> C { get; set; }

        [JsonProperty("D")]
        public IList<DViewModel> D { get; set; }

        [JsonProperty("E")]
        public IList<EViewModel> E { get; set; }

        [JsonProperty("F")]
        public IList<FViewModel> F { get; set; }

        [JsonProperty("G")]
        public IList<GViewModel> G { get; set; }

        [JsonProperty("H")]
        public IList<HViewModel> H { get; set; }
    }

    public class TabelaViewModel
    {
        [JsonProperty("leagueCaption")]
        public string LeagueCaption { get; set; }

        [JsonProperty("matchday")]
        public int Matchday { get; set; }

        [JsonProperty("standings")]
        public StandingsViewModel Standings { get; set; }
    }
}
