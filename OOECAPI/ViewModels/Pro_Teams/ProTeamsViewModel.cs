using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.ViewModels
{
    public class ProTeamsViewModel
    {
       public int Team_Id { get; set; }
       public double Rating { get; set; }
       public int Wins { get; set; }
       public int losses { get; set; }
       public int Last_Match_Time { get; set; }
       public string Name { get; set; }
       public string Tag { get; set; }  
       public string logo_url { get; set; }
    }
}
