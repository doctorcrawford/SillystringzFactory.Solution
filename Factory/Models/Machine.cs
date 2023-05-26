using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Machine
{
  public int MachineId { get; set; }
  [Required(ErrorMessage = "The machine must have a name!")]
  public string Name { get; set; }
  public string Status { get; set; }
  [Required(ErrorMessage = "The machine must be given a status!")]
  public List<EngineerMachine> EngineerMachines { get; set; }
  // public static List<string> StatusType = new List<string> { "Operational", "Malfunctioning", "Repairing" };
  public enum StatusType
  {
    Operational,
    Malfunctioning,
    Repairing
  }
}