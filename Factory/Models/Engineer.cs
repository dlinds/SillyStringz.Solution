using System.Collections.Generic;
using System;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }
      public string Name {get; set;}
      public int EngineerId {get; set;}
      public TimeSpan ShiftStart {get; set;}
      public TimeSpan ShiftEnd {get; set;}
      public virtual ICollection<EngineerMachine> JoinEntities {get; set;}
  }
}
