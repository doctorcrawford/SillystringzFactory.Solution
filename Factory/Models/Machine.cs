using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Machine
{
  public int MachineId { get; set; }
  
  
  [Required(ErrorMessage = "The machine must have a name!")]
  public string Name { get; set; }

  
  [Required(ErrorMessage = "The machine must be given a status!")]
  public string Status { get; set; }

  public List<EngineerMachine> EngineerMachines { get; set; }  
  
  public enum StatusType
  {
    Operational,
    Malfunctioning,
    Repairing
  }
}