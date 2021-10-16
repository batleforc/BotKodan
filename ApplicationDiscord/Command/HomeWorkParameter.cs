using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Discord.Commands;

namespace ApplicationDiscord.Command
{
  [NamedArgumentType]
  public class HomeWorkParameter
  {
    public string Label { get; set; }
    public string Matter { get; set; } = null;
    public string Due { get; set; } = null;
    public string Content { get; set; } = null;
  }
}
