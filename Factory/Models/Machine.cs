using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }
    public string MachineName {get; set;}
    public string MachinePurpose {get; set;}
    public string MachineMake { get; set; }
    public string MachineModel { get; set; }
    public int ManufacturedYear { get; set; }

    public virtual ICollection<EngineerMachine> JoinEntities { get;}
  }
}
