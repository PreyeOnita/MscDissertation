using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DissertationApp
{
    public class Statistic
    {
        public string year { get; set; }
        public string deaths { get; set; }
        public string male { get; set; }
        public string female { get; set; }
        [JsonProperty("10-14 P")]
        public string ten { get; set; }

        [JsonProperty("15-19 P")]
        public string fifteen { get; set; }
        [JsonProperty("20-24 P")]
        public string twenty { get; set; }
        [JsonProperty("25-29 P")]
        public string twentyfive { get; set; }
        [JsonProperty("30-34 P")]

        public string thirty { get; set; }
        [JsonProperty("35-39 P")]
        public string thirtyfive { get; set; }
        [JsonProperty("40-44 P")]
        public string forty { get; set; }
        [JsonProperty("45-49 P")]
        public string fortyfive { get; set; }
        [JsonProperty("50-54 P")]

        public string fifty { get; set; }
        [JsonProperty("55-59 P")]
        public string fiftyfive { get; set; }
        [JsonProperty("60-64 P")]
        public string sixty { get; set; }
        [JsonProperty("65-69 P")]
        public string sixtyfive { get; set; }
        [JsonProperty("70-74 P")]

        public string seventy { get; set; }
        [JsonProperty("75-79 P")]
        public string seventyfive { get; set; }
        [JsonProperty("80-84 P")]
        public string eighty { get; set; }
        [JsonProperty("85-89 P")]
        public string eightyfive { get; set; }
        [JsonProperty("90+ P")]

        public string ninety { get; set; }
      
        [JsonProperty("North East")]
        public string northeast { get; set; }
        [JsonProperty("North West")]
        public string northwest { get; set; }
        [JsonProperty("Yorkshire")]
        public string yorkshire { get; set; }
        [JsonProperty("East Midlands")]
        public string eastmidlands { get; set; }
        [JsonProperty("West Midlands")]
        public string westmidlands { get; set; }
        [JsonProperty("East of England")]
        public string eastofengland { get; set; }
        [JsonProperty("London")]
        public string london { get; set; }
        [JsonProperty("South East")]
        public string southeast { get; set; }
        [JsonProperty("South West")]
        public string southwest { get; set; }
        //Female
        [JsonProperty("North East F")]
        public string fnortheast { get; set; }
        [JsonProperty("North West F")]
        public string fnorthwest { get; set; }
        [JsonProperty("Yorkshire F")]
        public string fyorkshire { get; set; }
        [JsonProperty("East Midlands F")]
        public string feastmidlands { get; set; }
        [JsonProperty("West Midlands F")]
        public string fwestmidlands { get; set; }
        [JsonProperty("East of England F")]
        public string feastofengland { get; set; }
        [JsonProperty("London F")]
        public string flondon { get; set; }
        [JsonProperty("South East F")]
        public string fsoutheast { get; set; }
        [JsonProperty("South West F")]
        public string fsouthwest { get; set; }
        //male
        [JsonProperty("North East M")]
        public string mnortheast { get; set; }
        [JsonProperty("North West M")]
        public string mnorthwest { get; set; }
        [JsonProperty("Yorkshire M")]
        public string myorkshire { get; set; }
        [JsonProperty("East Midlands M")]
        public string meastmidlands { get; set; }
        [JsonProperty("West Midlands M")]
        public string mwestmidlands { get; set; }
        [JsonProperty("East of England M")]
        public string meastofengland { get; set; }
        [JsonProperty("London M")]
        public string mlondon { get; set; }
        [JsonProperty("South East M")]
        public string msoutheast { get; set; }
        [JsonProperty("South West M")]
        public string msouthwest { get; set; }



    }
    /*
       public class Service
       {
           public string nt { get; set; }
           public string te { get; set; }
           public string etw { get; set; }
           public string twth { get; set; }
           public string thfo { get; set; }
           public string fofi { get; set; }
           public string fisi { get; set; }
           public string popNT { get; set; }
           public string popTE { get; set; }
           public string popETw { get; set; }
           public string popTwTh { get; set; }
           public string popThFo { get; set; }
           public string popFoFi { get; set; }
           public string popFiSi { get; set; }

       }
    */
    /*
        
    public class Population
    {
        public string nt { get; set; }
        public string te { get; set; }
        public string etw { get; set; }
        public string twth { get; set; }
        public string thfo { get; set; }
        public string fofi { get; set; }
        public string fisi { get; set; }
    }
    public class Pop
    {
        public string popNT { get; set; }
        public string popTE { get; set; }
        public string popETw { get; set; }
        public string popTwTh { get; set; }
        public string popThFo { get; set; }
        public string popFoFi { get; set; }
        public string popFiSi { get; set; }
    }
    public class Service
    {

        public string sector { get; set; }
        [JsonProperty("Population")]
        public Population messagePopulation { get; set; }
        [JsonProperty("Pop")]
        public Pop messagePop { get; set; }
    }
    */
}
